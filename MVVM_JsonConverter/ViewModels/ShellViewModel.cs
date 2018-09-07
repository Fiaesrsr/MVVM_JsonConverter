using MVVM_JsonConverter.Models;
using Prism.Mvvm;
using MVVM_JsonConverter;
using MVVM_JsonConverter.ExtensionMethods;
using System.Data;
using System.Collections.Generic;
using Prism.Commands;
using MVVM_JsonConverter.ViewModels.Bases;
using System;
using System.Windows;

namespace MVVM_JsonConverter.ViewModels
{
    class ShellViewModel : ViewModelBase
    {
        private List<object> _tables;

        public List<object> Tables
        {
            get => _tables;
            set => SetProperty(ref _tables, value);
        }


        /// <summary>
        /// DataBinding für MainWindow Titel
        /// </summary>
        public string Title { get; set; } = "Json Converter";
        public DelegateCommand<object> OpenFileCommand { get; set; }
        
        public DelegateCommand<object> CloseApplicationCommand { get; set; }
        protected override void RegisterCommands()
        {
            OpenFileCommand = new DelegateCommand<object>(OpenFile);
            CloseApplicationCommand = new DelegateCommand<object>(ShutItDown);
        }

        /// <summary>
        /// DataBinding für Tables_Listbox.Items
        /// </summary>
        


        private void OpenFile(object obj)
        {
          this._tables  = new Model_DataTablesListBox().LoadTables();
        }
        ///  METHODEN  ///
        private void ShutItDown(object obj)
        {
            Application.Current.Shutdown();
        }

    }
}
