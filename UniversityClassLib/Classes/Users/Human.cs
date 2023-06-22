using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateTime { get; set; }

        public Human(string name, string surname, DateTime date)
        {
            Name = name;
            Surname = surname;
            DateTime = date;
        }

        public Human() : this("", "", DateTime.Now) { }
    }
}
