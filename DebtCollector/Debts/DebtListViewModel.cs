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

        public DebtListViewModel()
        {
            AddDebtCommand = new RelayCommand(OnAddDebt);
            EditDebtCommand = new RelayCommand<Debt>(OnEditDebt);
        }

        public event Action<Debt> AddDebtRequested = delegate { };
        public event Action<Debt> EditDebtRequested = delegate { };

        private void OnEditDebt(Debt debt)
        {
            EditDebtRequested(debt);
        }

        private void OnAddDebt()
        {
            AddDebtRequested(new Debt());
        }

        public void GetDebts()
        {
            this.Debts = new ObservableCollection<Debt>(this._repo.GetDebts());
        }

        public RelayCommand AddDebtCommand { get; private set; }
        public RelayCommand<Debt> EditDebtCommand { get; private set; }

    }
}
