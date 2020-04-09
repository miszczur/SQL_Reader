using System;
using System.IO;



namespace SQL_Reader
{
    class Program
    {



        static void Main(string[] args)
        {


            QueryFromFileProvider filePath = new QueryFromFileProvider(args[0]);
            filePath.GetQueries();


            Console.ReadKey();

        }
    }
}