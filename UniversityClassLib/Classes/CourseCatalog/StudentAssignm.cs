using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib.Enums;

namespace UniversityClassLib.Classes.CourseCatalog
{
    public class StudentAssignm
    {
        public int Id { get; private set; }
        public float Grade { get; set; }
        public int StudentId { get; set; }
        public AssignmStatus Status { get; set; }
    }
}
