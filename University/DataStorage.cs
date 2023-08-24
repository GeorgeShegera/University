using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web.Hosting;
using UniversityClassLib;
using UniversityClassLib.Enums;
using University.DataBase;

namespace University
{
    public class DataBaseClass
    {        
        private const int universityId = 1;
        private const string connectionString = @"Server=GEORGE;
                                                  Database=University;
                                                  Trusted_Connection=True;";
        public static UniversityClassLib.University University { get; private set; }
        private static List<KeyValuePair<int, Subject>> subjectsLectId;
        private static List<Subject> subjects => subjectsLectId.Select(x => x.Value).ToList();
        private static List<Lecturer> lecturers = new List<Lecturer>();

        public static void LoadDataBase()
        {
            // Subjects            
            string query = @"SELECT S.Id, S.Name, S.PassMark, 
                                    S.LecturerId
                            FROM [Subjects] AS S;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Subject subject = new Subject(Convert.ToInt32(reader["Id"]))
                    {
                        Name = Convert.ToString(reader["Name"]),
                        PassMark = Convert.ToInt32(reader["PassMark"])
                    };
                    subjectsLectId.Add(new KeyValuePair<int, Subject>
                    (Convert.ToInt32(reader["LecturerId"]), subject));
                }
            }
            // Lecturers
            query = @"SELECT L.Id, H.Name, H.Surname, H.BirthDate, 
                                    U.Email, U.Username, U.Password,
		                            L.ScientificDegree, L.AcademicStatus,
                                    L.ScientificIdentifiers AS SI, L.StatusId
	                         FROM [Lecturers] AS L
	                         INNER JOIN [Users] AS U ON U.Id = L.UserId
                             INNER JOIN [Humans] AS H ON H.Id = U.HumanId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    lecturers.Add(new Lecturer(LoadUser(reader))
                    {
                        Status = (LecturerStatus)Convert.ToInt32(reader["StatusId"]),
                        ScientificDegree = Convert.ToString(reader["ScientificDegree"]),
                        AcademicStatus = Convert.ToString(reader["AcademicStatus"]),
                        ScientificIdentifiers = Convert.ToString(reader["SI"]),
                        Subjects = subjectsLectId
                                    .Where(x => x.Key == id)
                                    .Select(x => x.Value).ToList()
                    });
                }
            }
            // University
            query = @"SELECT U.Id AS UniversityId, 
                             U.Name AS UniversityName,
                             U.RectorId
                      FROM [Universities] AS U
                      WHERE U.Id = @universityId;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
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

        private static List<Lecturer> LoadLecturers(int facultyId)
        {
            List<Lecturer> newLecturers = new List<Lecturer>();
            string query = @"SELECT L.Id FROM [Lecturers]
                             INNER JOIN [FacultiesLecturers] AS FL 
                             ON FL.LecturerId = L.Id AND FL.FacultyId = @facultyId";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter param = new SqlParameter("@facultyId", facultyId);
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int lecturId = Convert.ToInt32(reader["Id"]);
                    newLecturers.Add(lecturers.Find(x => x.Id == lecturId));
                }
            }
            return newLecturers;
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
            List<Mark> marks = new List<Mark>();
            string query = @"SELECT M.Id, M.Mark, M.SubjectId
                             FROM [Marks] AS M
                             WHERE M.StudentId = @studentId;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter param = new SqlParameter("@studentId", studentId);
                cmd.Parameters.Add(param);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int subjectId = Convert.ToInt32(reader["SubjectId"]);
                    marks.Add(new Mark(Convert.ToInt32(reader["Id"]))
                    {
                        Value = float.Parse(reader["Value"].ToString()),
                        Subject = subjects.Find(x => x.Id == subjectId)
                    });
                }
            }
            return marks;
        }

        private static List<StudentTask> LoadTasks(int studentId)
        {
            List<StudentTask> tasks = new List<StudentTask>();

            return tasks;
        }

        private static List<Class> LoadClasses(int groupId)
        {
            string query = @"SELECT C.Id, C.SubjectId, C.WeekDay,
                                    C.WeekType, C.StartTime, C.EndTime,
                                    C.TypeId, C.LecturerId
                             FROM [Classes] AS C
                             INNER JOIN [GroupsClasses] AS GC 
                             ON GC.ClassesId = C.Id AND GC.GroupId = @groupId;";
            List<Class> classes = new List<Class>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter sqlParameter = new SqlParameter("@groupId", groupId);
                cmd.Parameters.Add(sqlParameter);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int lectId = Convert.ToInt32(reader["LecturerId"]);
                    int subjId = Convert.ToInt32(reader["SubjectId"]);
                    classes.Add(new Class(Convert.ToInt32(reader["Id"]))
                    {
                        WeekDay = (DayOfWeek)Convert.ToInt32(reader["WeekDay"]),
                        WeekType = (TypeOfWeek)Convert.ToInt32(reader["WeekType"]),
                        StartTime = reader.GetTimeSpan(4),
                        EndTime = reader.GetTimeSpan(5),
                        Type = (ClassType)reader.GetInt32(6),
                        Subject = subjects.Find(x => x.Id == subjId),
                        Lecturer = lecturers.Find(x => x.Id == lectId)
                    });
                }
            }
            return classes;
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
                SqlParameter rectorParam = new SqlParameter("@rectorId", rectorId);
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
