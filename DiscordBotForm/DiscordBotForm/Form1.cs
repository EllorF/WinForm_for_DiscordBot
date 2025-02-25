using Newtonsoft.Json;
using System.Diagnostics;

namespace DiscordBotForm
{
    public partial class Form1 : Form
    {
        public class Settings
        {
            public int BotCount;
            public List<string> BotNames = new List<string>();
        }
        public Settings settings = new Settings();

        public Form1()
        {
            settings = new Settings();
            InitializeComponent();
            this.Size = new Size(433, 200);
            this.FormClosed += StopAllBots;

            string json = string.Empty;
            if (!File.Exists("Settings.json"))
            {
                settings.BotCount = 1;
                settings.BotNames.Add("Bot1");
                File.Create("Settings.json").Close();
                json = JsonConvert.SerializeObject(settings);

                using var writer = new StreamWriter("Settings.json", false);
                writer.WriteLine(json);
            }

            using (StreamReader r = new("Settings.json"))
            {
                json = r.ReadToEnd();
                settings = JsonConvert.DeserializeObject<Settings>(json);
                for (int i = 0; i < settings.BotCount; i++)
                    bot.Add(new Bot());
            }

            for (int i = 0; i < settings.BotCount; i++)
                toolStripComboBox1.Items.Add(settings.BotNames[i]);
            toolStripComboBox1.Items.Add("AddBot");
            toolStripComboBox1.SelectedIndex = 0;
            toolStripComboBox1.SelectedIndexChanged += ToolStripComboBox1_SelectedIndexChanged;
            LoadJson();
        }

        private void ToolStripComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            richTextBox1.Focus();
            if (toolStripComboBox1.SelectedIndex == toolStripComboBox1.Items.Count - 1)
            {
                bot.Add(new Bot());
                settings.BotCount++;
                settings.BotNames.Add("Bot" + settings.BotCount);

                var json = JsonConvert.SerializeObject(settings);

                using var writer = new StreamWriter("Settings.json", false);
                writer.WriteLine(json);

                BotSettings addBotForm = new BotSettings(this, toolStripComboBox1.SelectedIndex);
                addBotForm.Text = settings.BotNames[toolStripComboBox1.SelectedIndex] + " Settings";
                addBotForm.ShowDialog();
            }
        }

        public void LoadJson()
        {
            try
            {
                var botSettings = new List<Bot.BotSettings>();
                using (StreamReader r = new("BotSettings.json"))
                {
                    string json = r.ReadToEnd();
                    botSettings = JsonConvert.DeserializeObject<List<Bot.BotSettings>>(json);
                }

                for (int i = 0; i < bot.Count; i++)
                    bot[i].settings = botSettings[i];

                button1.Enabled = bot[BotIndex].settings.Config != null && bot[BotIndex].settings.ExeFile != null;
                button2.Enabled = bot[BotIndex].settings.Config != null && bot[BotIndex].settings.ExeFile != null;
            }
            catch { }
        }

        public readonly List<Bot> bot = new();
        public int BotIndex = 0;

        readonly System.Windows.Forms.Timer updateTime = new();
        PerformanceCounter cpuCounter = new();

        private void StopAllBots(object? sender, EventArgs e) { try { bot[BotIndex].Stop(new DataReceivedEventHandler(BotProcess_OutputDataReceived), new DataReceivedEventHandler(BotProcess_ErrorDataReceived)); } catch { } }

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

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(433, 450);
            richTextBox1.Text = "";
            bot[BotIndex].Start(new DataReceivedEventHandler(BotProcess_OutputDataReceived), new DataReceivedEventHandler(BotProcess_ErrorDataReceived));

            cpuCounter = new PerformanceCounter("Process", "% Processor Time", bot[BotIndex].p.ProcessName);

            updateTime.Interval = 1000;
            updateTime.Tick += new EventHandler(UpdateInfo);
            updateTime.Start();
        }

        private void BotProcess_Exited(object? sender, EventArgs e)
        {
            bot[BotIndex].Stop(new DataReceivedEventHandler(BotProcess_OutputDataReceived), new DataReceivedEventHandler(BotProcess_ErrorDataReceived));

            updateTime.Stop();
            label1.Text = "Бот выключен";
            label2.Text = "";
            richTextBox1.Text = "";
            this.Size = new Size(433, 182);
        }

        private void Button2_Click(object sender, EventArgs e) { bot[BotIndex].Stop(new DataReceivedEventHandler(BotProcess_OutputDataReceived), new DataReceivedEventHandler(BotProcess_ErrorDataReceived)); }

        public void UpdateInfo(object sender, EventArgs e)
        {
            label1.Text = bot[BotIndex].p.HasExited ? "Бот выключен" : "Бот запущен";
            label2.Text = !bot[BotIndex].p.HasExited ? $"""
                    Занято памяти: {bot[BotIndex].p.PrivateMemorySize64 / (1024 * 1024)} МБ
                    Процессор: {cpuCounter.NextValue()}%
                    Время запуска: {bot[BotIndex].p.StartTime}
                    Время работы: {new DateTime((DateTime.Now - bot[BotIndex].p.StartTime).Ticks):HH:mm:ss}
                    """ : "";
        }

        public void SaveJson()
        {
            var botSettings = new List<Bot.BotSettings>();
            for (int i = 0; i < bot.Count; i++)
                botSettings.Add(bot[i].settings);

            var json = JsonConvert.SerializeObject(botSettings);

            using var writer = new StreamWriter("BotSettings.json", false);
            writer.WriteLine(json);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BotSettings addBotForm = new BotSettings(this, toolStripComboBox1.SelectedIndex);
            addBotForm.Text = settings.BotNames[toolStripComboBox1.SelectedIndex] + " Settings";
            addBotForm.ShowDialog();
        }
    }
}