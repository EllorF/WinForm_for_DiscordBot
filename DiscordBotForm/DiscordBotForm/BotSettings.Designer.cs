namespace DiscordBotForm
{
    partial class BotSettings
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
            openFileDialog1 = new OpenFileDialog();
            GeneralButton = new Button();
            ConfigButton = new Button();
            panel1 = new Panel();
            ConfigPanel = new Panel();
            label3 = new Label();
            button5 = new Button();
            label4 = new Label();
            label2 = new Label();
            button4 = new Button();
            label1 = new Label();
            GeneralPanel = new Panel();
            button6 = new Button();
            button7 = new Button();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            ConfigPanel.SuspendLayout();
            GeneralPanel.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // GeneralButton
            // 
            GeneralButton.BackColor = Color.FromArgb(44, 43, 57);
            GeneralButton.FlatAppearance.BorderSize = 0;
            GeneralButton.FlatStyle = FlatStyle.Flat;
            GeneralButton.ForeColor = SystemColors.ButtonFace;
            GeneralButton.Location = new Point(-2, 0);
            GeneralButton.Margin = new Padding(0);
            GeneralButton.Name = "GeneralButton";
            GeneralButton.Size = new Size(87, 36);
            GeneralButton.TabIndex = 0;
            GeneralButton.Text = "General";
            GeneralButton.UseVisualStyleBackColor = false;
            GeneralButton.Click += button1_Click;
            // 
            // ConfigButton
            // 
            ConfigButton.BackColor = Color.FromArgb(44, 43, 57);
            ConfigButton.ForeColor = SystemColors.ButtonFace;
            ConfigButton.Location = new Point(-2, 34);
            ConfigButton.Margin = new Padding(0);
            ConfigButton.Name = "ConfigButton";
            ConfigButton.Size = new Size(87, 36);
            ConfigButton.TabIndex = 1;
            ConfigButton.Text = "Config";
            ConfigButton.UseVisualStyleBackColor = false;
            ConfigButton.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(GeneralButton);
            panel1.Controls.Add(ConfigButton);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(87, 413);
            panel1.TabIndex = 2;
            // 
            // ConfigPanel
            // 
            ConfigPanel.Controls.Add(label3);
            ConfigPanel.Controls.Add(button5);
            ConfigPanel.Controls.Add(label4);
            ConfigPanel.Controls.Add(label2);
            ConfigPanel.Controls.Add(button4);
            ConfigPanel.Controls.Add(label1);
            ConfigPanel.Location = new Point(95, 1);
            ConfigPanel.Name = "ConfigPanel";
            ConfigPanel.Size = new Size(313, 398);
            ConfigPanel.TabIndex = 3;
            ConfigPanel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(0, 99);
            label3.Name = "label3";
            label3.Size = new Size(0, 19);
            label3.TabIndex = 5;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(44, 43, 57);
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = SystemColors.ButtonFace;
            button5.Location = new Point(207, 68);
            button5.Name = "button5";
            button5.Size = new Size(106, 29);
            button5.TabIndex = 4;
            button5.Text = "SelectExeFile";
            button5.UseVisualStyleBackColor = false;
            button5.Click += Button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(0, 73);
            label4.Name = "label4";
            label4.Size = new Size(49, 19);
            label4.TabIndex = 3;
            label4.Text = "ExeFile";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(0, 34);
            label2.Name = "label2";
            label2.Size = new Size(0, 19);
            label2.TabIndex = 2;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(44, 43, 57);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = SystemColors.ButtonFace;
            button4.Location = new Point(207, 3);
            button4.Name = "button4";
            button4.Size = new Size(106, 29);
            button4.TabIndex = 1;
            button4.Text = "SelectConfig";
            button4.UseVisualStyleBackColor = false;
            button4.Click += Button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(0, 8);
            label1.Name = "label1";
            label1.Size = new Size(49, 19);
            label1.TabIndex = 0;
            label1.Text = "Config";
            // 
            // GeneralPanel
            // 
            GeneralPanel.Controls.Add(textBox1);
            GeneralPanel.Controls.Add(button6);
            GeneralPanel.Controls.Add(button7);
            GeneralPanel.Location = new Point(95, 1);
            GeneralPanel.Name = "GeneralPanel";
            GeneralPanel.Size = new Size(313, 398);
            GeneralPanel.TabIndex = 6;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(44, 43, 57);
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = SystemColors.ButtonFace;
            button6.Location = new Point(207, 68);
            button6.Name = "button6";
            button6.Size = new Size(106, 29);
            button6.TabIndex = 4;
            button6.Text = "ClearBotSettings";
            button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(44, 43, 57);
            button7.FlatStyle = FlatStyle.Flat;
            button7.ForeColor = SystemColors.ButtonFace;
            button7.Location = new Point(0, 68);
            button7.Name = "button7";
            button7.Size = new Size(106, 29);
            button7.TabIndex = 1;
            button7.Text = "DeleteBot";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(44, 43, 57);
            textBox1.ForeColor = SystemColors.ButtonFace;
            textBox1.Location = new Point(101, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            textBox1.Text = "BotName";
            // 
            // BotSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 43, 57);
            ClientSize = new Size(417, 411);
            Controls.Add(panel1);
            Controls.Add(GeneralPanel);
            Controls.Add(ConfigPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "BotSettings";
            Text = "Discord bot";
            panel1.ResumeLayout(false);
            ConfigPanel.ResumeLayout(false);
            ConfigPanel.PerformLayout();
            GeneralPanel.ResumeLayout(false);
            GeneralPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private Button GeneralButton;
        private Button ConfigButton;
        private Panel panel1;
        private Panel ConfigPanel;
        private Label label2;
        private Button button4;
        private Label label1;
        private Label label3;
        private Button button5;
        private Label label4;
        private Panel GeneralPanel;
        private Button button6;
        private Button button7;
        private TextBox textBox1;
    }
}