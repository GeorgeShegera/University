using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Group
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public List<Student> Students { get; set; }
        public List<Class> Classes { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}
