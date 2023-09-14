using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClassLib
{
    public class Human
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }

        public Human(int id, string name, string surname, DateOnly date)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = date;
        }

        public Human() : this(default, "", "", default) { }
        public Human(Human human) : this(human.Id, human.Name, human.Surname, human.BirthDate) { }
    }
}
