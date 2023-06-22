using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class University
    {
        public string Name { get; set; }
        public Rector Rector { get; }
        public List<Faculty> Faculties { get; set; }
    }
}
