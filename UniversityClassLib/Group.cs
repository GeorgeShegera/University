using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Group
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Year { get; set; }
        public GroupStatus Status { get; set; }
        public List<Student> Students { get; set; }
        public List<Class> Classes { get; set; }
        public Group(int id = default, string name = "", int year = 0,
                     GroupStatus status = GroupStatus.Active,
                     List<Student> students = default, List<Class> classes = default)
        {
            Id = id;
            Name = name;
            Year = year;
            Status = status;
            Students = students;
            Classes = classes;
        }
    }
}
