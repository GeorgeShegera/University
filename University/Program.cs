using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using UniversityClassLib;
using System.Data;
using UniversityClassLib.Enums;
using System.Web.Security;

namespace UniversityProject
{
    internal static class Program
    {
        internal const int universityId = 1;
        internal const string connStr = @"Server=GEORGE;
                                                  Database=University;
                                                  Trusted_Connection=True;";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
