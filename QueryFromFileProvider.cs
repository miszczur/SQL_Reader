using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace SQL_Reader
{
    public class QueryFromFileProvider : IQueryProvider
    {
        private IEnumerable<string> lines;
    

        public QueryFromFileProvider(string path)
        {
            this.lines = File.ReadAllLines(path);

        }

        public QueryFromFileProvider(IEnumerable<string> lines)
        {
            this.lines = lines;
        }

        private string removeComments(string line)
        {
           return Regex.Replace(line, "--.*", string.Empty); //removing sql comments in single line from file
        }

        public IEnumerable<string> GetQueries()
        {
            List<string> listLine = new List<string>();
            string buffor;

            foreach (var item in lines)
            {
                buffor = removeComments(item).Trim();
                if (string.IsNullOrWhiteSpace(buffor) == true)
                {
                    continue;
                }
                listLine.Add(buffor);
            }
            if (listLine.Count == 0)
            {
                throw new ArgumentNullException("List is empty");
            }
            else
            {
                return listLine;
            }
        }

    }
      
    
}
