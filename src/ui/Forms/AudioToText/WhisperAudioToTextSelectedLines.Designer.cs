namespace Nikse.SubtitleEdit.Forms.AudioToText
{
    sealed partial class WhisperAudioToTextSelectedLines
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
            this.groupBoxModels = new System.Windows.Forms.GroupBox();
            this.labelChooseLanguage = new System.Windows.Forms.Label();
            this.comboBoxLanguages = new Nikse.SubtitleEdit.Controls.NikseComboBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.comboBoxModels = new Nikse.SubtitleEdit.Controls.NikseComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripWhisperAdvanced = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setCPPConstmeModelsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTemporaryFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxModels.SuspendLayout();
            this.contextMenuStripWhisperAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(623, 168);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "C&ancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGenerate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGenerate.Location = new System.Drawing.Point(492, 168);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(125, 23);
            this.buttonGenerate.TabIndex = 5;
            this.buttonGenerate.Text = "&Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // groupBoxModels
            // 
            this.groupBoxModels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxModels.Controls.Add(this.labelChooseLanguage);
            this.groupBoxModels.Controls.Add(this.comboBoxLanguages);
            this.groupBoxModels.Controls.Add(this.labelModel);
            this.groupBoxModels.Controls.Add(this.comboBoxModels);
            this.groupBoxModels.Location = new System.Drawing.Point(15, 60);
            this.groupBoxModels.Name = "groupBoxModels";
            this.groupBoxModels.Size = new System.Drawing.Size(682, 82);
            this.groupBoxModels.TabIndex = 1;
            this.groupBoxModels.TabStop = false;
            this.groupBoxModels.Text = "Models";
            // 
            // labelChooseLanguage
            // 
            this.labelChooseLanguage.AutoSize = true;
            this.labelChooseLanguage.Location = new System.Drawing.Point(3, 21);
            this.labelChooseLanguage.Name = "labelChooseLanguage";
            this.labelChooseLanguage.Size = new System.Drawing.Size(90, 13);
            this.labelChooseLanguage.TabIndex = 6;
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
            this.comboBoxLanguages.DropDownWidth = 194;
            this.comboBoxLanguages.FormattingEnabled = true;
            this.comboBoxLanguages.Location = new System.Drawing.Point(6, 41);
            this.comboBoxLanguages.MaxLength = 32767;
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.SelectedIndex = -1;
            this.comboBoxLanguages.SelectedItem = null;
            this.comboBoxLanguages.SelectedText = "";
            this.comboBoxLanguages.Size = new System.Drawing.Size(194, 24);
            this.comboBoxLanguages.TabIndex = 7;
            this.comboBoxLanguages.UsePopupWindow = false;
            this.comboBoxLanguages.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguages_SelectedIndexChanged);
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(254, 21);
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
            this.comboBoxModels.Location = new System.Drawing.Point(257, 41);
            this.comboBoxModels.MaxLength = 32767;
            this.comboBoxModels.Name = "comboBoxModels";
            this.comboBoxModels.SelectedIndex = -1;
            this.comboBoxModels.SelectedItem = null;
            this.comboBoxModels.SelectedText = "";
            this.comboBoxModels.Size = new System.Drawing.Size(240, 24);
            this.comboBoxModels.TabIndex = 0;
            this.comboBoxModels.UsePopupWindow = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStripWhisperAdvanced
            // 
            this.contextMenuStripWhisperAdvanced.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setCPPConstmeModelsFolderToolStripMenuItem,
            this.removeTemporaryFilesToolStripMenuItem});
            this.contextMenuStripWhisperAdvanced.Name = "contextMenuStripWhisperAdvanced";
            this.contextMenuStripWhisperAdvanced.Size = new System.Drawing.Size(259, 48);
            // 
            // setCPPConstmeModelsFolderToolStripMenuItem
            // 
            this.setCPPConstmeModelsFolderToolStripMenuItem.Name = "setCPPConstmeModelsFolderToolStripMenuItem";
            this.setCPPConstmeModelsFolderToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.setCPPConstmeModelsFolderToolStripMenuItem.Text = "Set CPP/Const-me models folder...";
            // 
            // removeTemporaryFilesToolStripMenuItem
            // 
            this.removeTemporaryFilesToolStripMenuItem.Name = "removeTemporaryFilesToolStripMenuItem";
            this.removeTemporaryFilesToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.removeTemporaryFilesToolStripMenuItem.Text = "Remove temporary files";
            this.removeTemporaryFilesToolStripMenuItem.Click += new System.EventHandler(this.removeTemporaryFilesToolStripMenuItem_Click);
            // 
            // WhisperAudioToTextSelectedLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 203);
            this.Controls.Add(this.groupBoxModels);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGenerate);
            this.KeyPreview = true;
            this.Name = "WhisperAudioToTextSelectedLines";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Whisperer";
            this.Activated += new System.EventHandler(this.WhisperAudioToTextSelectedLines_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioToText_FormClosing);
            this.Shown += new System.EventHandler(this.AudioToTextSelectedLines_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AudioToText_KeyDown);
            this.groupBoxModels.ResumeLayout(false);
            this.groupBoxModels.PerformLayout();
            this.contextMenuStripWhisperAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.GroupBox groupBoxModels;
        private System.Windows.Forms.Label labelModel;
        private Nikse.SubtitleEdit.Controls.NikseComboBox comboBoxModels;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelChooseLanguage;
        private Nikse.SubtitleEdit.Controls.NikseComboBox comboBoxLanguages;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWhisperAdvanced;
        private System.Windows.Forms.ToolStripMenuItem removeTemporaryFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCPPConstmeModelsFolderToolStripMenuItem;
    }
}
