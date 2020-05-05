using System;
using System.IO;
namespace SQL_Reader
{
    public class LogMonitor
    {

        public void OnQueryProvided(object obj, string e)
        {
            File.AppendAllText("logFile.txt", $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} {e} {Environment.NewLine}");

        }
    }
}
