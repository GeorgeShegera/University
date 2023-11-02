using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using UniversityClassLib;
using System.Data;
using UniversityClassLib.Enums;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.IO.Ports;
using UniversityProject.Classes;
using System.Runtime.CompilerServices;

namespace UniversityProject
{
    internal static class Program
    {
        public static DateTime ToDateTime(this DateOnly dateOnly)
        {
            return new DateTime(dateOnly.Year, dateOnly.Month, dateOnly.Day);
        }

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
