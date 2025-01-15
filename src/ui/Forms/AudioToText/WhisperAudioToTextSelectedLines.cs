using Nikse.SubtitleEdit.Core.AudioToText;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Logic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikse.SubtitleEdit.Forms.AudioToText
{
    public sealed partial class WhisperAudioToTextSelectedLines : Form
    {
        private bool _cancel;
        private int _batchFileNumber;
        private readonly List<AudioClipsGet.AudioClip> _audioClips;
        private readonly Form _parentForm;
        private readonly List<string> _filesToDelete;
        private string _languageCode;
        private ConcurrentBag<string> _outputText = new ConcurrentBag<string>();
        private WhisperAPITools _whisperApi = new WhisperAPITools();

        public Subtitle TranscribedSubtitle { get; private set; }

        public WhisperAudioToTextSelectedLines(List<AudioClipsGet.AudioClip> audioClips, Form parentForm)
        {
            UiUtil.PreInitialize(this);
            InitializeComponent();
            _parentForm = parentForm;
            _filesToDelete = new List<string>();

            _audioClips = audioClips;

            Init();
            RunInference();
        }

        private void Init()
        {
            removeTemporaryFilesToolStripMenuItem.Checked = Configuration.Settings.Tools.WhisperDeleteTempFiles;

            ContextMenuStrip = contextMenuStripWhisperAdvanced;
        }

        private async void RunInference()
        {
            if (_audioClips.Count == 0)
            {
                return;
            }

            await GenerateBatch();
            TaskbarList.SetProgressState(_parentForm.Handle, TaskbarButtonProgressFlags.NoProgress);
        }

        private async Task GenerateBatch()
        {
            _languageCode = "fa";
            _batchFileNumber = 0;
            _outputText.Add("Batch mode");
            timer1.Start();
            foreach (var lvi in _audioClips)
            {
                _batchFileNumber++;

                _outputText.Add(string.Empty);
                var transcript = await TranscribeViaWhisper(lvi.AudioFileName, _languageCode);
                if (_cancel)
                {
                    TaskbarList.SetProgressState(_parentForm.Handle, TaskbarButtonProgressFlags.NoProgress);
                    return;
                }

                TranscribedSubtitle = new Subtitle();
                foreach (var x in transcript)
                {
                    TranscribedSubtitle.Paragraphs.Add(new Paragraph()
                    {
                        Text = x.Text,
                        StartTime = TimeCode.FromSeconds((double)x.Start),
                        EndTime = TimeCode.FromSeconds((double)x.End)
                    });
                }

                SaveToAudioClip(_batchFileNumber - 1);
                TaskbarList.SetProgressValue(_parentForm.Handle, _batchFileNumber, _audioClips.Count);
            }

            timer1.Stop();
            DialogResult = DialogResult.OK;
        }

        public async Task<List<ResultText>> TranscribeViaWhisper(string waveFileName, string language)
        {
            var result = new List<ResultText>();
            var response =  await _whisperApi.SendAudioFile(waveFileName, language);
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

            return result;
        }

        private void SaveToAudioClip(int index)
        {
            var audioClip = _audioClips[index];

            var sb = new StringBuilder();
            foreach (var p in TranscribedSubtitle.Paragraphs)
            {
                sb.AppendLine(p.Text);
            }

            audioClip.Paragraph.Text = sb.ToString().Trim();

            try
            {
                File.Delete(audioClip.AudioFileName);
            }
            catch
            {
                // ignore
            }
        }

        private void AudioToText_FormClosing(object sender, FormClosingEventArgs e)
        {
            WhisperAudioToText.DeleteTemporaryFiles(_filesToDelete);
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

        private void UpdateLog()
        {
            if (_outputText.IsEmpty)
            {
                return;
            }

            _outputText = new ConcurrentBag<string>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLog();
        }

        private void removeTemporaryFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration.Settings.Tools.WhisperDeleteTempFiles = !Configuration.Settings.Tools.WhisperDeleteTempFiles;
            removeTemporaryFilesToolStripMenuItem.Checked = Configuration.Settings.Tools.WhisperDeleteTempFiles;
        }

        private void WhisperAudioToTextSelectedLines_Activated(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}
