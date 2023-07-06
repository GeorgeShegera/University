using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib;

namespace University.Structs
{
    internal struct StudentMark
    {
        public Mark markValue;
        public int studentId;
        public StudentMark(int studentId, Mark mark)
        {
            this.studentId = studentId;
            this.markValue = mark;
        }
    }
}
