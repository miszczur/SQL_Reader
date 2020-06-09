using System.Collections.Generic;

namespace SQL_Reader.Interfaces
{
    public interface ISender
    {
        public void Send(string query);
        public void Send(IEnumerable<string> queries);
    }
}
