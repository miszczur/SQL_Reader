using System.Collections.Generic;

namespace SQL_Reader.Interfaces
{
    public interface IQueryProvider
    {
        IEnumerable<string> GetQueries();
    }
}
