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
    public class AccountRepository : IAccountRepository
    {
        private List<Account> _accounts;
        public AccountRepository(IAccountManager accountManager)
        {
            _accounts = accountManager.GetAccounts();
        }      
        public List<Account> Accounts => _accounts;

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Account account)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Account account)
        {
            throw new NotImplementedException();
        }
    }
}
