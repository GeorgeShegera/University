using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib;

namespace University.DataBase
{
    public sealed class DataBaseLoader
    {
        private const int universityId = 1;
        private const string connectionString = @"Server=GEORGE;
                                                  Database=University;
                                                  Trusted_Connection=True;";
        private DataBaseLoader() { }
        public List<Subject> LoadSubjects()
        {
            return new List<Subject>();
        }
    }
}
