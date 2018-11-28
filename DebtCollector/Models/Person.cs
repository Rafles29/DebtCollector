using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Models
{
    public class Person: BindableBase
    {
        public Person()
        {
            this.Nickname = "";
            this.FirstName = "";
            this.LastName = "";
            this.Adress = new Adress();

        }

        private string _nickname;
        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                SetProperty(ref _nickname, value);
            }
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                SetProperty(ref _firstName, value);
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                SetProperty(ref _lastName, value);
            }
        }
        private Adress _adress;
        public Adress Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                SetProperty(ref _adress, value);
            }
        }
    }
}
