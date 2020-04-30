using System;
using System.Collections.Generic;

namespace SQL_Reader
{
    public class ConsoleSender : ISender
    {
        // define a delegate
        // 2 define an event based on that delegate
        //3 raise or publish the event
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
            Logging?.Invoke(this,e);
        }
    }
}
