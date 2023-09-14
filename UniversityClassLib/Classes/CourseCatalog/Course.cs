using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib.Classes.CourseCatalog;

namespace UniversityClassLib
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public List<int> GroupIDs { get; private set; }
        public List<int> LecturerIDs { get; set; }
        public int SubjectId { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
