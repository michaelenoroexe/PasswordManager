using PasswordManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core
{
    public interface IAccountManager
    {
        public List<Account> GetAccounts(string path);
        public bool SaveAccounts(List<Account> accounts, string path=@"./", string fileName=@"passwords.json");
    }
}
