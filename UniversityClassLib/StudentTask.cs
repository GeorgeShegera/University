using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib.Enums;

namespace UniversityClassLib
{
    public class StudentTask
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime PublicationDate { get; set; }
        public Subject Subject { get; set; }
        public int Points { get; set; }
        public int Rated { get; set; }
        public int AssignedStudentId { get; set; }
        public StudentTask(int id, string title, string description, TaskState state, DateTime deadLine,
                DateTime publicationDate, Subject subject, int points, int rated, int assignedStudentId)
        {
            Id = id;
            Title = title;
            Description = description;
            State = state;
            DeadLine = deadLine;
            PublicationDate = publicationDate;
            Subject = subject;
            Points = points;
            Rated = rated;
            AssignedStudentId = assignedStudentId;
        }
        public StudentTask(int id) : this(id, "", "", default, default, default,
                                   new Subject(), 0, 0, default)
        { }
    }
}
