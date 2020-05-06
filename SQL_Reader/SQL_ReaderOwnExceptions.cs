using System;
using System.Collections.Generic;

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

    public class QueryWithoutSemicolonException : Exception
    {
        public string message { get; set; }
        public IEnumerable<string> correctrecords { get; set; }
        public QueryWithoutSemicolonException() : base()
        {

        }

        public QueryWithoutSemicolonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public QueryWithoutSemicolonException(string message, IEnumerable<string> correctRecords) : base(message)
        {
            this.message = message;
            this.correctrecords = correctRecords;
        }

        public QueryWithoutSemicolonException(string message) : base(message)
        {
        }
    }


}
