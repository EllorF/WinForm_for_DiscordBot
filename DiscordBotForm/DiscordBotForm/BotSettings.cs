using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordBotForm
{
    public partial class BotSettings : Form
    {
        Form1 form;
        int BotIndex;
        public BotSettings(Form1 form, int BotIndex)
        {
            this.form = form;
            this.BotIndex = BotIndex;
            InitializeComponent();
            label2.Text = form.bot[BotIndex].settings.Config;
            label3.Text = form.bot[BotIndex].settings.ExeFile;
            textBox1.Text = form.settings.BotNames[BotIndex];
            ConfigPanel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GeneralButton.FlatStyle = FlatStyle.Standard;
            GeneralButton.FlatAppearance.BorderSize = 1;
            GeneralPanel.Visible = false;


            ConfigButton.FlatStyle = FlatStyle.Flat;
            ConfigButton.FlatAppearance.BorderSize = 0;
            ConfigPanel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigButton.FlatStyle = FlatStyle.Standard;
            ConfigButton.FlatAppearance.BorderSize = 1;
            ConfigPanel.Visible = false;

            GeneralButton.FlatStyle = FlatStyle.Flat;
            GeneralButton.FlatAppearance.BorderSize = 0;
            GeneralPanel.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Все файлы |*.*";
            openFileDialog1.ShowDialog();
            form.bot[BotIndex].settings.Config = openFileDialog1.FileName;
            form.SaveJson();
            label2.Text = form.bot[BotIndex].settings.Config;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Исполняемый файл |*.exe";
            openFileDialog1.ShowDialog();
            form.bot[BotIndex].settings.ExeFile = openFileDialog1.FileName;
            form.SaveJson();
            label3.Text = form.bot[BotIndex].settings.ExeFile;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            form.bot.RemoveAt(BotIndex);
            form.settings.BotNames.RemoveAt(BotIndex);
            form.settings.BotCount--;
            form.SaveJson();
            this.Close();
        }
    }
}
