using System;
using System.Collections.Generic;
using SQL_Reader.Interfaces;

namespace SQL_Reader.Senders
{
    public class ConsoleSender : ISender
    {
        public event EventHandler<string> Logging;


        public void Send(string query)
        {
            OnQueriesLogged(query);
            Console.WriteLine(query);
        }

        public void Send(IEnumerable<string> queries)
        {

            foreach (string query in queries)
            {
                Send(query);
            }
        }

        protected virtual void OnQueriesLogged(string e)
        {
            Logging?.Invoke(this, e);
        }
    }
}
