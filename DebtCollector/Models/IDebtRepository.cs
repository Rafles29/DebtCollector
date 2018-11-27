using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Models
{
    public interface IDebtRepository
    {
        void CreateDebt(Debt debt);
        Debt GetDebt(Guid id);
        IEnumerable<Debt> GetDebts();
        void UpdateDebt(Debt updatedDebt);
        void DeleteDebt(Guid id);
    }
}
