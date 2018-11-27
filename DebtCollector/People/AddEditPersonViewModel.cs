using DebtCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.People
{
    class AddEditPersonViewModel: BindableBase
    {
        private bool _EditMode;
        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private Person _person = null;
        public void SetPerson(Person person)
        {
            _person = person;
        }
    }
}
