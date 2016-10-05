namespace ProxyManager.Forms
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
            this.components = new System.ComponentModel.Container();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpScraping = new System.Windows.Forms.TabPage();
            this.gbScraped = new System.Windows.Forms.GroupBox();
            this.lbScraped = new System.Windows.Forms.ListBox();
            this.btnStartScraping = new System.Windows.Forms.Button();
            this.btnStopScraping = new System.Windows.Forms.Button();
            this.tpChecking = new System.Windows.Forms.TabPage();
            this.gbChecked = new System.Windows.Forms.GroupBox();
            this.lbChecked = new System.Windows.Forms.ListBox();
            this.btnStartChecking = new System.Windows.Forms.Button();
            this.btnStopChecking = new System.Windows.Forms.Button();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.lblWorking = new System.Windows.Forms.Label();
            this.cmdExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain.SuspendLayout();
            this.tpScraping.SuspendLayout();
            this.gbScraped.SuspendLayout();
            this.tpChecking.SuspendLayout();
            this.gbChecked.SuspendLayout();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            this.cmdExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpScraping);
            this.tcMain.Controls.Add(this.tpChecking);
            this.tcMain.Controls.Add(this.tpSettings);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(484, 366);
            this.tcMain.TabIndex = 0;
            // 
            // tpScraping
            // 
            this.tpScraping.Controls.Add(this.gbScraped);
            this.tpScraping.Controls.Add(this.btnStartScraping);
            this.tpScraping.Controls.Add(this.btnStopScraping);
            this.tpScraping.Location = new System.Drawing.Point(4, 22);
            this.tpScraping.Name = "tpScraping";
            this.tpScraping.Size = new System.Drawing.Size(476, 340);
            this.tpScraping.TabIndex = 0;
            this.tpScraping.Text = "Scraping";
            this.tpScraping.UseVisualStyleBackColor = true;
            // 
            // gbScraped
            // 
            this.gbScraped.Controls.Add(this.lbScraped);
            this.gbScraped.Location = new System.Drawing.Point(3, 3);
            this.gbScraped.Name = "gbScraped";
            this.gbScraped.Size = new System.Drawing.Size(470, 303);
            this.gbScraped.TabIndex = 3;
            this.gbScraped.TabStop = false;
            this.gbScraped.Text = "Scraped [0]";
            // 
            // lbScraped
            // 
            this.lbScraped.FormattingEnabled = true;
            this.lbScraped.Location = new System.Drawing.Point(6, 20);
            this.lbScraped.Name = "lbScraped";
            this.lbScraped.Size = new System.Drawing.Size(458, 277);
            this.lbScraped.TabIndex = 0;
            // 
            // btnStartScraping
            // 
            this.btnStartScraping.Location = new System.Drawing.Point(317, 312);
            this.btnStartScraping.Name = "btnStartScraping";
            this.btnStartScraping.Size = new System.Drawing.Size(75, 25);
            this.btnStartScraping.TabIndex = 2;
            this.btnStartScraping.Text = "Start";
            this.btnStartScraping.UseVisualStyleBackColor = true;
            this.btnStartScraping.Click += new System.EventHandler(this.btnStartScraping_Click);
            // 
            // btnStopScraping
            // 
            this.btnStopScraping.Enabled = false;
            this.btnStopScraping.Location = new System.Drawing.Point(398, 312);
            this.btnStopScraping.Name = "btnStopScraping";
            this.btnStopScraping.Size = new System.Drawing.Size(75, 25);
            this.btnStopScraping.TabIndex = 1;
            this.btnStopScraping.Text = "Stop";
            this.btnStopScraping.UseVisualStyleBackColor = true;
            this.btnStopScraping.Click += new System.EventHandler(this.btnStopScraping_Click);
            // 
            // tpChecking
            // 
            this.tpChecking.Controls.Add(this.lblWorking);
            this.tpChecking.Controls.Add(this.gbChecked);
            this.tpChecking.Controls.Add(this.btnStartChecking);
            this.tpChecking.Controls.Add(this.btnStopChecking);
            this.tpChecking.Location = new System.Drawing.Point(4, 22);
            this.tpChecking.Name = "tpChecking";
            this.tpChecking.Size = new System.Drawing.Size(476, 340);
            this.tpChecking.TabIndex = 1;
            this.tpChecking.Text = "Checking";
            this.tpChecking.UseVisualStyleBackColor = true;
            // 
            // gbChecked
            // 
            this.gbChecked.Controls.Add(this.lbChecked);
            this.gbChecked.Location = new System.Drawing.Point(3, 3);
            this.gbChecked.Name = "gbChecked";
            this.gbChecked.Size = new System.Drawing.Size(470, 303);
            this.gbChecked.TabIndex = 5;
            this.gbChecked.TabStop = false;
            this.gbChecked.Text = "Checked [0/0]";
            // 
            // lbChecked
            // 
            this.lbChecked.ContextMenuStrip = this.cmdExport;
            this.lbChecked.FormattingEnabled = true;
            this.lbChecked.Location = new System.Drawing.Point(6, 20);
            this.lbChecked.Name = "lbChecked";
            this.lbChecked.Size = new System.Drawing.Size(458, 277);
            this.lbChecked.TabIndex = 0;
            // 
            // btnStartChecking
            // 
            this.btnStartChecking.Location = new System.Drawing.Point(317, 312);
            this.btnStartChecking.Name = "btnStartChecking";
            this.btnStartChecking.Size = new System.Drawing.Size(75, 25);
            this.btnStartChecking.TabIndex = 4;
            this.btnStartChecking.Text = "Start";
            this.btnStartChecking.UseVisualStyleBackColor = true;
            this.btnStartChecking.Click += new System.EventHandler(this.btnStartChecking_Click);
            // 
            // btnStopChecking
            // 
            this.btnStopChecking.Enabled = false;
            this.btnStopChecking.Location = new System.Drawing.Point(398, 312);
            this.btnStopChecking.Name = "btnStopChecking";
            this.btnStopChecking.Size = new System.Drawing.Size(75, 25);
            this.btnStopChecking.TabIndex = 3;
            this.btnStopChecking.Text = "Stop";
            this.btnStopChecking.UseVisualStyleBackColor = true;
            this.btnStopChecking.Click += new System.EventHandler(this.btnStopChecking_Click);
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.btnSave);
            this.tpSettings.Controls.Add(this.btnReset);
            this.tpSettings.Controls.Add(this.nudTimeout);
            this.tpSettings.Controls.Add(this.lblTimeout);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(476, 340);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(398, 312);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(3, 312);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // nudTimeout
            // 
            this.nudTimeout.Location = new System.Drawing.Point(8, 25);
            this.nudTimeout.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudTimeout.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(465, 22);
            this.nudTimeout.TabIndex = 1;
            this.nudTimeout.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Location = new System.Drawing.Point(8, 9);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(74, 13);
            this.lblTimeout.TabIndex = 0;
            this.lblTimeout.Text = "Timeout (ms):";
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.Location = new System.Drawing.Point(8, 312);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(64, 13);
            this.lblWorking.TabIndex = 6;
            this.lblWorking.Text = "Working: 0";
            // 
            // cmdExport
            // 
            this.cmdExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportAllToolStripMenuItem});
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(153, 48);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportAllToolStripMenuItem.Text = "Export All...";
            this.exportAllToolStripMenuItem.Click += new System.EventHandler(this.exportAllToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 366);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy Manager";
            this.tcMain.ResumeLayout(false);
            this.tpScraping.ResumeLayout(false);
            this.gbScraped.ResumeLayout(false);
            this.tpChecking.ResumeLayout(false);
            this.tpChecking.PerformLayout();
            this.gbChecked.ResumeLayout(false);
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            this.cmdExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpScraping;
        private System.Windows.Forms.TabPage tpChecking;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.ListBox lbScraped;
        private System.Windows.Forms.Button btnStartScraping;
        private System.Windows.Forms.Button btnStopScraping;
        private System.Windows.Forms.Button btnStartChecking;
        private System.Windows.Forms.Button btnStopChecking;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox gbScraped;
        private System.Windows.Forms.GroupBox gbChecked;
        private System.Windows.Forms.ListBox lbChecked;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.ContextMenuStrip cmdExport;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
    }
}