using FirebirdSql.Data.FirebirdClient;
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

                if (args.Length != 0)
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
                sendToDb.Log += log.OnQueryProvided;
                sendToDb.Message += log.OnMessage;
                sendToDb.Error += log.OnErrorLogging;
                reader.SendQueries(sendToDb);

            }
            catch (QueryWithoutSemicolonException e)
            {
                log.OnErrorLogging(e, e.Message);
            }
            catch (FileWithoutBeginAndEndScriptLinesException e)
            {
                log.OnMessage(e, e.Message);
            }
            catch (FbException e)
            {
                log.OnErrorLogging(e, e.Message);
            }
            catch(IOException e)
            {
                log.OnErrorLogging(e, e.Message);
            }
            Console.ReadKey();
        }



    }



}


