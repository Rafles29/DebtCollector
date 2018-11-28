using DebtCollector.Models;
using DebtCollector.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            DeletDebtCommand = new RelayCommand<Guid>(OnDeleteDebt);

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

        private void OnDeleteDebt(Guid id)
        {
            if (MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Repo.DeleteDebt(id);
                this.GetDebts();
            }
        }

        public void GetDebts()
        {
            this.Debts = new ObservableCollection<Debt>(this._repo.GetDebts());
        }

        public RelayCommand AddDebtCommand { get; private set; }
        public RelayCommand<Debt> EditDebtCommand { get; private set; }
        public RelayCommand<Guid> DeletDebtCommand { get; private set; }

    }
}
