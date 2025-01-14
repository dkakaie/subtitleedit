using Nikse.SubtitleEdit.Core.AudioToText;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Forms.Options;
using Nikse.SubtitleEdit.Logic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MessageBox = Nikse.SubtitleEdit.Forms.SeMsgBox.MessageBox;

namespace Nikse.SubtitleEdit.Forms.AudioToText
{
    public sealed partial class WhisperAudioToTextSelectedLines : Form
    {
        private bool _cancel;
        private int _batchFileNumber;
        private readonly List<AudioClipsGet.AudioClip> _audioClips;
        private readonly Form _parentForm;
        private readonly List<string> _filesToDelete;
        private List<ResultText> _resultList;
        private string _languageCode;
        private ConcurrentBag<string> _outputText = new ConcurrentBag<string>();

        public Subtitle TranscribedSubtitle { get; private set; }

        public WhisperAudioToTextSelectedLines(List<AudioClipsGet.AudioClip> audioClips, Form parentForm)
        {
            UiUtil.PreInitialize(this);
            InitializeComponent();
            UiUtil.FixFonts(this);
            UiUtil.FixLargeFonts(this, buttonGenerate);
            _parentForm = parentForm;
            _filesToDelete = new List<string>();

            Text = LanguageSettings.Current.AudioToText.Title;
            labelInfo.Text = LanguageSettings.Current.AudioToText.WhisperInfo;
            groupBoxModels.Text = LanguageSettings.Current.AudioToText.LanguagesAndModels;
            labelModel.Text = LanguageSettings.Current.AudioToText.ChooseModel;
            labelChooseLanguage.Text = LanguageSettings.Current.AudioToText.ChooseLanguage;
            linkLabelOpenModelsFolder.Text = LanguageSettings.Current.AudioToText.OpenModelsFolder;
            checkBoxUsePostProcessing.Text = LanguageSettings.Current.AudioToText.UsePostProcessing;
            linkLabelPostProcessingConfigure.Left = checkBoxUsePostProcessing.Right + 1;
            linkLabelPostProcessingConfigure.Text = LanguageSettings.Current.Settings.Title;
            buttonGenerate.Text = LanguageSettings.Current.Watermark.Generate;
            buttonCancel.Text = LanguageSettings.Current.General.Cancel;
            groupBoxInputFiles.Text = LanguageSettings.Current.BatchConvert.Input;
            linkLabeWhisperWebSite.Text = LanguageSettings.Current.AudioToText.WhisperWebsite;
            labelAdvanced.Text = Configuration.Settings.Tools.WhisperExtraSettings;
            columnHeaderFileName.Text = LanguageSettings.Current.JoinSubtitles.FileName;
            checkBoxUsePostProcessing.Checked = Configuration.Settings.Tools.VoskPostProcessing;

            Init();

            listViewInputFiles.Visible = true;
            _audioClips = audioClips;
            foreach (var audioClip in audioClips)
            {
                listViewInputFiles.Items.Add(audioClip.AudioFileName);
            }
        }

        private void Init()
        {
            WhisperAudioToText.InitializeLanguageNames(comboBoxLanguages);

            WhisperAudioToText.FillModels(comboBoxModels, string.Empty);

            removeTemporaryFilesToolStripMenuItem.Checked = Configuration.Settings.Tools.WhisperDeleteTempFiles;

            ContextMenuStrip = contextMenuStripWhisperAdvanced;
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            if (comboBoxModels.Items.Count == 0)
            {
                return;
            }

            if (listViewInputFiles.Items.Count == 0)
            {
                return;
            }

            GenerateBatch();
            TaskbarList.SetProgressState(_parentForm.Handle, TaskbarButtonProgressFlags.NoProgress);
        }

        private void GenerateBatch()
        {
            _languageCode = WhisperAudioToText.GetLanguage(comboBoxLanguages.Text);
            groupBoxInputFiles.Enabled = false;
            comboBoxLanguages.Enabled = false;
            comboBoxModels.Enabled = false;
            linkLabelPostProcessingConfigure.Enabled = false;
            _batchFileNumber = 0;
            var postProcessor = new AudioToTextPostProcessor(_languageCode)
            {
                ParagraphMaxChars = Configuration.Settings.General.SubtitleLineMaximumLength * 2,
            };
            _outputText.Add("Batch mode");
            timer1.Start();
            foreach (ListViewItem lvi in listViewInputFiles.Items)
            {
                _batchFileNumber++;
                var videoFileName = lvi.Text;
                listViewInputFiles.SelectedIndices.Clear();
                lvi.Selected = true;
                buttonGenerate.Enabled = false;
                buttonDownload.Enabled = false;
                comboBoxModels.Enabled = false;
                linkLabelPostProcessingConfigure.Enabled = false;
                comboBoxLanguages.Enabled = false;
                var waveFileName = videoFileName;

                _outputText.Add(string.Empty);
                var transcript = TranscribeViaWhisper(waveFileName, videoFileName);
                if (_cancel)
                {
                    TaskbarList.SetProgressState(_parentForm.Handle, TaskbarButtonProgressFlags.NoProgress);
                    groupBoxInputFiles.Enabled = true;
                    return;
                }

                TranscribedSubtitle = postProcessor.Fix(
                    AudioToTextPostProcessor.Engine.Whisper,
                    transcript,
                    checkBoxUsePostProcessing.Checked,
                    Configuration.Settings.Tools.WhisperPostProcessingAddPeriods,
                    Configuration.Settings.Tools.WhisperPostProcessingMergeLines,
                    Configuration.Settings.Tools.WhisperPostProcessingFixCasing,
                    Configuration.Settings.Tools.WhisperPostProcessingFixShortDuration,
                    Configuration.Settings.Tools.WhisperPostProcessingSplitLines);

                SaveToAudioClip(_batchFileNumber - 1);
                TaskbarList.SetProgressValue(_parentForm.Handle, _batchFileNumber, listViewInputFiles.Items.Count);
            }

            timer1.Stop();
            PostFix(postProcessor);

            DialogResult = DialogResult.OK;
        }

        public List<ResultText> TranscribeViaWhisper(string waveFileName, string videoFileName)
        {
            var model = comboBoxModels.Items[comboBoxModels.SelectedIndex] as WhisperModel;
            if (model == null)
            {
                return new List<ResultText>();
            }

            if (WhisperAudioToText.GetResultFromSrt(waveFileName, videoFileName, out var resultTexts, _outputText, null))
            {
                return resultTexts;
            }

            return _resultList;
        }

        private void PostFix(AudioToTextPostProcessor postProcessor)
        {
            var postSub = new Subtitle();
            foreach (var audioClip in _audioClips)
            {
                postSub.Paragraphs.Add(audioClip.Paragraph);
            }

            var postSubFixed = postProcessor.Fix(
                postSub,
                checkBoxUsePostProcessing.Checked,
                Configuration.Settings.Tools.WhisperPostProcessingAddPeriods,
                Configuration.Settings.Tools.WhisperPostProcessingMergeLines,
                Configuration.Settings.Tools.WhisperPostProcessingFixCasing,
                Configuration.Settings.Tools.WhisperPostProcessingFixShortDuration,
                Configuration.Settings.Tools.WhisperPostProcessingSplitLines,
                AudioToTextPostProcessor.Engine.Whisper);

            for (var index = 0; index < _audioClips.Count; index++)
            {
                var audioClip = _audioClips[index];
                if (index < postSubFixed.Paragraphs.Count)
                {
                    audioClip.Paragraph.Text = postSubFixed.Paragraphs[index].Text;
                }
            }
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

        private void linkLabelWhisperWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UiUtil.OpenUrl(WhisperHelper.GetWebSiteUrl());
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

        private void linkLabelOpenModelFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UiUtil.OpenFolder(WhisperHelper.GetWhisperModel().ModelFolder);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateLog();
        }

        private void ShowHideBatchMode()
        {
            Height = checkBoxUsePostProcessing.Bottom + buttonCancel.Height + 450;
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
