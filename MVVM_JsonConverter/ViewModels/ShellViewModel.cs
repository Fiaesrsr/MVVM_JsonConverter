using MVVM_JsonConverter.Models;
using Prism.Mvvm;
using MVVM_JsonConverter;
using MVVM_JsonConverter.ExtensionMethods;
using System.Data;
using System.Collections.Generic;
using Prism.Commands;
using MVVM_JsonConverter.ViewModels.Bases;
using System;

namespace MVVM_JsonConverter.ViewModels
{
    class ShellViewModel : ViewModelBase
    {


        /// <summary>
        /// DataBinding für MainWindow Titel
        /// </summary>
        public string Title { get; set; } = "Json Converter";
        
        /// <summary>
        /// DataBinding für Tables_Listbox.Items
        /// </summary>
        public List<object> Tables { get; set; } = new Model_DataTablesListBox().LoadTables();


        public DelegateCommand<object> OpenFileCommand { get; set; }
        protected override void RegisterCommands()
        {
            OpenFileCommand = new DelegateCommand<object>(OpenFile);
        }

        private void OpenFile(object obj)
        {
            new DataBaseHelper().ChangeConnectionString();
        }
    }
}
