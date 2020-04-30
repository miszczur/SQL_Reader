using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SQL_Reader
{
    public class LogMonitor
    {
        public void OnQueryProvided(string e)
        {
            Console.WriteLine($"Query {e} has been provided.");
        }

        //TODO: method to saving logs to file, more logging methods
    }
}
