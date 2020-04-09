using System.Collections.Generic;

namespace SQL_Reader
{
    public class SqlReader
    {
        public List<string> PrepareQueries(IQueryProvider provider)
        {
            List<string> QueriedProvider = new List<string>();

            QueriedProvider = (List<string>)provider.GetQueries();
            return QueriedProvider;

        }
        public void SendQueries(ISender sender)
        {

        }
    }
}
