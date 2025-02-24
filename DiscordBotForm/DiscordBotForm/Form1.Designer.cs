п»їnamespace DiscordBotForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            button3 = new Button();
            openFileDialog1 = new OpenFileDialog();
            button4 = new Button();
            richTextBox1 = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(44, 43, 57);
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 64);
            button1.FlatAppearance.CheckedBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 43, 130);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(132, 23);
            button1.TabIndex = 0;
            button1.Text = "StartBot";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(44, 43, 57);
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 64);
            button2.FlatAppearance.CheckedBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 43, 130);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(12, 41);
            button2.Name = "button2";
            button2.Size = new Size(132, 23);
            button2.TabIndex = 1;
            button2.Text = "StopBot";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(3, 2);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 2;
            label1.Text = "Р‘РѕС‚ РІС‹РєР»СЋС‡РµРЅ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(3, 31);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(150, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 119);
            panel1.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(44, 43, 57);
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 64);
            button3.FlatAppearance.CheckedBackColor = Color.White;
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 43, 130);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = SystemColors.ButtonFace;
            button3.Location = new Point(12, 70);
            button3.Name = "button3";
            button3.Size = new Size(132, 23);
            button3.TabIndex = 5;
            button3.Text = "Set Conf File";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(44, 43, 57);
            button4.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 64);
            button4.FlatAppearance.CheckedBackColor = Color.White;
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(44, 43, 130);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Location = new Point(12, 99);
            button4.Name = "button4";
            button4.Size = new Size(132, 23);
            button4.TabIndex = 6;
            button4.Text = "Set Bot Exe";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(44, 43, 57);
            richTextBox1.ForeColor = SystemColors.MenuBar;
            richTextBox1.Location = new Point(12, 151);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(393, 231);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 43, 57);
            ClientSize = new Size(417, 394);
            Controls.Add(richTextBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Discord bot";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Button button3;
        private OpenFileDialog openFileDialog1;
        private Button button4;
        private RichTextBox richTextBox1;
    }
}
