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
        public string Email { get; set; }

        public User(int id = default, string username = default,
                    string password = default, string name = default,
                    string surname = default, DateOnly date = default,
                    string email = default)
            : base(id, name, surname, date)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        public User(User user)
            : base(user)
        {
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }
    }
}
