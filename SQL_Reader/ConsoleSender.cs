using System;
using System.Collections.Generic;

namespace SQL_Reader
{
    public class ConsoleSender : ISender
    {
        // define a delegate
        // 2 define an event based on that delegate
        //3 raise or publish the event
        public delegate void LogMonitorEventHandler();
        public event LogMonitorEventHandler QueriesLogged;


        public void Send(string query)
        {
            Console.WriteLine(query);
        }

        public void Send(IEnumerable<string> queries)
        {
            OnQueriesLogged();
            foreach (string query in queries)
            {
                
                Send(query);
                
            }
        }

        protected virtual void OnQueriesLogged()
        {
            if (QueriesLogged != null)
            {
                QueriesLogged();
            }
        }
    }
}
