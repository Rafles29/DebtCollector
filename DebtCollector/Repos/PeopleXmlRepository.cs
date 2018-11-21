using DebtCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Repos
{
    class PeopleXmlRepository : IPeopleRepository
    {
        public void CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(string nickname)
        {
            throw new NotImplementedException();
        }

        public void UdpatePerson(Person updatedPerson)
        {
            throw new NotImplementedException();
        }
        public void DeletePerson(string nickname)
        {
            throw new NotImplementedException();
        }
    }
}
