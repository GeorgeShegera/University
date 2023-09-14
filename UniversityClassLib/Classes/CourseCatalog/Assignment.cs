using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib.Classes.CourseCatalog
{
    public class Assignment
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime Publication { get; set; }
        public float MaxPoints { get; set; }
        public int LecturerId { get; set; }
        public List<StudentAssignm> StudentAssign { get; set; }
    }
}
