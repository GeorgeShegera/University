using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib.Classes.CourseCatalog;
using UniversityClassLib.Classes.GradeBookLib;
using UniversityClassLib.Classes.Shedule;

namespace UniversityClassLib
{
    public class University
    {
        public int Id { get; }
        public string Name { get; set; }
        public Schedule Schedule { get; set; }
        public Rector Rector { get; private set; }
        public List<Faculty> Faculties { get; set; }
        public GradebookLibrary GradebookLib { get; set; }
        public CourseCatalog CourseCatalog { get; set; }


        public University(int id = default, string name = "", Rector rector = default, List<Faculty> faculties = default)
        {
            Id = id;
            Name = name;
            Rector = rector;
            Faculties = faculties;
        }
    }
}
