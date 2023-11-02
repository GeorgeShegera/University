using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Rector : User
    {
        public RectorStatus Status { get; set; }
        public DateOnly TenureStart { get; set; }

        public Rector(int id = default, string username = "",
                      string password = "", string name = "",
                      string surname = "", DateOnly date = default, string email = "",
                      RectorStatus status = default, DateOnly tenureStart = default)
                : base(id, username, password, name, surname, date, email)
        {
            Status = status;
            TenureStart = tenureStart;
        }

        public Rector(User user, RectorStatus status = default,
                      DateOnly tenureStart = default)
                : base(user)
        {
            Status = status;
            TenureStart = tenureStart;
        }
    }
}
