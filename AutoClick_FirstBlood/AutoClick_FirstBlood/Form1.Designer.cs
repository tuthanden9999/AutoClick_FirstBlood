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
            this.label1 = new System.Windows.Forms.Label();
            this.handIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.milisecondTextbox = new System.Windows.Forms.TextBox();
            this.secondTextbox = new System.Windows.Forms.TextBox();
            this.minTextbox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.clickTypeCombobox = new System.Windows.Forms.ComboBox();
            this.mouseCombobox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.timesCombobox = new System.Windows.Forms.ComboBox();
            this.repeat2Radio = new System.Windows.Forms.RadioButton();
            this.repeat1Radio = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.pickPosCheckbox = new System.Windows.Forms.CheckBox();
            this.posListTextbox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.clearPosButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Click interval";
            // 
            // handIcon
            // 
            this.handIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("handIcon.Icon")));
            this.handIcon.Text = "handIcon";
            this.handIcon.Visible = true;
            this.handIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.handIcon_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.milisecondTextbox);
            this.panel1.Controls.Add(this.secondTextbox);
            this.panel1.Controls.Add(this.minTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(51, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 87);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "miliseconds";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "seconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "mins";
            // 
            // milisecondTextbox
            // 
            this.milisecondTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.milisecondTextbox.Location = new System.Drawing.Point(285, 37);
            this.milisecondTextbox.Name = "milisecondTextbox";
            this.milisecondTextbox.Size = new System.Drawing.Size(64, 26);
            this.milisecondTextbox.TabIndex = 1;
            this.milisecondTextbox.Text = "0";
            this.milisecondTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // secondTextbox
            // 
            this.secondTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondTextbox.Location = new System.Drawing.Point(133, 37);
            this.secondTextbox.Name = "secondTextbox";
            this.secondTextbox.Size = new System.Drawing.Size(64, 26);
            this.secondTextbox.TabIndex = 2;
            this.secondTextbox.Text = "1";
            this.secondTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minTextbox
            // 
            this.minTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTextbox.Location = new System.Drawing.Point(6, 37);
            this.minTextbox.Name = "minTextbox";
            this.minTextbox.Size = new System.Drawing.Size(64, 26);
            this.minTextbox.TabIndex = 3;
            this.minTextbox.Text = "0";
            this.minTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.clickTypeCombobox);
            this.panel2.Controls.Add(this.mouseCombobox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(51, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 110);
            this.panel2.TabIndex = 2;
            // 
            // clickTypeCombobox
            // 
            this.clickTypeCombobox.FormattingEnabled = true;
            this.clickTypeCombobox.Items.AddRange(new object[] {
            "Single",
            "Double"});
            this.clickTypeCombobox.Location = new System.Drawing.Point(79, 73);
            this.clickTypeCombobox.Name = "clickTypeCombobox";
            this.clickTypeCombobox.Size = new System.Drawing.Size(103, 21);
            this.clickTypeCombobox.TabIndex = 7;
            // 
            // mouseCombobox
            // 
            this.mouseCombobox.DisplayMember = "(none)";
            this.mouseCombobox.FormattingEnabled = true;
            this.mouseCombobox.Items.AddRange(new object[] {
            "Left",
            "Right"});
            this.mouseCombobox.Location = new System.Drawing.Point(79, 36);
            this.mouseCombobox.Name = "mouseCombobox";
            this.mouseCombobox.Size = new System.Drawing.Size(103, 21);
            this.mouseCombobox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Click type : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mouse : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Click options";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.timesCombobox);
            this.panel3.Controls.Add(this.repeat2Radio);
            this.panel3.Controls.Add(this.repeat1Radio);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(292, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 110);
            this.panel3.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "times";
            // 
            // timesCombobox
            // 
            this.timesCombobox.FormattingEnabled = true;
            this.timesCombobox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "100",
            "1000"});
            this.timesCombobox.Location = new System.Drawing.Point(71, 36);
            this.timesCombobox.Name = "timesCombobox";
            this.timesCombobox.Size = new System.Drawing.Size(58, 21);
            this.timesCombobox.TabIndex = 3;
            // 
            // repeat2Radio
            // 
            this.repeat2Radio.AutoSize = true;
            this.repeat2Radio.Location = new System.Drawing.Point(6, 74);
            this.repeat2Radio.Name = "repeat2Radio";
            this.repeat2Radio.Size = new System.Drawing.Size(123, 17);
            this.repeat2Radio.TabIndex = 2;
            this.repeat2Radio.TabStop = true;
            this.repeat2Radio.Text = "Repeat until stopped";
            this.repeat2Radio.UseVisualStyleBackColor = true;
            this.repeat2Radio.Click += new System.EventHandler(this.repeat2Radio_Click);
            // 
            // repeat1Radio
            // 
            this.repeat1Radio.AutoSize = true;
            this.repeat1Radio.Location = new System.Drawing.Point(5, 37);
            this.repeat1Radio.Name = "repeat1Radio";
            this.repeat1Radio.Size = new System.Drawing.Size(60, 17);
            this.repeat1Radio.TabIndex = 1;
            this.repeat1Radio.TabStop = true;
            this.repeat1Radio.Text = "Repeat";
            this.repeat1Radio.UseVisualStyleBackColor = true;
            this.repeat1Radio.Click += new System.EventHandler(this.repeat1Radio_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Click repeat";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(105, 370);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(145, 41);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start (F4)";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(292, 370);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(145, 41);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop (F4)";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(425, 434);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(66, 28);
            this.helpButton.TabIndex = 11;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // pickPosCheckbox
            // 
            this.pickPosCheckbox.AutoSize = true;
            this.pickPosCheckbox.Location = new System.Drawing.Point(105, 247);
            this.pickPosCheckbox.Name = "pickPosCheckbox";
            this.pickPosCheckbox.Size = new System.Drawing.Size(86, 17);
            this.pickPosCheckbox.TabIndex = 13;
            this.pickPosCheckbox.Text = "Pick position";
            this.pickPosCheckbox.UseVisualStyleBackColor = true;
            // 
            // posListTextbox
            // 
            this.posListTextbox.Location = new System.Drawing.Point(220, 245);
            this.posListTextbox.Multiline = true;
            this.posListTextbox.Name = "posListTextbox";
            this.posListTextbox.ReadOnly = true;
            this.posListTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.posListTextbox.Size = new System.Drawing.Size(127, 63);
            this.posListTextbox.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(105, 270);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(86, 40);
            this.textBox2.TabIndex = 20;
            this.textBox2.Text = "Press F1 to record positions";
            // 
            // clearPosButton
            // 
            this.clearPosButton.Location = new System.Drawing.Point(362, 247);
            this.clearPosButton.Name = "clearPosButton";
            this.clearPosButton.Size = new System.Drawing.Size(75, 23);
            this.clearPosButton.TabIndex = 21;
            this.clearPosButton.Text = "Clear";
            this.clearPosButton.UseVisualStyleBackColor = true;
            this.clearPosButton.Click += new System.EventHandler(this.clearPosButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 474);
            this.Controls.Add(this.clearPosButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.posListTextbox);
            this.Controls.Add(this.pickPosCheckbox);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoClick_FirstBood";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon handIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox milisecondTextbox;
        private System.Windows.Forms.TextBox secondTextbox;
        private System.Windows.Forms.TextBox minTextbox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox clickTypeCombobox;
        private System.Windows.Forms.ComboBox mouseCombobox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton repeat2Radio;
        private System.Windows.Forms.RadioButton repeat1Radio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox timesCombobox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.CheckBox pickPosCheckbox;
        private System.Windows.Forms.TextBox posListTextbox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button clearPosButton;
    }
}

