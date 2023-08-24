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

        public Subject(int id = default, string name = "")
        {
            Id = id;
            Name = name;            
        }
    }
}
