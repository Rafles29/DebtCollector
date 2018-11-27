using DebtCollector.Debts;
using DebtCollector.Models;
using DebtCollector.People;
using DebtCollector.Repos;
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
        private AddEditPersonViewModel _addEditPersonViewModel = new AddEditPersonViewModel();

        private BindableBase _currentViewModel;

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            _personListViewModel.AddPersonRequested += NavToAddCustomer;
            _personListViewModel.EditPersonRequested += NavToAddEdit;
        }

        private void NavToAddEdit(Person person)
        {
            _addEditPersonViewModel.EditMode = true;
            _addEditPersonViewModel.SetPerson(person);
            CurrentViewModel = _addEditPersonViewModel;
        }

        private void NavToAddCustomer(Person person)
        {
            _addEditPersonViewModel.EditMode = false;
            _addEditPersonViewModel.SetPerson(person);
            CurrentViewModel = _addEditPersonViewModel;
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
                    this._personListViewModel.Repo = new PeopleXmlRepository("people.xml");
                    this._personListViewModel.GetPeople();
                    CurrentViewModel = _personListViewModel;
                    break;
                case "debts":
                    this._debtListViewModel.Repo = new DebtXmlReposiotry("debts.xml");
                    this._debtListViewModel.GetDebts();
                    CurrentViewModel = _debtListViewModel;
                    break;
            }
        }

    }
}
