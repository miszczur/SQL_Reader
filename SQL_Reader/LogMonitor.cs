using System.IO;
namespace SQL_Reader
{
    public class LogMonitor
    {

        public void OnQueryProvided(object obj, string e)
        {
            using (StreamWriter sw = File.AppendText("logFile.txt"))
            {
                sw.WriteLine($"Query:{e} has been provided.");
            }
        }
    }
}
