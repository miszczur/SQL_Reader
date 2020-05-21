using System;
using System.IO;
namespace SQL_Reader
{
    public class LogMonitor
    {
        public void OnQueryProvided(object obj, string e)
        {
            File.AppendAllText("logFile.txt", $"-------------------------{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff}------------------------- {Environment.NewLine}");
            File.AppendAllText("logFile.txt", $"{e}");
            File.AppendAllText("logFile.txt", $"-------------------------COMMIT------------------------- {Environment.NewLine}");
        }
        public void OnMessage(object obj, string mess)
        {
            Console.WriteLine(mess);
        }
        public void OnFileWithoutSemicolonOrBeginAndEndScriptLines(string message)
        {
            File.AppendAllText("logFile.txt", $"{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff} | {message} {Environment.NewLine}");
        }
    }
}
