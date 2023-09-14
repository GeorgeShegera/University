using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib.Classes.Shedule
{
    public class Schedule
    {
        public int Id { get; private set; }
        public List<Class> Classes { get; set; }
        public Schedule(int id = default, List<Class> classes = default)
        {
            Id = id;
            Classes = classes;
        }
    }
}
