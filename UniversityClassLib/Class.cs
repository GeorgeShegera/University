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
        public DayOfWeek DayOfWeek { get; set; }
        public WeekType WeekType { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public ClassType Type { get; set; }
        public Lecturer Lecturer { get; set; }
        public Class(int id, Subject subject, DayOfWeek dayOfWeek, WeekType weekType,
                       TimeSpan startTime, TimeSpan endTime, ClassType type, Lecturer lecturer)
        {
            Id = id;
            Subject = subject;
            DayOfWeek = dayOfWeek;
            WeekType = weekType;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            Lecturer = lecturer;
        }
        public Class(int id) : this(id, new Subject(), default, default, default, default, default, new Lecturer()) { }
    }
}
