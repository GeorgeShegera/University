using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib.Classes.GradeBookLib
{
    public class GradebookLibrary
    {
        public int Id { get; private set; }
        public List<Gradebook> Gradebooks { get; set; }
    }
}
