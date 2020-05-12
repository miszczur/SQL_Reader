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

    public class QueryWithoutSemicolonException : Exception
    {
        public QueryWithoutSemicolonException() : base()
        {

        }

        public QueryWithoutSemicolonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public QueryWithoutSemicolonException(string message) : base(message)
        {
        }
    }

    public class FileWithoutBeginAndEndScriptLinesException : Exception
    {
        public FileWithoutBeginAndEndScriptLinesException() : base()
        {
        }

        public FileWithoutBeginAndEndScriptLinesException(string message) : base(message)
        {
        }

        public FileWithoutBeginAndEndScriptLinesException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
