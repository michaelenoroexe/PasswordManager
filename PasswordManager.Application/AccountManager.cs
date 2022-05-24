using PasswordManager.Core;
using PasswordManager.Core.Models;
using PasswordManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application
{
    // Class to work with application from UI
    public class AccountManager
    {
        private IAccountRepository _accountRepository;
        private IAccountManager _accountManager;

        //private readonly string directoryFolder = $"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)}\\PasswordManager";

        public AccountManager()
        {
            _accountManager = new JsonManager();
            //bool isNotExist = CreateDirectory();

            //if(!isNotExist)
            //    _accountRepository = new AccountRepository(_accountManager.GetAccounts(directoryFolder));

        }

        public AccountManager(IAccountRepository accounts) : this()
        { 
            _accountRepository = accounts;            
        }

        public IAccountRepository AccountRepository => _accountRepository;

        public async void SaveAsync()
        {
            string path = "./path";
            await _accountManager.SaveAccounts(_accountRepository.Accounts, path);
        }

        public List<Account> ImportFrom(IAccountManager accountManager ,string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException($"Ссылка на путь пуста");

            return accountManager.GetAccounts(path);
        }
        // Export all accounts in file
        public void Export(IAccountManager accountManager, string path)
        {           
            accountManager.SaveAccounts(_accountRepository.Accounts, path);
        }

        //private bool CreateDirectory()
        //{
        //    if (Directory.Exists(directoryFolder)) 
        //        return false;
            
        //    Directory.CreateDirectory(directoryFolder);

        //    return true;

        //}

    }
}
