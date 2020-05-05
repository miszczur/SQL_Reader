using System;
using System.IO;

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

    public class QueryWithoutSemicolonException : ArgumentOutOfRangeException
    {
        public QueryWithoutSemicolonException() : base()
        {
        }

        public QueryWithoutSemicolonException(string message) : base(message)
        {
            File.AppendAllText("logFile.txt", $"{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff} | Query dont have semicolon! {Environment.NewLine}");
        }

        public QueryWithoutSemicolonException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
