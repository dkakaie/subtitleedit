namespace Nikse.SubtitleEdit.Forms.AudioToText
{
    sealed partial class WhisperAudioToText
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.groupBoxModels = new System.Windows.Forms.GroupBox();
            this.labelChooseLanguage = new System.Windows.Forms.Label();
            this.comboBoxLanguages = new Nikse.SubtitleEdit.Controls.NikseComboBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.labelModel = new System.Windows.Forms.Label();
            this.comboBoxModels = new Nikse.SubtitleEdit.Controls.NikseComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxUsePostProcessing = new System.Windows.Forms.CheckBox();
            this.buttonBatchMode = new System.Windows.Forms.Button();
            this.groupBoxInputFiles = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRemoveFile = new System.Windows.Forms.Button();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.listViewInputFiles = new System.Windows.Forms.ListView();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelFC = new System.Windows.Forms.Label();
            this.labelElapsed = new System.Windows.Forms.Label();
            this.contextMenuStripWhisperAdvanced = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runOnlyPostProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorRunOnlyPostprocessing = new System.Windows.Forms.ToolStripSeparator();
            this.setCPPConstmeModelsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTemporaryFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadNvidiaCudaForCPPCuBLASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWhisperlogtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxAutoAdjustTimings = new System.Windows.Forms.CheckBox();
            this.labelAdvanced = new System.Windows.Forms.Label();
            this.linkLabelPostProcessingConfigure = new System.Windows.Forms.LinkLabel();
            this.groupBoxModels.SuspendLayout();
            this.groupBoxInputFiles.SuspendLayout();
            this.contextMenuStripWhisperAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(631, 487);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(95, 23);
            this.buttonCancel.TabIndex = 94;
            this.buttonCancel.Text = "C&ancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGenerate.Location = new System.Drawing.Point(382, 487);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(125, 23);
            this.buttonGenerate.TabIndex = 90;
            this.buttonGenerate.Text = "&Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 487);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(364, 12);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(12, 469);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(70, 13);
            this.labelProgress.TabIndex = 6;
            this.labelProgress.Text = "labelProgress";
            // 
            // groupBoxModels
            // 
            this.groupBoxModels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxModels.Controls.Add(this.labelChooseLanguage);
            this.groupBoxModels.Controls.Add(this.comboBoxLanguages);
            this.groupBoxModels.Controls.Add(this.buttonDownload);
            this.groupBoxModels.Controls.Add(this.labelModel);
            this.groupBoxModels.Controls.Add(this.comboBoxModels);
            this.groupBoxModels.Location = new System.Drawing.Point(15, 12);
            this.groupBoxModels.Name = "groupBoxModels";
            this.groupBoxModels.Size = new System.Drawing.Size(711, 140);
            this.groupBoxModels.TabIndex = 10;
            this.groupBoxModels.TabStop = false;
            this.groupBoxModels.Text = "Language and models";
            // 
            // labelChooseLanguage
            // 
            this.labelChooseLanguage.AutoSize = true;
            this.labelChooseLanguage.Location = new System.Drawing.Point(3, 21);
            this.labelChooseLanguage.Name = "labelChooseLanguage";
            this.labelChooseLanguage.Size = new System.Drawing.Size(90, 13);
            this.labelChooseLanguage.TabIndex = 4;
            this.labelChooseLanguage.Text = "Choose language";
            // 
            // comboBoxLanguages
            // 
            this.comboBoxLanguages.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxLanguages.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.comboBoxLanguages.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.comboBoxLanguages.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.comboBoxLanguages.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBoxLanguages.ButtonForeColorDown = System.Drawing.Color.Orange;
            this.comboBoxLanguages.ButtonForeColorOver = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.comboBoxLanguages.DropDownHeight = 400;
            this.comboBoxLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguages.DropDownWidth = 240;
            this.comboBoxLanguages.FormattingEnabled = true;
            this.comboBoxLanguages.Location = new System.Drawing.Point(6, 44);
            this.comboBoxLanguages.MaxLength = 32767;
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.SelectedIndex = -1;
            this.comboBoxLanguages.SelectedItem = null;
            this.comboBoxLanguages.SelectedText = "";
            this.comboBoxLanguages.Size = new System.Drawing.Size(194, 24);
            this.comboBoxLanguages.TabIndex = 0;
            this.comboBoxLanguages.UsePopupWindow = true;
            this.comboBoxLanguages.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguages_SelectedIndexChanged);
            // 
            // buttonDownload
            // 
            this.buttonDownload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonDownload.Location = new System.Drawing.Point(255, 100);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(28, 23);
            this.buttonDownload.TabIndex = 2;
            this.buttonDownload.Text = "...";
            this.buttonDownload.UseVisualStyleBackColor = true;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(6, 81);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(167, 13);
            this.labelModel.TabIndex = 0;
            this.labelModel.Text = "Choose speech recognition model";
            // 
            // comboBoxModels
            // 
            this.comboBoxModels.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxModels.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.comboBoxModels.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.comboBoxModels.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.comboBoxModels.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBoxModels.ButtonForeColorDown = System.Drawing.Color.Orange;
            this.comboBoxModels.ButtonForeColorOver = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.comboBoxModels.DropDownHeight = 400;
            this.comboBoxModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModels.DropDownWidth = 240;
            this.comboBoxModels.FormattingEnabled = true;
            this.comboBoxModels.Location = new System.Drawing.Point(9, 101);
            this.comboBoxModels.MaxLength = 32767;
            this.comboBoxModels.Name = "comboBoxModels";
            this.comboBoxModels.SelectedIndex = -1;
            this.comboBoxModels.SelectedItem = null;
            this.comboBoxModels.SelectedText = "";
            this.comboBoxModels.Size = new System.Drawing.Size(240, 24);
            this.comboBoxModels.TabIndex = 1;
            this.comboBoxModels.UsePopupWindow = false;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(12, 502);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(88, 13);
            this.labelTime.TabIndex = 6;
            this.labelTime.Text = "Remaining time...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxUsePostProcessing
            // 
            this.checkBoxUsePostProcessing.AutoSize = true;
            this.checkBoxUsePostProcessing.Location = new System.Drawing.Point(15, 199);
            this.checkBoxUsePostProcessing.Name = "checkBoxUsePostProcessing";
            this.checkBoxUsePostProcessing.Size = new System.Drawing.Size(312, 17);
            this.checkBoxUsePostProcessing.TabIndex = 22;
            this.checkBoxUsePostProcessing.Text = "Use post-processing (line merge, fix casing, and punctuation)";
            this.checkBoxUsePostProcessing.UseVisualStyleBackColor = true;
            // 
            // buttonBatchMode
            // 
            this.buttonBatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBatchMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonBatchMode.Location = new System.Drawing.Point(513, 487);
            this.buttonBatchMode.Name = "buttonBatchMode";
            this.buttonBatchMode.Size = new System.Drawing.Size(112, 23);
            this.buttonBatchMode.TabIndex = 92;
            this.buttonBatchMode.Text = "Batch mode";
            this.buttonBatchMode.UseVisualStyleBackColor = true;
            this.buttonBatchMode.Click += new System.EventHandler(this.buttonBatchMode_Click);
            // 
            // groupBoxInputFiles
            // 
            this.groupBoxInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInputFiles.Controls.Add(this.buttonClear);
            this.groupBoxInputFiles.Controls.Add(this.buttonRemoveFile);
            this.groupBoxInputFiles.Controls.Add(this.buttonAddFile);
            this.groupBoxInputFiles.Controls.Add(this.listViewInputFiles);
            this.groupBoxInputFiles.Location = new System.Drawing.Point(15, 274);
            this.groupBoxInputFiles.Name = "groupBoxInputFiles";
            this.groupBoxInputFiles.Size = new System.Drawing.Size(711, 171);
            this.groupBoxInputFiles.TabIndex = 30;
            this.groupBoxInputFiles.TabStop = false;
            this.groupBoxInputFiles.Text = "Input files";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(631, 73);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(74, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonRemoveFile
            // 
            this.buttonRemoveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveFile.Location = new System.Drawing.Point(632, 46);
            this.buttonRemoveFile.Name = "buttonRemoveFile";
            this.buttonRemoveFile.Size = new System.Drawing.Size(74, 23);
            this.buttonRemoveFile.TabIndex = 2;
            this.buttonRemoveFile.Text = "Remove";
            this.buttonRemoveFile.UseVisualStyleBackColor = true;
            this.buttonRemoveFile.Click += new System.EventHandler(this.buttonRemoveFile_Click);
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFile.Location = new System.Drawing.Point(632, 19);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(73, 23);
            this.buttonAddFile.TabIndex = 1;
            this.buttonAddFile.Text = "Add...";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // listViewInputFiles
            // 
            this.listViewInputFiles.AllowDrop = true;
            this.listViewInputFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewInputFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName});
            this.listViewInputFiles.FullRowSelect = true;
            this.listViewInputFiles.HideSelection = false;
            this.listViewInputFiles.Location = new System.Drawing.Point(6, 18);
            this.listViewInputFiles.Name = "listViewInputFiles";
            this.listViewInputFiles.Size = new System.Drawing.Size(620, 136);
            this.listViewInputFiles.TabIndex = 0;
            this.listViewInputFiles.UseCompatibleStateImageBehavior = false;
            this.listViewInputFiles.View = System.Windows.Forms.View.Details;
            this.listViewInputFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewInputFiles_DragDrop);
            this.listViewInputFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewInputFiles_DragEnter);
            this.listViewInputFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewInputFiles_KeyDown);
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "File name";
            this.columnHeaderFileName.Width = 455;
            // 
            // labelFC
            // 
            this.labelFC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFC.ForeColor = System.Drawing.Color.Gray;
            this.labelFC.Location = new System.Drawing.Point(256, 502);
            this.labelFC.Name = "labelFC";
            this.labelFC.Size = new System.Drawing.Size(120, 17);
            this.labelFC.TabIndex = 19;
            this.labelFC.Text = "labelFC";
            this.labelFC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelElapsed
            // 
            this.labelElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelElapsed.Location = new System.Drawing.Point(215, 468);
            this.labelElapsed.Name = "labelElapsed";
            this.labelElapsed.Size = new System.Drawing.Size(152, 13);
            this.labelElapsed.TabIndex = 22;
            this.labelElapsed.Text = "labelElapsed";
            this.labelElapsed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // contextMenuStripWhisperAdvanced
            // 
            this.contextMenuStripWhisperAdvanced.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runOnlyPostProcessingToolStripMenuItem,
            this.toolStripSeparatorRunOnlyPostprocessing,
            this.setCPPConstmeModelsFolderToolStripMenuItem,
            this.removeTemporaryFilesToolStripMenuItem,
            this.downloadNvidiaCudaForCPPCuBLASToolStripMenuItem,
            this.showWhisperlogtxtToolStripMenuItem});
            this.contextMenuStripWhisperAdvanced.Name = "contextMenuStripWhisperAdvanced";
            this.contextMenuStripWhisperAdvanced.Size = new System.Drawing.Size(284, 120);
            // 
            // runOnlyPostProcessingToolStripMenuItem
            // 
            this.runOnlyPostProcessingToolStripMenuItem.Name = "runOnlyPostProcessingToolStripMenuItem";
            this.runOnlyPostProcessingToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.runOnlyPostProcessingToolStripMenuItem.Text = "Run only post processing";
            this.runOnlyPostProcessingToolStripMenuItem.Click += new System.EventHandler(this.runOnlyPostProcessingToolStripMenuItem_Click);
            // 
            // toolStripSeparatorRunOnlyPostprocessing
            // 
            this.toolStripSeparatorRunOnlyPostprocessing.Name = "toolStripSeparatorRunOnlyPostprocessing";
            this.toolStripSeparatorRunOnlyPostprocessing.Size = new System.Drawing.Size(280, 6);
            // 
            // setCPPConstmeModelsFolderToolStripMenuItem
            // 
            this.setCPPConstmeModelsFolderToolStripMenuItem.Name = "setCPPConstmeModelsFolderToolStripMenuItem";
            this.setCPPConstmeModelsFolderToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.setCPPConstmeModelsFolderToolStripMenuItem.Text = "Set CPP/Const-me models folder...";
            // 
            // removeTemporaryFilesToolStripMenuItem
            // 
            this.removeTemporaryFilesToolStripMenuItem.Name = "removeTemporaryFilesToolStripMenuItem";
            this.removeTemporaryFilesToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.removeTemporaryFilesToolStripMenuItem.Text = "Remove temporary files";
            this.removeTemporaryFilesToolStripMenuItem.Click += new System.EventHandler(this.removeTemporaryFilesToolStripMenuItem_Click);
            // 
            // downloadNvidiaCudaForCPPCuBLASToolStripMenuItem
            // 
            this.downloadNvidiaCudaForCPPCuBLASToolStripMenuItem.Name = "downloadNvidiaCudaForCPPCuBLASToolStripMenuItem";
            this.downloadNvidiaCudaForCPPCuBLASToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.downloadNvidiaCudaForCPPCuBLASToolStripMenuItem.Text = "Download Nvidia cuda for Whisper CPP";
            this.downloadNvidiaCudaForCPPCuBLASToolStripMenuItem.Click += new System.EventHandler(this.downloadNvidiaCudaForCPPCuBLASToolStripMenuItem_Click);
            // 
            // showWhisperlogtxtToolStripMenuItem
            // 
            this.showWhisperlogtxtToolStripMenuItem.Name = "showWhisperlogtxtToolStripMenuItem";
            this.showWhisperlogtxtToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.showWhisperlogtxtToolStripMenuItem.Text = "Show whisper_log.txt";
            this.showWhisperlogtxtToolStripMenuItem.Click += new System.EventHandler(this.ShowWhisperLogFileToolStripMenuItem_Click);
            // 
            // checkBoxAutoAdjustTimings
            // 
            this.checkBoxAutoAdjustTimings.AutoSize = true;
            this.checkBoxAutoAdjustTimings.Location = new System.Drawing.Point(15, 176);
            this.checkBoxAutoAdjustTimings.Name = "checkBoxAutoAdjustTimings";
            this.checkBoxAutoAdjustTimings.Size = new System.Drawing.Size(114, 17);
            this.checkBoxAutoAdjustTimings.TabIndex = 21;
            this.checkBoxAutoAdjustTimings.Text = "Auto adjust timings";
            this.checkBoxAutoAdjustTimings.UseVisualStyleBackColor = true;
            // 
            // labelAdvanced
            // 
            this.labelAdvanced.AutoSize = true;
            this.labelAdvanced.Location = new System.Drawing.Point(174, 238);
            this.labelAdvanced.Name = "labelAdvanced";
            this.labelAdvanced.Size = new System.Drawing.Size(65, 13);
            this.labelAdvanced.TabIndex = 29;
            this.labelAdvanced.Text = "Advanced...";
            // 
            // linkLabelPostProcessingConfigure
            // 
            this.linkLabelPostProcessingConfigure.AutoSize = true;
            this.linkLabelPostProcessingConfigure.Location = new System.Drawing.Point(328, 199);
            this.linkLabelPostProcessingConfigure.Name = "linkLabelPostProcessingConfigure";
            this.linkLabelPostProcessingConfigure.Size = new System.Drawing.Size(45, 13);
            this.linkLabelPostProcessingConfigure.TabIndex = 5;
            this.linkLabelPostProcessingConfigure.TabStop = true;
            this.linkLabelPostProcessingConfigure.Text = "Settings";
            this.linkLabelPostProcessingConfigure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPostProcessingConfigure_LinkClicked);
            // 
            // WhisperAudioToText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 524);
            this.Controls.Add(this.linkLabelPostProcessingConfigure);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelAdvanced);
            this.Controls.Add(this.labelElapsed);
            this.Controls.Add(this.checkBoxAutoAdjustTimings);
            this.Controls.Add(this.groupBoxInputFiles);
            this.Controls.Add(this.buttonBatchMode);
            this.Controls.Add(this.checkBoxUsePostProcessing);
            this.Controls.Add(this.groupBoxModels);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.labelFC);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(575, 250);
            this.Name = "WhisperAudioToText";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Whisper API";
            this.Activated += new System.EventHandler(this.WhisperAudioToText_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioToText_FormClosing);
            this.Load += new System.EventHandler(this.AudioToText_Load);
            this.Shown += new System.EventHandler(this.AudioToText_Shown);
            this.ResizeEnd += new System.EventHandler(this.AudioToText_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AudioToText_KeyDown);
            this.groupBoxModels.ResumeLayout(false);
            this.groupBoxModels.PerformLayout();
            this.groupBoxInputFiles.ResumeLayout(false);
            this.contextMenuStripWhisperAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.GroupBox groupBoxModels;
        private System.Windows.Forms.Label labelModel;
        private Nikse.SubtitleEdit.Controls.NikseComboBox comboBoxModels;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxUsePostProcessing;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonBatchMode;
        private System.Windows.Forms.GroupBox groupBoxInputFiles;
        private System.Windows.Forms.ListView listViewInputFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRemoveFile;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Label labelFC;
        private System.Windows.Forms.Label labelChooseLanguage;
        private Nikse.SubtitleEdit.Controls.NikseComboBox comboBoxLanguages;
        private System.Windows.Forms.Label labelElapsed;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWhisperAdvanced;
        private System.Windows.Forms.ToolStripMenuItem removeTemporaryFilesToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxAutoAdjustTimings;
        private System.Windows.Forms.ToolStripMenuItem setCPPConstmeModelsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runOnlyPostProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorRunOnlyPostprocessing;
        private System.Windows.Forms.Label labelAdvanced;
        private System.Windows.Forms.ToolStripMenuItem showWhisperlogtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadNvidiaCudaForCPPCuBLASToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelPostProcessingConfigure;
    }
}
