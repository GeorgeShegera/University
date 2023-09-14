using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib.Classes.GradeBookLib
{
    public class GradingCatigory
    {
        public int Id { get; private set; }
        public float MaxGrade { get; set; }
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }
    }
}
