using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UniversityClassLib
{
    public class Lecturer : User
    {
        public string ScientificDegree { get; set; }
        public string AcademicStatus { get; set; }
        public string ScientificIdentifiers { get; set; }
        public LecturerStatus Status { get; set; }
        public List<Subject> Subjects { get; set; }

        public Lecturer(int id = default, string scienDegree = default,
                        string academStatus = default, string username = default,
                        string password = default, string name = default,
                        string surname = default, DateTime date = default,
                        string scienIdent = default,
                        string email = default, LecturerStatus status = default)
            : base(id, username, password, name, surname, date, email)
        {
            ScientificDegree = scienDegree;
            AcademicStatus = academStatus;
            ScientificIdentifiers = scienIdent;
            Status = status;
        }
        public Lecturer(User user, string scienIdent = default,
                        string scienDegree = default, LecturerStatus status = default,
                        string academStatus = default, List<Subject> subjects = default)
            : base(user)
        {
            ScientificDegree = scienDegree;
            AcademicStatus = academStatus;
            ScientificIdentifiers = scienIdent;
            Status = status;
            Subjects = subjects;
        }
    }
}
