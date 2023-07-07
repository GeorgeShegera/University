using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Faculty
    {
        public int Id { get; }
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
        public List<Lecturer> Lecturers { get; set; }

        public Faculty(int id = default, string name = "", List<Group> groups = null, List<Lecturer> lecturers = null)
        {
            Id = id;
            Name = name;
            Groups = groups;
            Lecturers = lecturers;
        }
    }
}
