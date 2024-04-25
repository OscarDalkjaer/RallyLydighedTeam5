using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class CourseBuilding
    {
        public CourseBuilding(Course course, Event? @event, Judge? judge) 
        {
            Course = course;
            Event = @event;
            Judge = judge;
            PossibleExercises = new List<Exercise>();
            ChosenExercises = new List<Exercise>();

        }

        public Course Course { get; }
        public Event? Event { get; }
        public Judge? Judge { get; }
        public List<Exercise> PossibleExercises { get; }
        public List<Exercise> ChosenExercises { get; }  
    }
}
