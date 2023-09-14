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
        public DayOfWeek WeekDay { get; set; }
        public TypeOfWeek WeekType { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public ClassType Type { get; set; }
        public List<int> LecturerIDs { get; set; }
        public List<int> GroupIDs { get; set; }
        public int SubjectId { get; set; }


        public Class(int id = default, DayOfWeek dayOfWeek = default,
                     TypeOfWeek weekType = default, TimeOnly startTime = default,
                     TimeOnly endTime = default, ClassType type = default,
                     List<int> lecturerIDs = default, List<int> groupIDs = default,
                     int subjectId = default)
        {
            Id = id;
            WeekDay = dayOfWeek;
            WeekType = weekType;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            LecturerIDs = lecturerIDs;
            GroupIDs = groupIDs;
            SubjectId = subjectId;
        }
    }
}
