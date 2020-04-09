using System.Collections.Generic;

namespace SQL_Reader
{
    public interface ISender
    {
        void Send(string query);
        void Send(IEnumerable<string> queries);
    }
}
