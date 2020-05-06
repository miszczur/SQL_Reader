using System;
using System.IO;
namespace SQL_Reader
{
    public class LogMonitor
    {
        public void OnQueryProvided(object obj, string e)
        {
            File.AppendAllText("logFile.txt", $"{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff} | {e} {Environment.NewLine}");

        }
        public void OnQueryWithoutSemicolon(object obj, string e)
        {
            File.AppendAllText("logFile.txt", $"{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff} | {e} thrown QueryWithoutSemicolonExpression {Environment.NewLine}");
        }
    }
}
