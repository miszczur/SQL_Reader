using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace SQL_Reader
{
   static class ConverterJsonBothSide
    {
        public static string SerializeObject(this object item)
        {
            return JsonConvert.SerializeObject(item); 
        }
        public static object DeserializeObject(string item, Type typeOfObject)
        {
            return JsonConvert.DeserializeObject(item, typeOfObject);
        }


    }
}
