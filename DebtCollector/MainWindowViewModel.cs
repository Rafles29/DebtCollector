using DebtCollector.Debts;
using DebtCollector.Models;
using DebtCollector.People;
using DebtCollector.Repos;
using DebtCollector.FileSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollector
{
    class MainWindowViewModel :BindableBase
    {
        private DebtListViewModel _debtListViewModel = new DebtListViewModel();
        private AddEditDebtViewModel _addEditDebtViewModel = new AddEditDebtViewModel();
        private EditFileSourceViewModel _editFileSourceViewModel = new EditFileSourceViewModel();

        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            _currentViewModel = _editFileSourceViewModel;
            NavCommand = new RelayCommand<string>(OnNav);
            _debtListViewModel.AddDebtRequested += NavToAddDebt;
            _debtListViewModel.EditDebtRequested += NavToEditDebt;
            _addEditDebtViewModel.Done += NavToDebtList;
        }

        private void NavToDebtList()
        {
            this._debtListViewModel.Repo = new DebtXmlReposiotry(this._editFileSourceViewModel.FileSource.FileName);
            this._debtListViewModel.GetDebts();
            CurrentViewModel = _debtListViewModel;
        }

        private void NavToEditDebt(Debt debt)
        {
            _addEditDebtViewModel.EditMode = true;
            _addEditDebtViewModel.Debt = debt;
            _addEditDebtViewModel.Repo = new DebtXmlReposiotry(this._editFileSourceViewModel.FileSource.FileName);
            CurrentViewModel = _addEditDebtViewModel;
        }

        private void NavToAddDebt(Debt debt)
        {
            _addEditDebtViewModel.EditMode = false;
            _addEditDebtViewModel.Debt = debt;
            _addEditDebtViewModel.Repo = new DebtXmlReposiotry(this._editFileSourceViewModel.FileSource.FileName);
            CurrentViewModel = _addEditDebtViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "file":
                    CurrentViewModel = _editFileSourceViewModel;
                    break;
                case "debts":
                    this._debtListViewModel.Repo = new DebtXmlReposiotry(this._editFileSourceViewModel.FileSource.FileName);
                    this._debtListViewModel.GetDebts();
                    CurrentViewModel = _debtListViewModel;
                    break;
            }
        }

    }
}
