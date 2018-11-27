using DebtCollector.Models;
using DebtCollector.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DebtCollector.People
{
    class PeopleListViewModel :BindableBase
    {
        private IPeopleRepository _repo;
        public IPeopleRepository Repo
        {
            get { return _repo; }
            set
            {
                SetProperty(ref _repo, value);
            }
        }

        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public PeopleListViewModel()
        {
            AddPersonCommand = new RelayCommand(OnAddPerson);
            EditPersonCommand = new RelayCommand<Person>(OnEditPerson);
        }

        public event Action<Person> AddPersonRequested = delegate { };
        public event Action<Person> EditPersonRequested = delegate { };

        private void OnEditPerson(Person person)
        {
            EditPersonRequested(person);
        }

        private void OnAddPerson()
        {
            AddPersonRequested(new Person());
        }

        public void GetPeople()
        {
            this.People = new ObservableCollection<Person>(this._repo.GetPeople());
        }

        public RelayCommand AddPersonCommand { get; private set; }
        public RelayCommand<Person> EditPersonCommand { get; private set; }

    }
}
