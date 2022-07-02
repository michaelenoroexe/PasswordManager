using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PasswordManager.Core.Models
{
    public record Account
    {
        public Account() { }
        public Account(int id, string url, string login, string password)
        {
            Id=id;
            Url=url;
            Login=login;
            Password=password;
            
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Login { get; set; } 
        public string Password { get; set; } 
        public List<string> Additional { get; set; }
        [JsonIgnore]
        public bool Changed { get; set; } = false;

        public override string ToString()
        {
            return $"{Url}/{Login}/{Password}";
        }
    }
}
