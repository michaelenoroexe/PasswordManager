using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using PasswordManager.Application;
using PasswordManager.Core.Models;
using PasswordManager.Infrastructure;

namespace PasswordManager.Test.Infrastructure
{
    internal class JsonManagerTest
    {
        private JsonManager _jsonManager;
        private List<Account> _accounts;
        [SetUp]
        public void Setup()
        {
            _jsonManager = new JsonManager();
            _accounts = new List<Account>
            {
                new Account(1,"https://www.youtube.com/","denis","dnis"),
                new Account(2,"https://www.facebook.com/","den","deis"),
                new Account(3,"https://www.Artur.com/","dis","dens"),
                new Account(4,"https://www.Abreviatur.com/","dens","dens"),
                new Account(5,"https://www.rambler.com/","dnis","deis"),
                new Account(6,"https://www.artu.com/","den","dnis"),
                new Account(7,"https://www.rook.com/","denis","dens"),
                new Account(8,"https://www.cooking.com/","denis","dis"),
                new Account(9,"https://www.bart.com/","denis","deis"),
            };       
        }

        [Test]
        public async Task SaveAccounts()
        {
            Assert.IsTrue(await _jsonManager.SaveAccounts(_accounts));
        }
    }
}
