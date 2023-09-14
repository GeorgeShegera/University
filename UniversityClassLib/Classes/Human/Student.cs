using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Student : User
    {
        public DateOnly EnrollmentDate { get; set; }
        public StudentStatus Status { get; set; }

        public Student(int id = default, string username = default,
                       string password = default, string name = default,
                       string surname = default, DateOnly date = default,
                       string email = default, StudentStatus status = default,
                       DateOnly enDate = default)
            : base(id, username, password, name, surname, date, email)
        {
            Status = status;
            EnrollmentDate = enDate;
        }
        public Student(User user, StudentStatus status = default)
            : base(user)
        {
            Status = status;
        }
    }
}
