namespace TimeTracker2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblListModes = new System.Windows.Forms.Label();
            this.btnResetCurrMode = new System.Windows.Forms.Button();
            this.btnResetAllModes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "TimeTracer v2, ctrl+click to bring up the form";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // lblListModes
            // 
            this.lblListModes.AutoSize = true;
            this.lblListModes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblListModes.Location = new System.Drawing.Point(3, 3);
            this.lblListModes.Name = "lblListModes";
            this.lblListModes.Size = new System.Drawing.Size(73, 15);
            this.lblListModes.TabIndex = 0;
            this.lblListModes.Text = "Lists modes";
            // 
            // btnResetCurrMode
            // 
            this.btnResetCurrMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetCurrMode.Enabled = false;
            this.btnResetCurrMode.Location = new System.Drawing.Point(170, 6);
            this.btnResetCurrMode.Name = "btnResetCurrMode";
            this.btnResetCurrMode.Size = new System.Drawing.Size(112, 24);
            this.btnResetCurrMode.TabIndex = 1;
            this.btnResetCurrMode.Text = "Reset current mode";
            this.btnResetCurrMode.UseVisualStyleBackColor = true;
            this.btnResetCurrMode.Click += new System.EventHandler(this.btnResetCurrMode_Click);
            // 
            // btnResetAllModes
            // 
            this.btnResetAllModes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetAllModes.Location = new System.Drawing.Point(170, 36);
            this.btnResetAllModes.Name = "btnResetAllModes";
            this.btnResetAllModes.Size = new System.Drawing.Size(112, 24);
            this.btnResetAllModes.TabIndex = 1;
            this.btnResetAllModes.Text = "Reset all modes";
            this.btnResetAllModes.UseVisualStyleBackColor = true;
            this.btnResetAllModes.Click += new System.EventHandler(this.btnResetAllModes_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 86);
            this.Controls.Add(this.btnResetAllModes);
            this.Controls.Add(this.btnResetCurrMode);
            this.Controls.Add(this.lblListModes);
            this.Name = "MainForm";
            this.Text = "Time Tracker v2";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Label lblListModes;
        private System.Windows.Forms.Button btnResetCurrMode;
        private System.Windows.Forms.Button btnResetAllModes;
    }
}

