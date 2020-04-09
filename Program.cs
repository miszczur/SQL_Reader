using System;



namespace SQL_Reader
{
    class Program
    {



        static void Main(string[] args)
        {


            QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(args[0]);
           
            ConsoleSender writeOnConsole = new ConsoleSender();
            
            SqlReader reader = new SqlReader(queryFromFileProvider);

            reader.SendQueries(writeOnConsole);

            


            Console.ReadKey();

        }
    }
}