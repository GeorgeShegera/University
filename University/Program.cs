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
            using (FileStream stream = new FileStream("encryptKey.json", FileMode.OpenOrCreate))
            {
                using (StreamReader read = new StreamReader(stream, Encoding.UTF8))
                {
                    json = read.ReadLine();
                }
            }
            encryptKey = JsonConvert.DeserializeObject<string>(json);

            json = "";
            using (FileStream stream = new FileStream("connStr.json", FileMode.OpenOrCreate))
            {
                using (StreamReader read = new StreamReader(stream, Encoding.UTF8))
                {
                    while (!read.EndOfStream) json += read.ReadLine();
                }
            }
            connStr = JsonConvert.DeserializeObject<string>(json);
        }

        public static string Encrypt(string source, string key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Encoding.UTF8.GetBytes(source);

            string encoded =
                Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return encoded;
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
