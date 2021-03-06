﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtCollector.Models;

namespace DebtCollector.Repos
{
    class DebtXmlReposiotry : IDebtRepository
    {
        private List<Debt> Debts;
        public string fileName { get; set; }

        public DebtXmlReposiotry()
        {
            Seed();
            this.WriteXml();
        }
        public DebtXmlReposiotry(string fileName)
        {
            this.fileName = fileName;
            this.Debts = ReadXml();
        }
        public void CreateDebt(Debt debt)
        {
            this.Debts.Add(debt);
            this.WriteXml();
        }

        public void DeleteDebt(Guid id)
        {
            var index = this.Debts.FindIndex(d => d.Id == id);
            this.Debts.RemoveAt(index);
            this.WriteXml();
        }

        public Debt GetDebt(Guid id)
        {           
            return this.Debts.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Debt> GetDebts()
        {
            return this.Debts;
        }

        public void UpdateDebt(Debt updatedDebt)
        {
            var index = this.Debts.FindIndex(d => d.Id == updatedDebt.Id);
            this.Debts.RemoveAt(index);
            this.Debts.Insert(index, updatedDebt);
            this.WriteXml();
            
        }
        private List<Debt> ReadXml()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Debt>));
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                List<Debt> debts = (List<Debt>)reader.Deserialize(file);
                file.Close();
                return debts;
            }
            catch
            {
                return new List<Debt>();
            }
            
        }
        private void WriteXml()
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(List<Debt>));

            var path = this.fileName;
            if(path == null)
            {
                path = "debts.xml";
                this.fileName = path;
            }
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this.Debts);
            file.Close();
        }
        private void Seed()
        {
            this.Debts = new List<Debt>();
            this.Debts.Add(new Debt()
            {
                Id = Guid.NewGuid(),
                Start = DateTime.Now,
                End = DateTime.Now.AddMonths(1),
                Amount = 1000,
                Deptor = new Person()
                {
                    Nickname = "Random",
                    FirstName = "Rav",
                    LastName = "Woz",
                    Adress = new Adress()
                    {
                        City = "Warszawa",
                        PostCode = "02-781"
                    }
                }
            });
            this.Debts.Add(new Debt()
            {
                Id = Guid.NewGuid(),
                Start = DateTime.Now,
                End = DateTime.Now.AddMonths(2),
                Amount = 2000,
                Deptor = new Person()
                {
                    Nickname = "Random2",
                    FirstName = "Rafa",
                    LastName = "Wozn",
                    Adress = new Adress()
                    {
                        City = "Warszawa",
                        PostCode = "02-783"
                    }
                }
            });
        }
    }
}
