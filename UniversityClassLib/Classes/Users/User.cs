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

        public User(int id = default, string username = default,
                    string password = default, string name = default,
                    string surname = default, DateTime date = default,
                    string email = default)
            : base(name, surname, date)
        {
            Username = username;
            Password = password;
            Id = id;
            Email = email;
        }
        public User(User user)
            : base(user.Name, user.Surname, user.BirthDate)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }
    }
}
