using PasswordManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core
{
    public interface IAccountRepository
    {
        public List<Account> Accounts { get;}
        public bool Insert(Account account);
        public bool Update(int id, Account account);
        public bool Delete(int id);
    }
}
