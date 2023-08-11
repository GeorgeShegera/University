using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class University
    {
        public int Id { get; }
        public string Name { get; set; }
        public Rector Rector { get; private set; }
        public List<Faculty> Faculties { get; set; }

        public University(int id = default, string name = "", Rector rector = default, List<Faculty> faculties = default)
        {
            Id = id;
            Name = name;
            Rector = rector;
            Faculties = faculties;
        }
    }
}
