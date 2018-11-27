using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtCollector.Models;

namespace DebtCollector.FileSource
{
    class EditFileSourceViewModel: BindableBase
    {
        private DebtCollector.Models.FileXML _fileSource = new FileXML() { FileName="debts.xml", DateTime=DateTime.Now};

        public DebtCollector.Models.FileXML FileSource
        {
            get { return _fileSource; }
            set { SetProperty(ref _fileSource, value); }
        }


    }
}
