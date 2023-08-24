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
        public List<StudentTask> Tasks { get; set; }
        public StudentStatus Status { get; set; }

        public Student(int id = default, List<Mark> marks = default,
                       string username = default, string password = default,
                       string name = default, string surname = default,
                       DateTime date = default, string email = default,
                       List<StudentTask> tasks = default, StudentStatus status = default)
            : base(id, username, password, name, surname, date, email)
        {
            Marks = marks;
            Tasks = tasks;
            Status = status;
        }
        public Student(User user, List<Mark> marks = default,
                       List<StudentTask> task = default, StudentStatus status = default)
            : base(user)
        {
            Marks = marks;
            Tasks = task;
            Status = status;
        }
    }
}
