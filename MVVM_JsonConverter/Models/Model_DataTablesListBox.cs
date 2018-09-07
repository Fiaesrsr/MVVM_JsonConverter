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

        private List<object> _tablenames;

        public List<object> TableNames
        {
            get => _tablenames;
            set => SetProperty(ref _tablenames, value);
        }

        public List<object> LoadTables()
        {
            List<object> tableNames = new List<object>();

            Extension_DataBaseHelper Helper = new Extension_DataBaseHelper();
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
