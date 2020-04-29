using System;

namespace SQL_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            
           // QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(args[0]);
            ConsoleSender writeOnConsole = new ConsoleSender(); // publisher
                                                                     
            string[] lines = { "alelalamanochala ------dousuniecia"};
        
            QueryFromFileProvider queryFromFileProvider = new QueryFromFileProvider(lines);
            SqlReader reader = new SqlReader(queryFromFileProvider);
            writeOnConsole.QueriesLogged += queryFromFileProvider.OnQueriesProvided;
            reader.SendQueries(writeOnConsole);
            
            Console.ReadKey();
        }
    }
}
