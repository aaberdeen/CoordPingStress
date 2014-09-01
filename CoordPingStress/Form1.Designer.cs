namespace CoordPingStress
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.noOfTagsText = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gapText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.burstGapText = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.sequTextBox = new System.Windows.Forms.TextBox();
            this.Sequ = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(149, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(149, 158);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // noOfTagsText
            // 
            this.noOfTagsText.Location = new System.Drawing.Point(149, 68);
            this.noOfTagsText.Name = "noOfTagsText";
            this.noOfTagsText.Size = new System.Drawing.Size(100, 20);
            this.noOfTagsText.TabIndex = 2;
            this.noOfTagsText.Text = "1";
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(276, 39);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(75, 23);
            this.setButton.TabIndex = 3;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Com Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "No of Tags";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inter Packet Gap (ms)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // gapText
            // 
            this.gapText.Location = new System.Drawing.Point(149, 97);
            this.gapText.Name = "gapText";
            this.gapText.Size = new System.Drawing.Size(100, 20);
            this.gapText.TabIndex = 7;
            this.gapText.Text = "400";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Inter Burst Gap (ms)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // burstGapText
            // 
            this.burstGapText.Location = new System.Drawing.Point(149, 127);
            this.burstGapText.Name = "burstGapText";
            this.burstGapText.Size = new System.Drawing.Size(100, 20);
            this.burstGapText.TabIndex = 9;
            this.burstGapText.Text = "10000";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(230, 158);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 10;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // sequTextBox
            // 
            this.sequTextBox.Location = new System.Drawing.Point(149, 187);
            this.sequTextBox.Name = "sequTextBox";
            this.sequTextBox.Size = new System.Drawing.Size(100, 20);
            this.sequTextBox.TabIndex = 11;
            // 
            // Sequ
            // 
            this.Sequ.AutoSize = true;
            this.Sequ.Location = new System.Drawing.Point(99, 194);
            this.Sequ.Name = "Sequ";
            this.Sequ.Size = new System.Drawing.Size(32, 13);
            this.Sequ.TabIndex = 12;
            this.Sequ.Text = "Sequ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 383);
            this.Controls.Add(this.Sequ);
            this.Controls.Add(this.sequTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.burstGapText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gapText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.noOfTagsText);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox noOfTagsText;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gapText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox burstGapText;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TextBox sequTextBox;
        private System.Windows.Forms.Label Sequ;
        private System.Windows.Forms.Timer timer1;
    }
}

