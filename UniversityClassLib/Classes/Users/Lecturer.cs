using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Lecturer : User
    {
        public string ScientificDegree { get; set; }
        public string AcademicStatus { get; set; }
        public string ScientificIdentifiers { get; set; }

        public Lecturer(int id, string scientificDegree, string academicStatus, string username,
            string password, string name, string surname, DateTime date, string scientificIdentifiers, string email)
            : base(id, username, password, name, surname, date, email)
        {
            ScientificDegree = scientificDegree;
            AcademicStatus = academicStatus;
            ScientificIdentifiers = scientificIdentifiers;
        }
        public Lecturer() : this(default, "", "", "", "", "", "", default, "", null) { }
        public Lecturer(int id) : this(id, "", "", "", "", "", "", default, "", null) { }
    }
}
