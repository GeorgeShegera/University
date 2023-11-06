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
using System.Threading;
using System.Web;
using System.Xml.Serialization;

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
                        user = new User(Convert.ToInt32(reader["Id"]))
                        {
                            Name = Convert.ToString(reader["Name"]),
                            Surname = Convert.ToString(reader["Surname"]),
                            BirthDate = DateOnly.FromDateTime(Convert.ToDateTime(reader["BirthDate"])),
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

        internal static void UpdateRectorData(Rector rector)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "UpdateRectorData";
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = query,
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@id", rector.Id),
                    new SqlParameter("@name", rector.Name),
                    new SqlParameter("@surname", rector.Surname),
                    new SqlParameter("@birthDate", rector.BirthDate.ToDateTime()),
                    new SqlParameter("@username", rector.Username),
                    new SqlParameter("@password", rector.Password),
                    new SqlParameter("@email", rector.Email),
                    new SqlParameter("@statusId", Convert.ToInt32(rector.Status)),
                    new SqlParameter("@tenureStart", rector.TenureStart.ToDateTime())
                });
                cmd.ExecuteNonQuery();
            }
        }

        internal static bool CheckUsernameNotExists(string username)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "CheckUsernameExists";
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = query,
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@username", username));
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return count == 0;
        }

        internal static bool CheckEmailNotExists(string email)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "CheckEmailExists";
                SqlCommand cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = query,
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@email", email));
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return count == 0;
        }
    }
}
