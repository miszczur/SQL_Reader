using System;

namespace SQL_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            LogMonitor log = new LogMonitor(); //subscriber

            ConsoleSender writeOnConsole = new ConsoleSender(); // publisher


           // string[] lines = { "alelalamanochala; ------dousuniecia;", " druga linijka; -- do usuniecia", @"INSERT INTO TMP_MENU( PROGRAMIDENT, PRGPATH,  KABEL, KABELIDENT, OPIS, SPECIALIDX, CHIP, SHOWTOUSER, FUNCTIONALITY, CABLEGROUP)
            //",@"VALUES(3128, 'CARS\ACURA\ILX 93C66', 'C18', 145, 764, 0, 69, 1, 36, 2);" };
          //  QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(lines);
            QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(args[0]);
            SqlReader reader = new SqlReader(queryFromFileProvider);
            writeOnConsole.Logging += log.OnQueryProvided;

            reader.SendQueries(writeOnConsole);

            Console.ReadKey();
        }


    }
}

