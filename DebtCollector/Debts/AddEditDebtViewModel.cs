using DebtCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Debts
{
    class AddEditDebtViewModel: BindableBase
    {
        private bool _EditMode;
        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private Debt _debt = null;
        public void SetDebt(Debt debt)
        {
            _debt = debt;
        }
    }
}
