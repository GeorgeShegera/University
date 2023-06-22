using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class User : Human
    {        
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password, string name, string surname, DateTime date)
            : base(name, surname, date)
        {
            Username = username;
            Password = password;
        }

        public User() : this("", "", "", "", DateTime.Now) { }
    }
}
