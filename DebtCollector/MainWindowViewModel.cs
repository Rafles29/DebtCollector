using DebtCollector.Debts;
using DebtCollector.People;
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
        private PeopleListViewModel _personListViewModel = new PeopleListViewModel();

        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
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
                case "people":
                    CurrentViewModel = _personListViewModel;
                    break;
                case "debts":
                    CurrentViewModel = _debtListViewModel;
                    break;
            }
        }

    }
}
