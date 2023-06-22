using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Student : User
    {
        public List<Mark> Marks { get; set; }

        public Student(List<Mark> marks, string username, string password, string name,
                      string surname, DateTime date)
            : base(username, password, name, surname, date)
        {
            Marks = marks;
        }
    }
}
