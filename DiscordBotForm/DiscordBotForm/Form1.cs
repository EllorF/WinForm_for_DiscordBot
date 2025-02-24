using System;
using System.Diagnostics;
using System.Drawing;

namespace DiscordBotForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(433, 182);
            button1.Enabled = false;
            button2.Enabled = false;
            this.FormClosed += StopAllBots;
        }

        System.Windows.Forms.Timer updateTime = new System.Windows.Forms.Timer();
        PerformanceCounter cpuCounter = new PerformanceCounter();
        CancellationToken token;
        Process p = new Process();
        StreamReader srIncoming;

        private void StopAllBots(object? sender, EventArgs e) => p.Kill();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(433, 433);
            p = new Process();
            p.StartInfo.FileName = $"{BotFileName}";
            p.StartInfo.Arguments = $"-conf {ConfFileName.Replace('\"', '\0')}";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.OutputDataReceived += BotProcess_OutputDataReceived;
            p.ErrorDataReceived += BotProcess_ErrorDataReceived;
            p.Exited += BotProcess_Exited;

            p.Start();

            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            button3.Enabled = false;
            button4.Enabled = false;

            cpuCounter = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);

            updateTime.Interval = 1000;
            updateTime.Tick += new EventHandler(UpdateInfo);
            updateTime.Start();
        }

        private void BotProcess_Exited(object? sender, EventArgs e)
        {
            p.CancelOutputRead();
            p.CancelErrorRead();
            p.OutputDataReceived -= BotProcess_OutputDataReceived;
            p.ErrorDataReceived -= BotProcess_ErrorDataReceived;
            updateTime.Stop();
            label1.Text = "Бот выключен";
            label2.Text = "";
            richTextBox1.Text = "";
            this.Size = new Size(433, 182);
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void BotProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                richTextBox1.Invoke((MethodInvoker)(() =>
                {
                    richTextBox1.AppendText(e.Data + "\n");
                    ChangeTextColor("warn", Color.Yellow, 0);
                    ChangeTextColor("fail", Color.Red, 0);
                    ChangeTextColor("info", Color.Green, 0);
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.ScrollToCaret();
                }));
            }
        }

        private void ChangeTextColor(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.SelectionProtected = true;
                }
            }
        }

        private void BotProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                richTextBox1.Invoke((MethodInvoker)(() =>
                {
                    richTextBox1.AppendText($"[ERROR]: {e.Data}\n");
                    ChangeTextColor("[ERROR]", Color.Red, 0);
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.ScrollToCaret();
                }));
            }
        }

        private void button2_Click(object sender, EventArgs e) => p.Kill();

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
