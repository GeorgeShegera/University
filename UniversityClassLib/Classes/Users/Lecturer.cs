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

        public Lecturer(string scientificDegree, string academicStatus, string username,
            string password, string name, string surname, DateTime date, string scientificIdentifiers)
            : base(username, password, name, surname, date)
        {
            ScientificDegree = scientificDegree;
            AcademicStatus = academicStatus;
            ScientificIdentifiers = scientificIdentifiers;
        }
    }
}
