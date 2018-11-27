using DebtCollector.Models;
using DebtCollector.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector.Debts
{
    class DebtListViewModel: BindableBase
    {
        private IDebtRepository _repo;
        public IDebtRepository Repo
        {
            get { return _repo; }
            set {
                SetProperty(ref _repo, value);
            }
        }

        private ObservableCollection<Debt> _debts;
        public ObservableCollection<Debt> Debts
        {
            get { return _debts; }
            set { SetProperty(ref _debts, value); }
        }

        public void GetDebts()
        {
            this.Debts = new ObservableCollection<Debt>(this._repo.GetDebts());
        }

    }
}
