using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Mark
    {
        public float Value { get; set; }
        public Subject Subject { get; set; }
        public Mark(float value, Subject subject)
        {
            Value = value;
            Subject = subject;
        }
    }
}
