using System.Collections.Generic;

namespace SQL_Reader
{
    public interface IQueryProvider
    {
        IEnumerable<string> GetQueries();
        
    }
}
