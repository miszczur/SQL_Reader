using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ReadATextFile
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.Write("Podaj scieżkę dostępu do pliku: "); //C:\Users\Kuba\Desktop\menu.sql
            string textFile = Console.ReadLine();

            try
            {
                if (File.Exists(textFile))
                {

                    // Read file using StreamReader. Reads file line by line  
                    using (StreamReader file = new StreamReader(textFile))
                    {
                        int counter = 0;
                        string line;



                        while ((line = file.ReadLine()) != null)
                        {




                            if (string.IsNullOrWhiteSpace(line) == true)
                            {
                                continue;
                            }
                            line = Regex.Replace(line, "--.*", "");

                            Console.WriteLine(line);
                            counter++;
                        }
                        file.Close();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}