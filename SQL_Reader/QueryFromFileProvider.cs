using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SQL_Reader
{
    public class QueryFromFileProvider : IQueryProvider
    {
        private readonly IEnumerable<string> lines;

        public QueryFromFileProvider(string path)
        {

            if (File.ReadLines(path).First() == "-- begin script" && File.ReadLines(path).Last() == "-- end script")
            {
                this.lines = File.ReadAllLines(path);
            }

            else
            {
                throw new FileWithoutBeginAndEndScriptLinesException("Add \"-- begin script\" in first line and \"-- end script\" in last line in File.");
            }

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
          //  List<string> listOfLines = new List<string>();
            string buffor = null;

            foreach (var item in lines)
            {
                buffor = string.Concat(buffor, removeComments(item));
                if (buffor.EndsWith(';'))
                {
                    //  listOfLines.Add(buffor);
                    yield return buffor;
                    buffor = null; //when query has been provided, we are cleaning variable for Concat method
                }
                else if (string.IsNullOrWhiteSpace(buffor))
                {
                    buffor = null;
                    continue;
                }
            }
            if (!string.IsNullOrEmpty(buffor))
            {
                throw new QueryWithoutSemicolonException($"{buffor} doesn't contain \";\" on the end of line. ");
            }
            //  return listOfLines;
        }
    }
}
