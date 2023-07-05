using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class User : Human
    {
        public int Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(int id, string username, string password, string name, string surname, DateTime date, string email)
            : base(name, surname, date)
        {
            Username = username;
            Password = password;
            Id = id;
            Email = email;
        }

        public User() : this(default, "", "", "", "", DateTime.Now, "") { }
    }
}
