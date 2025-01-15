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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripWhisperAdvanced = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setCPPConstmeModelsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTemporaryFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStripWhisperAdvanced.SuspendLayout();
            this.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazirmatn", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Calling API endpoint...";
            // 
            // WhisperAudioToTextSelectedLines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 67);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "WhisperAudioToTextSelectedLines";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Activated += new System.EventHandler(this.WhisperAudioToTextSelectedLines_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioToText_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AudioToText_KeyDown);
            this.contextMenuStripWhisperAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripWhisperAdvanced;
        private System.Windows.Forms.ToolStripMenuItem removeTemporaryFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCPPConstmeModelsFolderToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}
