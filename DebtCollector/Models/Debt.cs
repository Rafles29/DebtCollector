using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Models
{
    public class Debt
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Amount { get; set; }
        public string Deptor { get; set; }
    }
}
