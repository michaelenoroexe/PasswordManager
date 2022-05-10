using NUnit.Framework;
using PasswordManager.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Test.Application
{
    internal class AccountManagerTest
    {
        [Test]
        public void CreateDirectory_ShouldReturnFalse()
        {
            var pm = new AccountManager();

            var method = typeof(AccountManager).GetMethod(("CreateDirectory"),
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var result = (bool)method?.Invoke(pm, null);

            Assert.IsFalse(result);
        }
    }
}
