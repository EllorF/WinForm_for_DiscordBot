using System;
using System.Diagnostics;

namespace DiscordBotForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
        }

        System.Windows.Forms.Timer updateTime = new System.Windows.Forms.Timer();
        PerformanceCounter cpuCounter = new PerformanceCounter();
        CancellationToken token;
        Process p = new Process();

        private void button1_Click(object sender, EventArgs e)
        {
            p = Process.Start($"{BotFileName}", $"-conf {ConfFileName.Replace('\"', '\0')}");
            cpuCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);

            updateTime.Interval = 1000;
            updateTime.Tick += new EventHandler(UpdateInfo);
            updateTime.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Kill();
            updateTime.Stop();
            label1.Text = "Бот выключен";
            label2.Text = "";
        }

        public void UpdateInfo(object sender, EventArgs e)
        {
            label1.Text = p.HasExited ? "Бот выключен" : "Бот запущен";
            label2.Text = !p.HasExited ? $"""
                    Занято памяти: {p.PrivateMemorySize64 / (1024 * 1024)} МБ
                    Процессор: {cpuCounter.NextValue()}%
                    Время запуска: {p.StartTime}
                    Время работы: {new DateTime((DateTime.Now - p.StartTime).Ticks).ToString("HH:mm:ss")}
                    """ : "";
        }

        string BotFileName = string.Empty;
        string ConfFileName = string.Empty;
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Все файлы |*.*";
            openFileDialog1.ShowDialog();
            ConfFileName = openFileDialog1.FileName;

            button1.Enabled = ConfFileName != string.Empty && BotFileName != string.Empty;
            button2.Enabled = ConfFileName != string.Empty && BotFileName != string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Исполняемый файл |*.exe";
            openFileDialog1.ShowDialog();
            BotFileName = openFileDialog1.FileName;

            button1.Enabled = ConfFileName != string.Empty && BotFileName != string.Empty;
            button2.Enabled = ConfFileName != string.Empty && BotFileName != string.Empty;
        }
    }
}
