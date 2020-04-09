using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SQL_Reader
{
    public class QueryFromFileProvider : IQueryProvider
    {
        private string filePath;

        public QueryFromFileProvider(string path)
        {
            this.filePath = path;
        }
        private string removeComments(string line)
        {
            string commentLine = String.Empty;
            commentLine = Regex.Replace(line, "--.*", string.Empty);
            return commentLine;
        }
        public IEnumerable<string> GetQueries()
        {
            List<string> listLine = new List<string>();
            if (File.Exists(filePath))
            {

                // Read file using StreamReader. Reads file line by line  
                using (StreamReader file = new StreamReader(filePath))
                {
                    string line;

                    while ((line = file.ReadLine()) != null)
                    {


                        removeComments(line);

                        if (string.IsNullOrWhiteSpace(line) == true)
                        {
                            continue;
                        }

                        listLine.Add(line);
                        
                    }

                }

            }
            return listLine;

        }
    }
}
