using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Faculty
    {
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
        public List<Lecturer> Lecturers { get; set; }

        public Faculty(string name, List<Group> groups, List<Lecturer> lecturers)
        {
            Name = name;
            Groups = groups;
            Lecturers = lecturers;
        }
    }
}
