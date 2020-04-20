using System;
using System.IO;


namespace SQL_Reader
{
    class Program
    {



        static void Main(string[] args)
        {


            // QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(args[0]);

            string[] lines = File.ReadAllLines(args[0]);
            QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(lines);

            ConsoleSender writeOnConsole = new ConsoleSender();
            
            SqlReader reader = new SqlReader(queryFromFileProvider);

            reader.SendQueries(writeOnConsole);

            


            Console.ReadKey();

        }
    }
}
