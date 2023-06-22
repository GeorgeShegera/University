using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Subject
    {       
        public string Name { get; set; }
        public float PassMark { get; set; }
        public Lecturer Lecturer { get; set; }

        public Subject(string name, float passMark, Lecturer lecturer)
        {            
            Name = name;
            PassMark = passMark;
            Lecturer = lecturer;
        }
    }
}
