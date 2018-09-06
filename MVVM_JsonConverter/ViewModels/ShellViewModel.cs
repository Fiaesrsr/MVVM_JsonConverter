using MVVM_JsonConverter.Models;
using Prism.Mvvm;
using MVVM_JsonConverter;
using MVVM_JsonConverter.ExtensionMethods;
using System.Data;
using System.Collections.Generic;

namespace MVVM_JsonConverter.ViewModels
{
    class ShellViewModel : BindableBase
    {


        /// <summary>
        /// DataBinding für MainWindow Titel
        /// </summary>
        public string Title { get; set; } = "Json Converter";
        
        /// <summary>
        /// DataBinding für Tables_Listbox.Items
        /// </summary>
        public List<object> Tables { get; set; } = new DataTablesListBox().LoadTables();
    }
}
