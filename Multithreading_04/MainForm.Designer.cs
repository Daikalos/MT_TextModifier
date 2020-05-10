namespace Multithreading_04
{
    partial class MainForm
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
            this.TextControl = new System.Windows.Forms.TabControl();
            this.SourcePage = new System.Windows.Forms.TabPage();
            this.SourceTextBox = new System.Windows.Forms.RichTextBox();
            this.DestinationPage = new System.Windows.Forms.TabPage();
            this.DestinationTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NbrOfReplacementsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NotifyUserCheck = new System.Windows.Forms.CheckBox();
            this.ReplaceTextBox = new System.Windows.Forms.TextBox();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.CopyToDestButton = new System.Windows.Forms.Button();
            this.ClearDestButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.NextMatchButton = new System.Windows.Forms.Button();
            this.TextControl.SuspendLayout();
            this.SourcePage.SuspendLayout();
            this.DestinationPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextControl
            // 
            this.TextControl.Controls.Add(this.SourcePage);
            this.TextControl.Controls.Add(this.DestinationPage);
            this.TextControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextControl.Location = new System.Drawing.Point(12, 179);
            this.TextControl.Name = "TextControl";
            this.TextControl.SelectedIndex = 0;
            this.TextControl.Size = new System.Drawing.Size(613, 398);
            this.TextControl.TabIndex = 0;
            // 
            // SourcePage
            // 
            this.SourcePage.BackColor = System.Drawing.Color.Transparent;
            this.SourcePage.Controls.Add(this.SourceTextBox);
            this.SourcePage.Location = new System.Drawing.Point(4, 25);
            this.SourcePage.Name = "SourcePage";
            this.SourcePage.Padding = new System.Windows.Forms.Padding(3);
            this.SourcePage.Size = new System.Drawing.Size(605, 369);
            this.SourcePage.TabIndex = 0;
            this.SourcePage.Text = "Source";
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceTextBox.Location = new System.Drawing.Point(6, 6);
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.Size = new System.Drawing.Size(593, 357);
            this.SourceTextBox.TabIndex = 0;
            this.SourceTextBox.Text = "";
            // 
            // DestinationPage
            // 
            this.DestinationPage.Controls.Add(this.DestinationTextBox);
            this.DestinationPage.Location = new System.Drawing.Point(4, 25);
            this.DestinationPage.Name = "DestinationPage";
            this.DestinationPage.Padding = new System.Windows.Forms.Padding(3);
            this.DestinationPage.Size = new System.Drawing.Size(605, 369);
            this.DestinationPage.TabIndex = 1;
            this.DestinationPage.Text = "Destination";
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationTextBox.Location = new System.Drawing.Point(6, 6);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.ReadOnly = true;
            this.DestinationTextBox.Size = new System.Drawing.Size(593, 357);
            this.DestinationTextBox.TabIndex = 1;
            this.DestinationTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Controls.Add(this.NextMatchButton);
            this.groupBox1.Controls.Add(this.NbrOfReplacementsLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NotifyUserCheck);
            this.groupBox1.Controls.Add(this.ReplaceTextBox);
            this.groupBox1.Controls.Add(this.FindTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find and Replace";
            // 
            // NbrOfReplacementsLabel
            // 
            this.NbrOfReplacementsLabel.AutoSize = true;
            this.NbrOfReplacementsLabel.Location = new System.Drawing.Point(219, 117);
            this.NbrOfReplacementsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.NbrOfReplacementsLabel.Name = "NbrOfReplacementsLabel";
            this.NbrOfReplacementsLabel.Size = new System.Drawing.Size(13, 13);
            this.NbrOfReplacementsLabel.TabIndex = 6;
            this.NbrOfReplacementsLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "No replacements:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Replace with:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find:";
            // 
            // NotifyUserCheck
            // 
            this.NotifyUserCheck.AutoSize = true;
            this.NotifyUserCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotifyUserCheck.Location = new System.Drawing.Point(105, 93);
            this.NotifyUserCheck.Name = "NotifyUserCheck";
            this.NotifyUserCheck.Size = new System.Drawing.Size(184, 20);
            this.NotifyUserCheck.TabIndex = 2;
            this.NotifyUserCheck.Text = "Notify user on every match";
            this.NotifyUserCheck.UseVisualStyleBackColor = true;
            this.NotifyUserCheck.CheckedChanged += new System.EventHandler(this.NotifyUserCheck_CheckedChanged);
            // 
            // ReplaceTextBox
            // 
            this.ReplaceTextBox.Location = new System.Drawing.Point(105, 67);
            this.ReplaceTextBox.Name = "ReplaceTextBox";
            this.ReplaceTextBox.Size = new System.Drawing.Size(301, 20);
            this.ReplaceTextBox.TabIndex = 1;
            // 
            // FindTextBox
            // 
            this.FindTextBox.Location = new System.Drawing.Point(105, 40);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(301, 20);
            this.FindTextBox.TabIndex = 0;
            // 
            // CopyToDestButton
            // 
            this.CopyToDestButton.Location = new System.Drawing.Point(430, 107);
            this.CopyToDestButton.Name = "CopyToDestButton";
            this.CopyToDestButton.Size = new System.Drawing.Size(195, 30);
            this.CopyToDestButton.TabIndex = 2;
            this.CopyToDestButton.Text = "Copy to Destination";
            this.CopyToDestButton.UseVisualStyleBackColor = true;
            this.CopyToDestButton.Click += new System.EventHandler(this.CopyToDestButton_Click);
            // 
            // ClearDestButton
            // 
            this.ClearDestButton.Enabled = false;
            this.ClearDestButton.Location = new System.Drawing.Point(430, 143);
            this.ClearDestButton.Name = "ClearDestButton";
            this.ClearDestButton.Size = new System.Drawing.Size(195, 30);
            this.ClearDestButton.TabIndex = 3;
            this.ClearDestButton.Text = "Clear dest. and remove marks";
            this.ClearDestButton.UseVisualStyleBackColor = true;
            this.ClearDestButton.Click += new System.EventHandler(this.ClearDestButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileSelect});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(637, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileSelect
            // 
            this.FileSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.SaveFile,
            this.toolStripSeparator1,
            this.FileExit});
            this.FileSelect.Name = "FileSelect";
            this.FileSelect.Size = new System.Drawing.Size(37, 20);
            this.FileSelect.Text = "File";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(198, 22);
            this.OpenFile.Text = "Open Source File";
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(198, 22);
            this.SaveFile.Text = "Save Destination File As";
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.Size = new System.Drawing.Size(198, 22);
            this.FileExit.Text = "Exit";
            this.FileExit.Click += new System.EventHandler(this.FileExit_Click);
            // 
            // NextMatchButton
            // 
            this.NextMatchButton.Enabled = false;
            this.NextMatchButton.Location = new System.Drawing.Point(298, 93);
            this.NextMatchButton.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.NextMatchButton.Name = "NextMatchButton";
            this.NextMatchButton.Size = new System.Drawing.Size(108, 36);
            this.NextMatchButton.TabIndex = 7;
            this.NextMatchButton.Text = "Go to next match";
            this.NextMatchButton.UseVisualStyleBackColor = true;
            this.NextMatchButton.Click += new System.EventHandler(this.NextMatchButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(637, 589);
            this.Controls.Add(this.ClearDestButton);
            this.Controls.Add(this.CopyToDestButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextControl);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Multithreading_04";
            this.TextControl.ResumeLayout(false);
            this.SourcePage.ResumeLayout(false);
            this.DestinationPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TextControl;
        private System.Windows.Forms.TabPage SourcePage;
        private System.Windows.Forms.TabPage DestinationPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label NbrOfReplacementsLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox NotifyUserCheck;
        private System.Windows.Forms.TextBox ReplaceTextBox;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.Button CopyToDestButton;
        private System.Windows.Forms.Button ClearDestButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileSelect;
        private System.Windows.Forms.RichTextBox SourceTextBox;
        private System.Windows.Forms.RichTextBox DestinationTextBox;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem FileExit;
        private System.Windows.Forms.Button NextMatchButton;
    }
}

