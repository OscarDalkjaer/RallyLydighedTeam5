using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }

        public Course (LevelEnum level)
        {
            Level = level;
        }

        public Course(int courseId, LevelEnum level)
        {
            CourseId = courseId;
            Level = level;
        }
    }   
}
