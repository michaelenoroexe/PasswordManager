using PasswordManager.Core;
using PasswordManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PasswordManager.Application
{
    // Class to work with accounts buffer
    public class AccountRepository : IAccountRepository
    {
        private List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new List<Account>();
        }

        public AccountRepository(List<Account> accounts)
        {          
            _accounts = accounts;   
        }      
        public List<Account> Accounts => _accounts;

        public bool Delete(int id)
        {
            var account = _accounts.Where(account => account.Id == id).FirstOrDefault();

            if (account is not null)
            {
                _accounts.Remove(account);
                return true;
            }
            return false;
        }

        public bool Insert(Account account)
        {
            if(account is not null)
            {
                _accounts.Add(account);
                return true;
            }
            return false;
        }

        public bool InsertRange(IEnumerable<Account> accounts)
        {
            if(accounts is not null && accounts.Count() > 0)
            {
                _accounts.AddRange(accounts);
                return true;
            }
            return false;
        }

        public bool Update(int id, Account account)
        {
            var needAccount = _accounts.Where(account => account.Id == id).FirstOrDefault();
            if (account is not null && needAccount is not null)
            {
                Delete(needAccount.Id);

                account.Id = id;
                _accounts.Add(account);
                return true;
            }
            return false;
        }
    }
}
