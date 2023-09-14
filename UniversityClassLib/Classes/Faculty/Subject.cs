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
        public int LecturerId { get; set; }
        public Subject(int id = default, string name = "", int lecturerId = 0)
        {
            Id = id;
            Name = name;
            LecturerId = lecturerId;
        }
    }
}
