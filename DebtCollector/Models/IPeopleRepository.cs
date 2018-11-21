using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Models
{
    public interface IPeopleRepository
    {
        void CreatePerson(Person person);
        Person GetPerson(string nickname);
        IEnumerable<Person> GetPeople();
        void UdpatePerson(Person updatedPerson);
        void DeletePerson(string nickname);
    }
}
