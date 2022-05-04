using PasswordManager.Core;
using PasswordManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Infrastructure
{
    public class JsonManager : IAccountManager
    {
        public List<Account> GetAccounts()
        {
            //TO-DO тут логика получения данных
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAccounts(List<Account> accounts)
        {
            return true;
        }
    }
}
