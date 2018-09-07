using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Data;

namespace MVVM_JsonConverter.ExtensionMethods
{
    class Extension_Converter
    {
        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            //string JSONString = string.Empty;
            string JSONString = JsonConvert.SerializeObject(table, Formatting.Indented);
            return JSONString;
        }
    }
}
