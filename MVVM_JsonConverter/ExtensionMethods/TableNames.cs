using MVVM_JsonConverter.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Prism.Mvvm;
using MVVM_JsonConverter;
using System.Diagnostics;
using System.IO;

namespace MVVM_JsonConverter.ExtensionMethods
{
     public class TableNames 
    {

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public  List<Object> LoadTables()
        {
            List<object> tableNames = new List<object>();

            DataBaseHelper Helper = new DataBaseHelper();
            Helper.ChangeConnectionString();

            if (Helper.GetDialogResult() == true)
            {
                this.fileName = Path.GetFileNameWithoutExtension(Helper.GetFileName().ToString());

                DataTable tables = Helper.ConnectToDB().GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


                foreach (DataRow row in tables.Rows)
                {
                    tableNames.Add(row[2]);
                }
                
            }
             
            return tableNames;

        }





    }
}
