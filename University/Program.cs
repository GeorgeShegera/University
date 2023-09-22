﻿using System;
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

namespace UniversityProject
{
    internal static class Program
    {
        internal const int universityId = 1;
        internal static readonly string connStr;
        internal static readonly string encryptKey;

        static Program()
        {            
            string json;
            
            using (FileStream stream = new FileStream("connStr.json", FileMode.OpenOrCreate))
            {
                using (StreamReader read = new StreamReader(stream, Encoding.UTF8))
                {
                    json = read.ReadLine();
                }
            }
            connStr = JsonConvert.DeserializeObject<string>(json);
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
