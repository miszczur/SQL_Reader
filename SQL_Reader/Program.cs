using System;

namespace SQL_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];

            LogMonitor log = new LogMonitor(); //subscriber

            try
            {               
                QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(path);
                ConsoleSender writeOnConsole = new ConsoleSender(); // publisher
                SqlReader reader = new SqlReader(queryFromFileProvider);

                writeOnConsole.Logging += log.OnQueryProvided;

                try
                {
                    reader.SendQueries(writeOnConsole);
                }
                catch (QueryWithoutSemicolonException e)
                {
                    log.OnFileWithoutBeginAndEndScriptLines(e.Message);
                    Console.WriteLine(e.Message);
                }

                Console.ReadKey();

            }
            catch (FileWithoutBeginAndEndScriptLinesException e)
            {
                log.OnFileWithoutBeginAndEndScriptLines(e.Message);
                Console.WriteLine(e.Message);
            }

            
        }


    }
}

