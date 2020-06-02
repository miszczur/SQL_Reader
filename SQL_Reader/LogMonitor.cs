using System;
using System.IO;
namespace SQL_Reader
{
    public class LogMonitor
    {
        public void OnQueryProvided(object obj, string message)
        {
            File.AppendAllText("logFile.txt", $"-------------------------{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff}------------------------- {Environment.NewLine}");
            File.AppendAllText("logFile.txt", $"{message}");
            File.AppendAllText("logFile.txt", $"-------------------------COMMIT------------------------- {Environment.NewLine}");
        }
        public void OnMessage(object obj, string message)
        {
            Console.WriteLine(message);
        }
        public void OnErrorLogging(object obj, string message)
        {
            File.AppendAllText("logFile.txt", $"{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff} | {message} {Environment.NewLine}");
            Console.WriteLine(message);
        }
    }
}
