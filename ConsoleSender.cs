using System;
using System.Collections.Generic;

namespace SQL_Reader
{
    public class ConsoleSender : ISender
    {
        public void Send(string query)
        {
            throw new NotImplementedException();
        }

        public void Send(IEnumerable<string> queries)
        {
            throw new NotImplementedException();
        }
    }
}
