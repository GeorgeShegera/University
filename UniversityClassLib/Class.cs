using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityClassLib.Enums;

namespace UniversityClassLib
{
    public class Class
    {
        public int Id { get; }
        public Subject Subject { get; set; }
        public Lecturer Lecturer { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TypeOfWeek WeekType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public ClassType Type { get; set; }

        public Class(int id = default, Subject subject = default,
                     DayOfWeek dayOfWeek = default, TypeOfWeek weekType = default,
                     TimeSpan startTime = default, TimeSpan endTime = default,
                     ClassType type = default, Lecturer lecturer = null)
        {
            Id = id;
            Subject = subject;
            WeekDay = dayOfWeek;
            WeekType = weekType;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            Lecturer = lecturer;
        }
    }
}
