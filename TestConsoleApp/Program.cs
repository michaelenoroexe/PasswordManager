using PasswordManager.Core;
using PasswordManager.Core.Models;
using PasswordManager.Infrastructure;
using PasswordManager.Application;

//builder = new AccountBuilder();
//builder.CreateManager().AddNewRepository().FromJson(path);
//accountManager = builder.Build();


var accountManager = new AccountManager(new AccountRepository(new JsonManager().GetAccounts("/path")));
var accounts = new List<Account>
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
                new Account(10,"https://www.youtube.com/","disds","ddffd"),
            };
accountManager.AccountRepository.InsertRange(accounts);

accountManager.Save();

