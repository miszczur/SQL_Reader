using System;
using System.Collections.Generic;

namespace SQL_Reader
{
    public class ConsoleSender : ISender
    {
        public void Send(string query)
        {
            Console.WriteLine(query);
        }

        public void Send(IEnumerable<string> queries)
        {
            foreach (string query in queries)
            {
                Send(query);
            }
        }
    }
}
