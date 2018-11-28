using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Models
{
    public class Debt: BindableBase
    {
        public Debt()
        {
            this.Id = Guid.NewGuid();
            this.Start = DateTime.Now;
            this.Start = DateTime.Now.AddDays(1);
            this.Amount = 0;
            this.Deptor = new Person();
        }

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                SetProperty(ref _id, value);
            }
        }
        private DateTime _start;
        public DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                SetProperty(ref _start, value);
            }
        }
        private DateTime _end;
        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                SetProperty(ref _end, value);
            }
        }
        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                SetProperty(ref _amount, value);
            }
        }
        public Person Deptor { get; set; }
    }
}
