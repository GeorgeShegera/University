using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Student : User
    {
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public List<Task> Tasks { get; set; }
        public StudentStatus Status { get; set; }

        public Student(int id, List<Mark> marks, string username, string password,
                       string name, string surname, DateTime date,
                       string email, List<Task> tasks)
            : base(id, username, password, name, surname, date, email)
        {
            Marks = marks;
            Tasks = tasks;
        }

        public Student() : this(default, new List<Mark>(), "", "",
                                "", "", DateTime.Now, "", default)
        { }

        public Student(int id) : this(id, new List<Mark>(), "", "",
                                      "", "", DateTime.Now, "", default)
        { }
    }
}
