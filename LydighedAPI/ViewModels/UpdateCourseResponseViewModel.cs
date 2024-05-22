﻿using BusinessLogic.Models;

namespace API.ViewModels
{
    public class UpdateCourseResponseViewModel
    {
        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        public List<UpdateExerciseResponseViewModel> UpdateExerciseVMList { get; set; }
        public List<string> StatusStrings { get; set; }
        
        public Event Event { get; set; } 
        public Judge Judge { get; set; } 


        public UpdateCourseResponseViewModel(int courseId,
            LevelEnum level, List<UpdateExerciseResponseViewModel> updateExerciseVMList, List<string> statusStrings)
        {
            CourseId = courseId;
            Level = level;
            UpdateExerciseVMList = updateExerciseVMList;
            this.StatusStrings = statusStrings;
        }

        public UpdateCourseResponseViewModel() { }
    }
}
