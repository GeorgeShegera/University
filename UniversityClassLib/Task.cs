using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib.Enums;

namespace UniversityClassLib
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime PublicationDate { get; set; }
        public Subject Subject { get; set; }
        public int Points { get; set; }
        public int Rated { get; set; }
        public Student AssignedStudent { get; set; }
    }
}
