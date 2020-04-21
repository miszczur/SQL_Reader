using System;

namespace SQL_Reader
{
    public class QueryFromFileProviderNullLineException : Exception
    {
        public QueryFromFileProviderNullLineException() : base()
        {
        }

        public QueryFromFileProviderNullLineException(string message) : base(message)
        {
        }

        public QueryFromFileProviderNullLineException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
