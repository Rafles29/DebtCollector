using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Models
{
    public class Adress: BindableBase
    {
        public Adress()
        {
            this.City = "Warszawa";
            this.PostCode = "00-000";
        }
        private string _city;
        public string City
        {
            get
            {
                return _city;
            } set
            {
                SetProperty(ref _city, value);
            }
        }
        private string _postCode;
        public string PostCode
        {
            get
            {
                return _postCode;
            }
            set
            {
                SetProperty(ref _postCode, value);
            }
        }
    }
}
