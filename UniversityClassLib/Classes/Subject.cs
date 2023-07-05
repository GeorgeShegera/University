using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Subject
    {
        public int Id { get; }
        public string Name { get; set; }
        public float PassMark { get; set; }
        public Lecturer Lecturer { get; set; }

        public Subject(int id = default, string name = "", float passMark = 60, Lecturer lecturer = default)
        {
            Id = id;
            Name = name;
            PassMark = passMark;
            Lecturer = lecturer;
        }
    }
}
