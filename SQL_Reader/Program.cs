using System;

namespace SQL_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
          //  path = @"C:\Users\Kuba\Desktop\menuTest.sql";

            LogMonitor log = new LogMonitor(); //subscriber


            QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(path);
            ConsoleSender writeOnConsole = new ConsoleSender(); // publisher
            SqlReader reader = new SqlReader(queryFromFileProvider);
            DataBaseSender sendToDb = new DataBaseSender();

          //  writeOnConsole.Logging += log.OnQueryProvided;
            sendToDb.Logging += log.OnQueryProvided;
            try
            {
                  // reader.SendQueries(writeOnConsole);
                reader.SendQueries(sendToDb);
            }
            catch (QueryWithoutSemicolonException e)
            {
                log.OnFileWithoutBeginAndEndScriptLines(e.Message);
                Console.WriteLine(e.Message);
            }
            catch (FileWithoutBeginAndEndScriptLinesException e)
            {
                log.OnFileWithoutBeginAndEndScriptLines(e.Message);
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }



    }


}


