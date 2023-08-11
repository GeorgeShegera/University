using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityClassLib;

namespace University
{
    internal static class DataBase
    {
        private const int universityId = 1;
        private const string connectionString = @"Server=GEORGE;
                                                  Database=University;
                                                  Trusted_Connection=True;";
        public static UniversityClassLib.University University { get; private set; }


        public static void LoadDataBase()
        {
            string query = @"SELECT U.Id AS UniversityId, 
                                    U.Name AS UniversityName,
                                    U.RectorId
                             FROM [Universities] AS U
                             WHERE U.Id = @universityId;";
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
                        University = new UniversityClassLib.University(
                            Convert.ToInt32(reader["UniversityId"]),
                            Convert.ToString(reader["UniversityName"]),
                            LoadRector(Convert.ToInt32(reader["RectorId"]))
                        );
                    };
                }
                // University's faculties
                cmd.CommandText = @"SELECT F.Id, F.Name
                                    FROM [Faculties] AS F
                                    INNER JOIN [UniversitiesFaculties] AS UF
                                    ON UF.UniversityId = @universityId AND 
                                       UF.FacultyId = F.Id;";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int facultyId = Convert.ToInt32(reader["Id"]);
                    University.Faculties.Add(new Faculty(facultyId)
                    {
                        Name = Convert.ToString(reader["Name"]),
                        Lecturers = LoadLecturers(facultyId),
                        Groups = LoadGroups(facultyId)
                    });
                }
            }
        }

        private static List<Group> LoadGroups(int facultyId)
        {
            string query = @"SELECT G.Id, G.Name, G.Year, G.StatusId
                             FROM [Groups] AS G
                             WHERE G.FacultyId = @facultyId;";
            List<Group> groups = new List<Group>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter sqlParameter = new SqlParameter
                {
                    ParameterName = "@facultyId",
                    Value = facultyId
                };
                cmd.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int groupId = Convert.ToInt32(reader["Id"]);
                    groups.Add(new Group(groupId)
                    {
                        Name = Convert.ToString(reader["Name"]),
                        Year = Convert.ToInt32(reader["Year"]),
                        Status = (GroupStatus)Convert.ToInt32(reader["StatusId"]),
                        Students = LoadStudents(groupId),
                        Classes = LoadClasses(groupId)
                    });
                }
            }
            return groups;
        }

        private static List<Student> LoadStudents(int groupId)
        {
            string query = @"SELECT S.Id, H.Name, H.Surname, H.BirthDate, 
                                    U.Email, U.Username, U.Password,
		                            S.StatusId
	                         FROM [Students] AS S
	                         INNER JOIN [Users] AS U ON U.Id = S.UserId
                             INNER JOIN [Humans] AS H ON H.Id = U.HumanId
                             INNER JOIN [GroupsStudents] AS GS
	                         ON GS.GroupId = @groupId AND GS.StudentId = S.Id;";
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter sqlParameter = new SqlParameter
                {
                    ParameterName = "@groupId",
                    Value = groupId
                };
                cmd.Parameters.Add(sqlParameter);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int studentId = Convert.ToInt32(reader["Id"]);
                    students.Add(new Student(LoadUser(reader))
                    {
                        Status = (StudentStatus)Convert.ToInt32(reader["StatusId"]),
                        Marks = LoadMarks(studentId),
                        Tasks = LoadTasks(studentId)
                    });
                }
            }
            return students;
        }
        private static List<Mark> LoadMarks(int studentId)
        {

        }

        private static List<StudentTask> LoadTasks(int studentId)
        {

        }

        private static List<Class> LoadClasses(int groupId)
        {

        }

        private static List<Lecturer> LoadLecturers(int facultyId)
        {
            string query = @"SELECT L.Id, H.Name, H.Surname, H.BirthDate, 
                                    U.Email, U.Username, U.Password,
		                            L.ScientificDegree, L.AcademicStatus,
                                    L.ScientificIdentifiers AS SI, L.StatusId
	                         FROM [Lecturers] AS L
	                         INNER JOIN [Users] AS U ON U.Id = L.UserId
                             INNER JOIN [Humans] AS H ON H.Id = U.HumanId
                             INNER JOIN [FacultiesLecturers] AS FL
	                         ON FL.FacultyId = @facultyId AND FL.LecturerId = L.Id;";
            List<Lecturer> lecturers = new List<Lecturer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter sqlParameter = new SqlParameter
                {
                    ParameterName = "@facultyId",
                    Value = facultyId
                };
                cmd.Parameters.Add(sqlParameter);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lecturers.Add(new Lecturer(LoadUser(reader))
                    {
                        Status = (LecturerStatus)Convert.ToInt32(reader["StatusId"]),
                        ScientificDegree = Convert.ToString(reader["ScientificDegree"]),
                        AcademicStatus = Convert.ToString(reader["AcademicStatus"]),
                        ScientificIdentifiers = Convert.ToString(reader["SI"])
                    });
                }
            }
            return lecturers;
        }

        private static Rector LoadRector(int rectorId)
        {
            string query = @"SELECT R.Id, H.Name, H.Surname, H.BirthDate,
	                                U.Email, U.Password, U.Username, R.StatusId
	                         FROM [Rectors] AS R
                             INNER JOIN [Users] AS U ON U.Id = R.UserId
                             INNER JOIN [Humans] AS H ON H.Id = U.HumanId
                             WHERE R.Id = @rectorId;";
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
                    rector = new Rector(LoadUser(reader))
                    {
                        Status = (RectorStatus)Convert.ToInt32(reader["StatusId"])
                    };
                }
            }
            return rector;
        }

        private static User LoadUser(SqlDataReader reader)
        {
            return new User(Convert.ToInt32(reader["Id"]))
            {
                Name = Convert.ToString(reader["Name"]),
                Surname = Convert.ToString(reader["Surname"]),
                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                Email = Convert.ToString(reader["Email"]),
                Password = Convert.ToString(reader["Password"]),
                Username = Convert.ToString(reader["Username"]),
            };
        }
    }
}
