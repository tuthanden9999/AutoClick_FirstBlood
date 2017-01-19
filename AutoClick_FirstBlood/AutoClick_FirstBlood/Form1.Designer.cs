namespace AutoClick_FirstBlood
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.handIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // handIcon
            // 
            this.handIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("handIcon.Icon")));
            this.handIcon.Text = "handIcon";
            this.handIcon.Visible = true;
            this.handIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.handIcon_MouseClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(96, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(145, 41);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start (F6)";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(283, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(145, 41);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop (F6)";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(416, 76);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(66, 28);
            this.helpButton.TabIndex = 11;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 123);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoClick_FirstBood";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon handIcon;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button helpButton;
    }
}

