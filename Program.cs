using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ReadATextFile
{
    class Program
    {
        static string removeComments(string line)
        {
            string commentLine = String.Empty;
            commentLine = Regex.Replace(line, "--.*", string.Empty);
            return commentLine;
        }
    

        static void Main(string[] args)
        {
            try
            {
                if (args == null)
            {
                Console.WriteLine("args are null");
            }
            else
            {
                string filePath = args[0];

                
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

                                Console.WriteLine(line);

                            }

                        }

                    }
                }
          
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}