using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SQL_Reader
{
    public class QueryFromFileProvider : IQueryProvider
    {
        private readonly IEnumerable<string> lines;

        public QueryFromFileProvider(string path)
        {
            this.lines = File.ReadAllLines(path);
        }

        public QueryFromFileProvider(IEnumerable<string> lines)
        {
            if (lines == null)
            {
                throw new QueryFromFileProviderNullLineException("Parameter of this constructor cannot be null.");
            }
            this.lines = lines;
        }

        private string removeComments(string line)
        {
            return Regex.Replace(line, "--.*", string.Empty).Trim(); //removing sql comments in single line from file
        }

        public IEnumerable<string> GetQueries()
        {
            List<string> listOfLines = new List<string>();
            string buffor = null;

            foreach (var item in lines)
            {
                buffor = string.Concat(buffor, removeComments(item));
                if (string.IsNullOrWhiteSpace(buffor) || buffor.EndsWith(';') == false)
                {
                    continue;
                }

                listOfLines.Add(buffor);

                buffor = null; //when query has been provided, we are cleaning variable for Concat method
            }
            if (buffor != null)
            {
                throw new QueryWithoutSemicolonException(buffor, listOfLines);
                File.AppendAllText("logFile.txt", $"{DateTime.Now:yyyy.MM.dd HH:mm:ss.fff} | {buffor} thrown QueryWithoutSemicolonExpression {Environment.NewLine}");
            }
            return listOfLines;
        }


    }
}
