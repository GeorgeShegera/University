using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Rector : User
    {
        public Rector(int id = default, string username = "", string password = "", string name = "",
             string surname = "", DateTime date = default, string email = "")
        : base(id, username, password, name, surname, date, email) { }
    }
}
