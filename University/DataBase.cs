using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib;
using UniversityClassLib.Enums;
using System.Data;
using System.Runtime.InteropServices;

namespace UniversityNamespace
{
    internal static class DataBase
    {
        private const int universityId = 1;
        private const string connectionString = @"Server=GEORGE;
                                                  Database=University;
                                                  Trusted_Connection=True;";
        public static University University { get; private set; }


        public static void LoadDataBase()
        {
            string query = @"SELECT U.Id AS UniversityId, 
                                    U.Name AS UniversityName, 
                                    U.RectorId
                             FROM [Universities] AS U
                             WHERE U.Id = @universityId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // University
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter universityParam = new SqlParameter
                {
                    ParameterName = "@universityId",
                    Value = universityId,
                    Direction = ParameterDirection.Input
                };
                cmd.Parameters.Add(universityParam);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        University = new University(
                            Convert.ToInt32(reader["UniversityId"]),
                            Convert.ToString(reader["UniversityName"]),
                            GetRectorById(Convert.ToInt32(reader["RectorId"]))
                        );
                    };
                }                
            }
        }
        private static Rector GetRectorById(int rectorId)
        {
            string query = @"SELECT U.Id, U.Name, U.Surname, U.BirthDate,
		                            U.Email, U.Password, U.Username
	                         FROM [Users] AS U
                             WHERE U.Id = @rectorId";
            Rector rector;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter rectorParam = new SqlParameter
                {
                    ParameterName = "@rectorId",
                    Value = rectorId
                };
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    rector = new Rector(Convert.ToInt32(reader["Id"]))
                    {
                        Name = Convert.ToString(reader["Name"]),
                        Surname = Convert.ToString(reader["Surname"]),
                        BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                        Email = Convert.ToString(reader["Email"]),
                        Password = Convert.ToString(reader["Password"]),
                        Username = Convert.ToString(reader["Username"])
                    };
                }
            }
            return rector;
        }
    }
}
