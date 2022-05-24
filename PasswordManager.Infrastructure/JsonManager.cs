using PasswordManager.Core;
using PasswordManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PasswordManager.Infrastructure
{
    public class JsonManager : IAccountManager
    {
        public List<Account> GetAccounts(string path = @"./passwords.json")
        {
            //TO-DO тут логика получения данных
            try
            {
                if(Directory.Exists(path)) throw new Exception("Invalid directory");
                List<Account> accounts;
                using (StreamReader sw = new StreamReader(path))
                {
                    accounts = JsonConvert.DeserializeObject<List<Account>>(sw.ReadToEnd());
                }
                return accounts;
                
            }
            catch (Exception ex)
            {
                return new List<Account>();
            }
        }
        // Saving accounts in file
        public bool SaveAccounts(List<Account> accounts, string path = @"./", string fileName = @"passwords.json")
        {
            try
            {
                Directory.CreateDirectory(path);
                var sortedAccounts = accounts.AsQueryable().OrderBy(acc => acc.Url);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                using (StreamWriter sw = new StreamWriter(path+fileName))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, sortedAccounts);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
