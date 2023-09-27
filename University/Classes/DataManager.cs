using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib;

namespace UniversityProject.Classes
{
    internal static class DataManager
    {
        internal const int universityId = 1;
        internal static readonly string connStr;

        static DataManager()
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

        internal static (User, string) AuthGetUser(string password, string login)
        {
            string query = "AuthGetUser";
            User user = null;
            string userType = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = query,
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@usernameEmail", login),
                    new SqlParameter("@password", password)
                });
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userType = Convert.ToString(reader["Type"]);
                        DateTime birthD = Convert.ToDateTime(reader["BirthDate"]);
                        user = new User(Convert.ToInt32(reader["Id"]))
                        {
                            Name = Convert.ToString(reader["Name"]),
                            Surname = Convert.ToString(reader["Surname"]),
                            BirthDate = new DateOnly(birthD.Year, birthD.Month, birthD.Day),
                            Username = Convert.ToString(reader["Username"]),
                            Password = password,
                            Email = Convert.ToString(reader["Email"]),
                        };
                    }
                }
                return (user, userType);
            }
        }

        internal static Rector GetRector(User user)
        {
            Rector rector = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                DateTime tenSt;
                string query = "RectorById";
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = query,
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter userId = new SqlParameter("@userId", user.Id);
                cmd.Parameters.Add(userId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tenSt = Convert.ToDateTime(reader["TenureStart"]);
                        rector = new Rector(user)
                        {
                            Status = (RectorStatus)Convert.ToInt32(reader["StatusId"]),
                            TenureStart = new DateOnly(tenSt.Year, tenSt.Month, tenSt.Day)
                        };
                    }
                }
            }
            return rector;
        }
    }
}
