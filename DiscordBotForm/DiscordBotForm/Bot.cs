using System.Diagnostics;

namespace DiscordBotForm
{
    public class Bot
    {
        public class BotSettings
        {
            public string? Config { get; set; }
            public string? ExeFile { get; set; }
        }
        public BotSettings settings = new();

        bool BotStarted = false;
        public Process p = new();

        public void Start(DataReceivedEventHandler outPut, DataReceivedEventHandler ErrorOutPut)
        {
            if (!BotStarted)
            {
                p = new Process();
                p.StartInfo.FileName = $"{settings.ExeFile}";
                p.StartInfo.Arguments = $"-conf {settings.Config}";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;

                p.OutputDataReceived += outPut;
                p.ErrorDataReceived += ErrorOutPut;

                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                BotStarted = true;
            }
        }

        public void Stop(DataReceivedEventHandler outPut, DataReceivedEventHandler ErrorOutPut)
        {
            p.CancelOutputRead();
            p.CancelErrorRead();
            p.OutputDataReceived -= outPut;
            p.ErrorDataReceived -= ErrorOutPut;
            p.Kill();
        }
    }
}
