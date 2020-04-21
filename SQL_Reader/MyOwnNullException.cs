using System;
using System.Collections.Generic;
using System.Text;

namespace SQL_Reader
{
    class MyOwnNullException : Exception
    {
        public override string Message
        {
            get
            {
                return "Argument cannot be null!";
            }
        }
    }
}
