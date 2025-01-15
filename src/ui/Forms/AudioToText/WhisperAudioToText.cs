using Nikse.SubtitleEdit.Controls;
using Nikse.SubtitleEdit.Core.AudioToText;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.ContainerFormats.Matroska;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using Nikse.SubtitleEdit.Forms.Options;
using Nikse.SubtitleEdit.Logic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = Nikse.SubtitleEdit.Forms.SeMsgBox.MessageBox;

namespace Nikse.SubtitleEdit.Forms.AudioToText
{
    public sealed partial class WhisperAudioToText : Form
    {
        private readonly string _videoFileName;
        private Subtitle _subtitle;
        private readonly int _audioTrackNumber;
        private bool _cancel;
        private bool _batchMode;
        private int _batchFileNumber;
        private readonly List<string> _filesToDelete;
        private readonly Form _parentForm;
        private bool _useCenterChannelOnly;
        private List<ResultText> _resultList;
        private string _languageCode;

        public bool UnknownArgument { get; set; }
        public bool RunningOnCuda { get; set; }
        public bool IncompleteModel { get; set; }
        public string IncompleteModelName { get; set; }

        public Subtitle TranscribedSubtitle { get; private set; }
        private WhisperAPITools _whisperApi = new WhisperAPITools();
        public WhisperAudioToText(string videoFileName, Subtitle subtitle, int audioTrackNumber, Form parentForm, WavePeakData wavePeaks)
        {
            UiUtil.PreInitialize(this);
            InitializeComponent();
            _videoFileName = videoFileName;
            _subtitle = subtitle;
            _audioTrackNumber = audioTrackNumber;
            _parentForm = parentForm;

            _filesToDelete = new List<string>();

            if (Configuration.Settings.Tools.WhisperChoice == WhisperChoice.PurfviewFasterWhisperXxl
                && !string.IsNullOrEmpty(Configuration.Settings.Tools.WhisperPurfviewFasterWhisperDefaultCmd))
            {
                Configuration.Settings.Tools.WhisperExtraSettings = Configuration.Settings.Tools.WhisperPurfviewFasterWhisperDefaultCmd;
            }

            Generate();
        }

        private async void Generate()
        {
            _useCenterChannelOnly = Configuration.Settings.General.FFmpegUseCenterChannelOnly &&
                                    FfmpegMediaInfo.Parse(_videoFileName).HasFrontCenterAudio(_audioTrackNumber);


            var mediaInfo = FfmpegMediaInfo.Parse(_videoFileName);
            if (mediaInfo.Tracks.Count(p => p.TrackType == FfmpegTrackType.Audio) == 0)
            {
                MessageBox.Show("No audio track in file: " + _videoFileName);
                return;
            }

            var waveFileName = GenerateWavFile(_videoFileName, _audioTrackNumber);
            
            await TranscribeViaWhisper(waveFileName, _videoFileName);
            DialogResult = DialogResult.OK;
        }

        internal static string GetLanguage(string name)
        {
            var language = WhisperLanguage.Languages.FirstOrDefault(l => l.Name == name);
            return language != null ? language.Code : "en";
        }

        public async Task<Subtitle> TranscribeViaWhisper(string waveFileName, string videoFileName)
        {
            var result = new List<ResultText>();
            var response = await _whisperApi.SendAudioFile(waveFileName);
            foreach (var item in response)
            {
                result.Add(new ResultText()
                {
                    Confidence = (decimal)item.Score,
                    Start = (decimal)item.End,
                    End = (decimal)item.End,
                    Text = item.Text
                });
            }

            TranscribedSubtitle = new Subtitle();
            foreach (var x in response)
            {
                TranscribedSubtitle.Paragraphs.Add(new Paragraph()
                {
                    Text = x.Text,
                    StartTime = TimeCode.FromSeconds((double)x.Start),
                    EndTime = TimeCode.FromSeconds((double)x.End)
                });
            }

            return TranscribedSubtitle;

            var sub = new Subtitle();
            sub.Paragraphs.AddRange(result.OrderBy(p => p.Start).Select(p => new Paragraph(p.Text, (double)p.Start * 1000.0, (double)p.End * 1000.0)).ToList());
            return sub;
        }


        private string GenerateWavFile(string videoFileName, int audioTrackNumber)
        {
            if (videoFileName.EndsWith(".wav"))
            {
                try
                {
                    using (var waveFile = new WavePeakGenerator(videoFileName))
                    {
                        if (waveFile.Header != null && waveFile.Header.SampleRate == 16000)
                        {
                            return videoFileName;
                        }
                    }
                }
                catch
                {
                    // ignore
                }
            }

            var ffmpegLog = new StringBuilder();
            var outWaveFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".wav");
            _filesToDelete.Add(outWaveFile);
            var process = GetFfmpegProcess(videoFileName, audioTrackNumber, outWaveFile);

            process.ErrorDataReceived += (sender, args) =>
            {
                ffmpegLog.AppendLine(args.Data);
            };

            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.BeginErrorReadLine();

            double seconds = 0;
            try
            {
                process.PriorityClass = ProcessPriorityClass.Normal;
            }
            catch
            {
                // ignored
            }

            _cancel = false;
            string targetDriveLetter = null;
            if (Configuration.IsRunningOnWindows)
            {
                var root = Path.GetPathRoot(outWaveFile);
                if (root.Length > 1 && root[1] == ':')
                {
                    targetDriveLetter = root.Remove(1);
                }
            }

            while (!process.HasExited)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
                seconds += 0.1;

                Invalidate();
                if (_cancel)
                {
                    process.Kill();
                    DialogResult = DialogResult.Cancel;
                    return null;
                }
            }

            Application.DoEvents();
            System.Threading.Thread.Sleep(100);

            if (!File.Exists(outWaveFile))
            {
                SeLogger.WhisperInfo("Generated wave file not found: " + outWaveFile + Environment.NewLine +
                               "ffmpeg: " + process.StartInfo.FileName + Environment.NewLine +
                               "Parameters: " + process.StartInfo.Arguments + Environment.NewLine +
                               "OS: " + Environment.OSVersion + Environment.NewLine +
                               "64-bit: " + Environment.Is64BitOperatingSystem + Environment.NewLine +
                               "ffmpeg exit code: " + process.ExitCode + Environment.NewLine +
                               "ffmpeg log: " + ffmpegLog);
            }

            return outWaveFile;
        }

        private Process GetFfmpegProcess(string videoFileName, int audioTrackNumber, string outWaveFile)
        {
            if (!File.Exists(Configuration.Settings.General.FFmpegLocation) && Configuration.IsRunningOnWindows)
            {
                return null;
            }

            var audioParameter = string.Empty;
            if (audioTrackNumber > 0)
            {
                audioParameter = $"-map 0:a:{audioTrackNumber}";
            }

            var fFmpegWaveTranscodeSettings = "-i \"{0}\" -vn -ar 16000 -ac 1 -ab 32k -af volume=1.75 -f wav {2} \"{1}\"";
            if (_useCenterChannelOnly)
            {
                fFmpegWaveTranscodeSettings = "-i \"{0}\" -vn -ar 16000 -ab 32k -af volume=1.75 -af \"pan=mono|c0=FC\" -f wav {2} \"{1}\"";
            }

            //-i indicates the input
            //-vn means no video output
            //-ar 44100 indicates the sampling frequency.
            //-ab indicates the bit rate (in this example 160kb/s)
            //-af volume=1.75 will boot volume... 1.0 is normal
            //-ac 2 means 2 channels
            // "-map 0:a:0" is the first audio stream, "-map 0:a:1" is the second audio stream

            var exeFilePath = Configuration.Settings.General.FFmpegLocation;
            if (!Configuration.IsRunningOnWindows)
            {
                exeFilePath = "ffmpeg";
            }

            var parameters = string.Format(fFmpegWaveTranscodeSettings, videoFileName, outWaveFile, audioParameter);
            return new Process
            {
                StartInfo = new ProcessStartInfo(exeFilePath, parameters)
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                }
            };
        }

        private void AudioToText_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskbarList.SetProgressState(_parentForm.Handle, TaskbarButtonProgressFlags.NoProgress);
            DeleteTemporaryFiles(_filesToDelete);
        }

        public static void DeleteTemporaryFiles(List<string> filesToDelete)
        {
            foreach (var fileName in filesToDelete)
            {
                try
                {
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }
                catch
                {
                    // ignore
                }
            }
        }

        private void AudioToText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyData == UiUtil.HelpKeys)
            {
                UiUtil.ShowHelp("#audio_to_text_whisper");
                e.SuppressKeyPress = true;
            }
        }

        private void WhisperAudioToText_Activated(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}
