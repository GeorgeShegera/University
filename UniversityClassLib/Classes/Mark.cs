using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Mark
    {
        public int Id {  get; set; }
        public float Value { get; set; }
        public Subject Subject { get; set; }
        public Mark(int id = default, float value = 0, Subject subject = default)
        {
            Id = id;
            Value = value;
            Subject = subject;
        }
    }
}
