
using NUnit.Framework;
using PasswordManager.Application;
using PasswordManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Test.Application
{
    internal class AccountRepositoryTest
    {
        private AccountRepository accountRepository;
        [SetUp]
        public void Setup()
        {
            accountRepository = new AccountRepository(new List<Account>()
            {
                new Account(0, "Some site", "den@gmail.com", "12345678"),
                new Account(1, "Some site", "den1@gmail.com", "12345678"),
                new Account(2, "Some site", "den2@gmail.com", "12345678"),
                new Account(3, "Some site", "den3@gmail.com", "12345678"),
                new Account(4, "Some site", "den4@gmail.com", "12345678")
            });
        }
        [TestCase(0)]
        [TestCase(4)]
        public void DeleCommand_ShouldReturnTrue(int id)
        {
            var result = accountRepository.Delete(id);

            Assert.IsTrue(result);
        }

        [TestCase(-1)]
        [TestCase(10)]
        public void DeleCommand_ShouldReturnFalse(int id)
        {
            var result = accountRepository.Delete(id);

            Assert.IsFalse(result);
        }

        [TestCase(5,"Some site", "den6@gmail.com", "12345678")]
        public void InsertCommand_ShouldReturnTrue(int id, string uri, string login, string password)
        {
            var accountEx = new Account(id, uri, login, password);

            var result = accountRepository.Insert(accountEx);

            Assert.IsTrue(result);
        }

        [Test]
        public void InsertCommand_ShouldReturnFalse()
        {
            Account? accountEx = null;

            var result = accountRepository.Insert(accountEx);
           
            Assert.IsFalse(result);
        }

        [Test]
        public void InsertRangeCommand_ShouldReturnTrue()
        {
            List<Account> listAccount = new List<Account>
            {
                new Account(5, "Some site", "den4@gmail.com", "12345678"),
                new Account(6, "Some site", "den4@gmail.com", "12345678")
            };

            var result = accountRepository.InsertRange(listAccount);

            Assert.IsTrue(result);
        }


        [Test]
        public void InsertRangeCommand_ShouldReturnFalse()
        {
            List<Account> listAccount = null;

            var result = accountRepository.InsertRange(listAccount);
            var result2 = accountRepository.InsertRange(new List<Account>());

            Assert.IsFalse(result);
            Assert.IsFalse(result2);
        }


        [TestCase(2, 5, "Some site", "den6@gmail.com", "12345678")]
        public void UpdateCommand_ShouldReturnTrue(int oldId, int id, string uri, string login, string password)
        {
            var accountEx = new Account(id, uri, login, password);

            var result = accountRepository.Update(oldId, accountEx);

            Assert.IsTrue(result);
        }

        [TestCase(2, 5, "Some site", "den6@gmail.com", "12345678")]
        public void UpdateCommand_MustUpdateAnExistingEntry(int oldId, int id, string uri, string login, string password)
        {
            var accountEx = new Account(id, uri, login, password);

            var result = accountRepository.Update(oldId, accountEx);

            Assert.AreEqual(accountRepository.Accounts.Where(x => x.Id == oldId).First().Login, accountEx.Login);
        }

        [TestCase(7, 5, "Some site", "den6@gmail.com", "12345678")]
        public void UpdateCommand_ShouldReturnFalse(int oldId, int id, string uri, string login, string password)
        {
            var accountEx = new Account(id, uri, login, password);

            var result = accountRepository.Update(oldId, accountEx);

            Assert.IsFalse(result);
        }


    }
}
