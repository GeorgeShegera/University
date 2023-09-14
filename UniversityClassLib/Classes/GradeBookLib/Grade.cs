using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib.Classes.GradeBookLib
{
    public class Grade
    {
        public int Id { get; private set; }
        public float Value { get; set; }
        public int StudentId { get; set; }
    }
}
