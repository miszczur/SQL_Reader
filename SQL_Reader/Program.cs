using System;

namespace SQL_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            LogMonitor log = new LogMonitor(); //subscriber

            ConsoleSender writeOnConsole = new ConsoleSender(); // publisher


          //  string[] lines = { "alelalamanochala ------dousuniecia", " druga linijka -- do usuniecia" };
           // QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(lines);
            QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(args[0]);
            SqlReader reader = new SqlReader(queryFromFileProvider);
            //         writeOnConsole.QueriesLogged += queryFromFileProvider.OnQueriesProvided;
            writeOnConsole.Logging += log.OnQueryProvided;

            reader.SendQueries(writeOnConsole);

            Console.ReadKey();
        }


    }
}

