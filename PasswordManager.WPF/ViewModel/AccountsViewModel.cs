using PasswordManager.Core.Models;
using PasswordManager.WPF.Common.Base;
using PasswordManager.WPF.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WPF.ViewModel
{
    public class AccountsViewModel : ObservableObject, IViewModel
    {
        public AccountsViewModel()
        {
            var accs = new List<Account> {
                new Account {Id=1, Url="https://www.youtube.com/", Login="denis", Password="dnis" },
                new Account {Id=2, Url="https://www.facebook.com/", Login="den", Password="deis" },
                new Account {Id=3, Url="https://www.artur.com/", Login="dis", Password="dens" },
                new Account {Id=4, Url="https://www.abreviatur.com/", Login="dens", Password="dens"},
                new Account {Id=5, Url="https://www.youtube.com/", Login="denis", Password="dnis" },
                new Account {Id=6, Url="https://www.facebook.com/", Login="den", Password="deis" },
                new Account {Id=7, Url="https://www.artur.com/", Login="dis", Password="dens" },
                new Account {Id=8, Url="https://www.abreviatur.com/", Login="dens", Password="dens"}
            }.Select(ar => new Account(ar.Id, new Uri(ar.Url).Host, ar.Login, ar.Password)).ToList();
           
            Accounts = new ObservableCollection<Account>(accs);

        }

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = _accounts.Where(a => a.Id == value.Id).Single();
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts { get; set; }
        public RelayCommand ListBoxLeftClick { get; set; }


    }
}
