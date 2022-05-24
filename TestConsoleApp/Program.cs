using PasswordManager.Core;
using PasswordManager.Infrastructure;
using PasswordManager.Application;

//builder = new AccountBuilder();
//builder.CreateManager().AddNewRepository().FromJson(path);
//accountManager = builder.Build();


var accountManager = new AccountManager(new AccountRepository(new JsonManager().GetAccounts("/path")));
Console.WriteLine("test");


accountManager.SaveAsync();

