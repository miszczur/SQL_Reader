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
                throw new QueryFromFileProviderNullLineException("parameter of this constructor cannot be null");
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
            string buffor;

            foreach (var item in lines)
            {
                buffor = removeComments(item);
                if (string.IsNullOrWhiteSpace(buffor))
                {
                    continue;
                }
                listOfLines.Add(buffor);
            }
            return listOfLines;
        }
    }
}
