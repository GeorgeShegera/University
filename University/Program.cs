using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using UniversityClassLib;
using System.Data;
using UniversityClassLib.Enums;
using University.Structs;
using System.Web.Security;

namespace University
{
    internal static class Program
    {
        private static readonly string connectionString = "Server=GEORGE;Database=University;Trusted_Connection=True;";
        private const int universityId = 1;

        private static void LoadDataBase()
        {            
            string sqlExpression = "";
            List<Lecturer> lerturers = GetLecturers();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand
                {
                    CommandText = sqlExpression,
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };


                SqlParameter universityPar = new SqlParameter("@universityId", universityId);
                cmd.Parameters.Add(universityPar);

                cmd.CommandText = "GetSubjects";
                // Get Subjects
                List<Subject> subjects = new List<Subject>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject(reader.GetInt32(0))
                        {
                            Name = reader.GetString(1),
                            PassMark = reader.GetFloat(2),
                            Lecturer = lerturers.Find(x => x.Id == reader.GetInt32(3))
                        });
                    }
                }
                // Marks
                List<KeyValueEntry<Mark, int>> studentsMarks = new List<KeyValueEntry<Mark, int>>();
                cmd.CommandText = "GetMarks";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Mark mark = new Mark
                        {
                            Id = reader.GetInt32(0),
                            Value = reader.GetFloat(1),
                            Subject = subjects.Find(x => x.Id == reader.GetInt32(3))
                        };
                        int studentId = reader.GetInt32(4);
                        studentsMarks.Add(new KeyValueEntry<Mark, int>(studentId, mark));
                    }
                }
                // Get Students
                cmd.CommandText = "GetStudents";
                List<Student> students = new List<Student>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Mark> marks = new List<Mark>();
                    while (reader.Read())
                    {
                        int studentId = reader.GetInt32(0);
                        foreach (var mark in studentsMarks)
                        {
                            if (mark.id == studentId) marks.Add(mark.value);
                        }
                        students.Add(new Student(studentId)
                        {
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            BirthDate = reader.GetDateTime(3),
                            Email = reader.GetString(4),
                            Password = reader.GetString(5),
                            Username = reader.GetString(6),
                            Marks = marks
                        });
                    }
                }
                // Get Classes
                cmd.CommandText = "GetClasses";
                List<Class> classes = new List<Class>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        classes.Add(new Class(reader.GetInt32(0))
                        {
                            Subject = subjects.Find(x => x.Id == reader.GetInt32(1)),
                            DayOfWeek = (DayOfWeek)reader.GetInt32(2),
                            WeekType = (WeekType)reader.GetInt32(3),
                            StartTime = reader.GetTimeSpan(4),
                            EndTime = reader.GetTimeSpan(5),
                            Type = (ClassType)reader.GetInt32(6),
                            Lecturer = lerturers.Find(x => x.Id == reader.GetInt32(7))
                        });
                    }
                }
                // Get Tasks
                cmd.CommandText = "GetTasks";
                List<Task> tasks = new List<Task>();
                List<int> tasksGroupsId = new List<int>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task(reader.GetInt32(0))
                        {
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            State = (TaskState)reader.GetInt32(4),
                            DeadLine = reader.GetDateTime(5),
                            PublicationDate = reader.GetDateTime(6),
                            Points = reader.GetInt32(7),
                            Rated = reader.GetInt32(8),
                            AssignedStudentId = reader.GetInt32(9),
                            Subject = subjects.Find(x => x.Id == reader.GetInt32(10))
                        });
                        tasksGroupsId.Add(reader.GetInt32(3));
                    }
                }
                // Groups

            }
        }

        private static List<Lecturer> GetLecturers()
        {
            string sqlExpression = "GetLecturers";
            List<Lecturer> lecturers = new List<Lecturer>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = sqlExpression,
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter universityIdParam = new SqlParameter
                {
                    ParameterName = "@universityId",
                    Value = universityId,
                    Direction = ParameterDirection.Input
                };

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lecturers.Add(new Lecturer(reader.GetInt32(0))
                            {
                                Name = reader.GetString(1),
                                Surname = reader.GetString(2),
                                BirthDate = reader.GetDateTime(3),
                                Username = reader.GetString(4),
                                Password = reader.GetString(5),
                                ScientificDegree = reader.GetString(6),
                                AcademicStatus = reader.GetString(7),
                                ScientificIdentifiers = reader.GetString(8)
                            });
                        }
                    }
                }
            }
            return lecturers;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadDataBase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
