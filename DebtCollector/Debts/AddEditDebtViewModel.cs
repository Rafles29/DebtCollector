﻿using DebtCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DebtCollector.Debts
{
    class AddEditDebtViewModel: BindableBase
    {
        private IDebtRepository _repo;
        public IDebtRepository Repo
        {
            get { return _repo; }
            set
            {
                SetProperty(ref _repo, value);
            }
        }

        public AddEditDebtViewModel()
        {
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave);
        }



        public event Action Done = delegate { };

        private bool _EditMode;
        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }

        private Debt _debt = null;
        public Debt Debt
        {
            get
            {
                return _debt;
            }
            set
            {
                SetProperty(ref _debt, value);
            }
        }

        public RelayCommand CancelCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        private void OnCancel()
        {
            Done();
        }
        private void OnSave()
        {
            if(EditMode)
            {
                if(MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
                {
                    this.Repo.UpdateDebt(this.Debt);
                    Done();
                }
                
            }
            else
            {
                if (MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    this.Repo.CreateDebt(this.Debt);
                    Done();
                }
            }
            
        }
    }
}
