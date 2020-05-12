namespace SQL_Reader
{
    public class SqlReader
    {


        private readonly IQueryProvider provider;
        public SqlReader(IQueryProvider provider)
        {
            this.provider = provider;
        }

        public void SendQueries(ISender sender)
        {
            sender.Send(this.provider.GetQueries());
        }
    }
}
