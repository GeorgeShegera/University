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

        public int UniversityId { get; set; }

        public Faculty(int id = default, string name = "", int universityId = default)
        {
            Id = id;
            Name = name;
            UniversityId = universityId;
        }
    }
}
