using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtCollector.Models;
using Microsoft.Win32;

namespace DebtCollector.FileSource
{
    class EditFileSourceViewModel: BindableBase
    {
        private DebtCollector.Models.FileXML _fileSource = new FileXML() { FileName = "debts.xml" };

        public DebtCollector.Models.FileXML FileSource
        {
            get { return _fileSource; }
            set { SetProperty(ref _fileSource, value); }
        }

        public EditFileSourceViewModel()
        {
            FileCommand = new RelayCommand(OnFile);
        }

        public void OnFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileSource.FileName = openFileDialog.FileName;
                Console.WriteLine(openFileDialog.FileName);
            }

        }

        public RelayCommand FileCommand { get; private set; }


    }
}
