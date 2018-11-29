using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Models
{
    public class FileXML: BindableBase
    {
        private string _fileName;
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                SetProperty(ref _fileName, value);
            }
        }
    }
}
