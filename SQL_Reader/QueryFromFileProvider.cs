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
           return Regex.Replace(line, "--.*", string.Empty).Trim(); //removing sql comments in single line from file
        }

        public IEnumerable<string> GetQueries()
        {
            List<string> listOfLines = new List<string>();
            string buffor;
            if (lines != null)
            {
                foreach (var item in lines)
                {
                    buffor = removeComments(item);
                    if (string.IsNullOrWhiteSpace(buffor) == true)
                    {
                        continue;
                    }
                    listOfLines.Add(buffor);
                }

                if(listOfLines.Count == 0)
                {
                    listOfLines.Add("List of Queries is empty!");
                }
                return listOfLines;

            }        
            
            else
            {
                listOfLines.Add("List of Queries is empty!");
                return listOfLines;
            }
            
        }

    }
      
    
}
