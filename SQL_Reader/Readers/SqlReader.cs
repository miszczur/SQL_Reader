using SQL_Reader.Interfaces;

namespace SQL_Reader.Readers
{
    public class SqlReader
    {


        private readonly IQueryProvider _provider;
        public SqlReader(IQueryProvider provider)
        {
            this._provider = provider;
        }

        public void SendQueries(ISender sender)
        {
            sender.Send(this._provider.GetQueries());
        }
    }
}
