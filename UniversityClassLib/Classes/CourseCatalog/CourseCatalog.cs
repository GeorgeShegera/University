using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib.Classes.CourseCatalog
{
    public class CourseCatalog
    {
        public int Id { get; private set; }
        public List<Course> Courses { get; private set; }        
    }
}
