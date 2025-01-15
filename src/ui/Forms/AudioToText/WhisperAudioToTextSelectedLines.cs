using Nikse.SubtitleEdit.Core.AudioToText;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Forms.Options;
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
            UiUtil.FixFonts(this);
            UiUtil.FixLargeFonts(this, buttonGenerate);
            _parentForm = parentForm;
            _filesToDelete = new List<string>();

            groupBoxModels.Text = LanguageSettings.Current.AudioToText.LanguagesAndModels;
            labelModel.Text = LanguageSettings.Current.AudioToText.ChooseModel;
            labelChooseLanguage.Text = LanguageSettings.Current.AudioToText.ChooseLanguage;
            buttonGenerate.Text = LanguageSettings.Current.Watermark.Generate;
            buttonCancel.Text = LanguageSettings.Current.General.Cancel;
            groupBoxInputFiles.Text = LanguageSettings.Current.BatchConvert.Input;
            columnHeaderFileName.Text = LanguageSettings.Current.JoinSubtitles.FileName;

            Init();

            listViewInputFiles.Visible = true;
            _audioClips = audioClips;
            foreach (var audioClip in audioClips)
            {
                listViewInputFiles.Items.Add(audioClip.AudioFileName);
            }

            ButtonGenerate_Click(null, null);
        }

        private void Init()
        {
            WhisperAudioToText.InitializeLanguageNames(comboBoxLanguages);

            WhisperAudioToText.FillModels(comboBoxModels, string.Empty);

            removeTemporaryFilesToolStripMenuItem.Checked = Configuration.Settings.Tools.WhisperDeleteTempFiles;

            ContextMenuStrip = contextMenuStripWhisperAdvanced;
        }

        private async void ButtonGenerate_Click(object sender, EventArgs e)
        {
            if (listViewInputFiles.Items.Count == 0)
            {
                return;
            }

            await GenerateBatch();
            TaskbarList.SetProgressState(_parentForm.Handle, TaskbarButtonProgressFlags.NoProgress);
        }

        private async Task GenerateBatch()
        {
            _languageCode = WhisperAudioToText.GetLanguage(comboBoxLanguages.Text);
            groupBoxInputFiles.Enabled = false;
            comboBoxLanguages.Enabled = false;
            comboBoxModels.Enabled = false;
            _batchFileNumber = 0;
            _outputText.Add("Batch mode");
            timer1.Start();
            foreach (ListViewItem lvi in listViewInputFiles.Items)
            {
                _batchFileNumber++;
                var videoFileName = lvi.Text;
                listViewInputFiles.SelectedIndices.Clear();
                lvi.Selected = true;
                buttonGenerate.Enabled = false;
                comboBoxModels.Enabled = false;
                comboBoxLanguages.Enabled = false;
                var waveFileName = videoFileName;

                _outputText.Add(string.Empty);
                var transcript = await TranscribeViaWhisper(waveFileName, videoFileName, _languageCode);
                if (_cancel)
                {
                    TaskbarList.SetProgressState(_parentForm.Handle, TaskbarButtonProgressFlags.NoProgress);
                    groupBoxInputFiles.Enabled = true;
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
                TaskbarList.SetProgressValue(_parentForm.Handle, _batchFileNumber, listViewInputFiles.Items.Count);
            }

            timer1.Stop();
            DialogResult = DialogResult.OK;
        }

        public async Task<List<ResultText>> TranscribeViaWhisper(string waveFileName, string videoFileName, string language)
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (buttonGenerate.Enabled)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                _cancel = true;
            }
        }


        private void AudioToText_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comboBoxModels.SelectedItem is WhisperModel model)
            {
                Configuration.Settings.Tools.WhisperModel = model.Name;
            }

            if (comboBoxLanguages.SelectedItem is WhisperLanguage language)
            {
                Configuration.Settings.Tools.WhisperLanguageCode = language.Code;
            }

            WhisperAudioToText.DeleteTemporaryFiles(_filesToDelete);
        }

        private void AudioToText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && buttonGenerate.Enabled)
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

        private void ShowHideBatchMode()
        {
            listViewInputFiles.Visible = true;
        }

        private void AudioToText_Load(object sender, EventArgs e)
        {
            ShowHideBatchMode();
            listViewInputFiles.Columns[0].Width = -2;
        }

        private void AudioToTextSelectedLines_Shown(object sender, EventArgs e)
        {
            buttonGenerate.Focus();
        }

        private void AudioToTextSelectedLines_ResizeEnd(object sender, EventArgs e)
        {
            listViewInputFiles.AutoSizeLastColumn();
        }

        private void comboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguages.SelectedIndex > 0 && comboBoxLanguages.Text == LanguageSettings.Current.General.ChangeLanguageFilter)
            {
                using (var form = new DefaultLanguagesChooser(Configuration.Settings.General.DefaultLanguages))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        Configuration.Settings.General.DefaultLanguages = form.DefaultLanguages;
                    }
                }

                WhisperAudioToText.InitializeLanguageNames(comboBoxLanguages);
                return;
            }
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
