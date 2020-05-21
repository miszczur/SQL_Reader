using Newtonsoft.Json;
using System;
using System.IO;

namespace SQL_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path; 


           // path = @"C:\Users\Kuba\Desktop\menuTest.sql";

            LogMonitor log = new LogMonitor(); //subscriber

            try
            {
                JsonConfig cfg = JsonConvert.DeserializeObject<JsonConfig>(File.ReadAllText("config.json"));

                if (args.Length!=0)
                {
                    path = args[0];
                }
                else
                {
                path = cfg.DefaultPath;

                }
                

                QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(path);
                ConsoleSender writeOnConsole = new ConsoleSender(); // publisher
                SqlReader reader = new SqlReader(queryFromFileProvider);
                writeOnConsole.Logging += log.OnQueryProvided;
                using DataBaseSender sendToDb = new DataBaseSender(cfg.Path, cfg.Username, cfg.Password);
                sendToDb.Logging += log.OnQueryProvided;
                sendToDb.Message += log.OnMessage;
                reader.SendQueries(sendToDb);

            }
            catch (QueryWithoutSemicolonException e)
            {
                log.OnFileWithoutSemicolonOrBeginAndEndScriptLines(e.Message);
                Console.WriteLine(e.Message);
            }
            catch (FileWithoutBeginAndEndScriptLinesException e)
            {
                log.OnFileWithoutSemicolonOrBeginAndEndScriptLines(e.Message);
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }



    }



}


