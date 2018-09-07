using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Microsoft.Win32;

namespace MVVM_JsonConverter.ExtensionMethods
{
    class Extension_DataBaseHelper
    {
        // Attribute
        private string connString;
        private Nullable<bool> dialogResult;
        private OleDbConnection conn = new OleDbConnection();
        private string fileName;
        public Extension_DataBaseHelper()
        {
            
        }

        // Methoden

        /// <summary>
        /// Instanziiert eine Datenbank verbindung mit einem Connection String als Übergabeparameter und öffnet die Verbindung zur Datenbank.
        /// </summary>
        /// <returns></returns>
        public OleDbConnection ConnectToDB()
        {
            this.conn = new OleDbConnection(GetConnectionString());
            conn.Open();
            return conn;
        }
        /// <summary>
        /// Erhält eine OleDbConnection als Übergabeparameter und schließt die Verbindung zur Datenbank.
        /// </summary>
        /// <param name="dbConnection"></param>
        public void DisconnectDB(OleDbConnection dbConnection)
        {
            dbConnection.Close();

        }

        public string SelectTable()
        {
            return "SELECT * FROM ";
        }
        /// <summary>
        /// Öffnet einen File Dialog um den Connection String mit der ausgewählten datei zu ergänzen.
        /// </summary>
        public void ChangeConnectionString()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DB files (*.mdb)|*.mdb|All files (*.*)|*.*";
            this.dialogResult = openFileDialog.ShowDialog();

            this.connString = "Provider=Microsoft.JET.OLEDB.4.0;data source=" + openFileDialog.FileName.ToString();
            fileName = openFileDialog.FileName.ToString();
        }


        // Getter und Setter
        /// <summary>
        /// Return der Connection.
        /// </summary>
        /// <returns>conn</returns>
        public OleDbConnection GetConnection()
        {
            return this.conn;
        }

        /// <summary>
        /// Return des Connection Strings
        /// </summary>
        /// <returns>connString</returns>
        public string GetConnectionString()
        {

            return connString;
        }
        /// <summary>
        /// Getter für das Resultat des File Dialogs
        /// </summary>
        /// <returns>nullable bool = dialogResultat</returns>
        public bool? GetDialogResult()
        {
            return dialogResult;
        }
        /// <summary>
        /// Getter für den FilePath aus OpenFileDialog.
        /// </summary>
        /// <returns>fileName</returns>
        public string GetFileName()
        {
            return fileName;
        }
    }
}
    
