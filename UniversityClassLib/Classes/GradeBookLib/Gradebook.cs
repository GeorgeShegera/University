using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib.Classes.GradeBookLib
{
    public class Gradebook
    {
        public int Id { get; private set; }
        public int GroupId { get; set; }
        public List<GradingCatigory> Catigorirs { get; set; }
        public int LecturerId { get; set; }
        public int SubjectId { get; set; }

    }
}
