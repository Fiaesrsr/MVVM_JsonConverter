using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Prism.Mvvm;
using MVVM_JsonConverter.ExtensionMethods;

namespace MVVM_JsonConverter.Models
{
    class Model_DataTablesListBox : BindableBase
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public List<Object> LoadTables()
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
