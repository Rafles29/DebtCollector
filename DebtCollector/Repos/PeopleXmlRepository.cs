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
        private List<Person> People;
        public string fileName { get; set; }

        public PeopleXmlRepository()
        {
            Seed();
            this.WriteXml();
        }
        public PeopleXmlRepository(string fileName)
        {
            this.fileName = fileName;
            this.People= ReadXml();
        }

        public void CreatePerson(Person person)
        {
            this.People.Add(person);
            this.WriteXml();
        }

        public IEnumerable<Person> GetPeople()
        {
            return this.People;
        }

        public Person GetPerson(string nickname)
        {
            return this.People.FirstOrDefault(p => p.Nickname == nickname);
        }

        public void UdpatePerson(Person updatedPerson)
        {
            var index = this.People.FindIndex(p => p.Nickname == updatedPerson.Nickname);
            this.People.RemoveAt(index);
            this.People.Insert(index, updatedPerson);
            this.WriteXml();
        }
        public void DeletePerson(string nickname)
        {
            var index = this.People.FindIndex(p => p.Nickname == nickname);
            this.People.RemoveAt(index);
            this.WriteXml();
        }
        private List<Person> ReadXml()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Person>));
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                List<Person> people = (List<Person>)reader.Deserialize(file);
                file.Close();
                return people;
            }
            catch
            {
                return new List<Person>();
            }

        }
        private void WriteXml()
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Person>));

            var path = this.fileName;
            if (path == null)
            {
                path = "people.xml";
                this.fileName = path;
            }
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this.People);
            file.Close();
        }
        private void Seed()
        {
            this.People = new List<Person>();
            this.People.Add(new Person()
            {
                Nickname = "Random",
                FirstName = "Rav",
                LastName ="Woz",
                Adress = new Adress()
                {
                    City = "Warszawa",
                    PostCode = "02-781"
                }
            });
            this.People.Add(new Person()
            {
                Nickname = "Random2",
                FirstName = "Rafa",
                LastName = "Wozn",
                Adress = new Adress()
                {
                    City = "Warszawa",
                    PostCode = "02-783"
                }
            });
        }
    }
}
