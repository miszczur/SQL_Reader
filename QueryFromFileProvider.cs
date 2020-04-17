using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SQL_Reader
{
    public class QueryFromFileProvider : IQueryProvider
    {
        private string[] lines;
    

        public QueryFromFileProvider(string path)
        {
            this.lines = File.ReadAllLines(path);

        }

        public QueryFromFileProvider(string[] lines)
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
            

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = removeComments(lines[i]);
                if (string.IsNullOrWhiteSpace(lines[i]) == true)
                {
                    continue;
                }
                listLine.Add(lines[i]);
            }
            return listLine;
        }

    }
      
    
}
