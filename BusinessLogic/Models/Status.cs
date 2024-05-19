﻿using BusinessLogic.Models;

namespace API.Controllers
{
    public class Status
    {
        private readonly CourseVisualizer _visualizer;
        private readonly CourseValidator _validator;
        public string NumberOfRightHandledExercises { get; set; }


        public Status(CourseVisualizer courseVisualizer, CourseValidator validator)
        {
           _visualizer = courseVisualizer;
            _validator = validator;                    
        }

        public List<(int, int, string, bool)> PrepareForStatusUpdate(Course updatedCourse, DefaultHandlingPositionEnum startPosition) 
        {
            List<(int, int, string, bool)> courseVisualized = _visualizer.VisualiseCourse(updatedCourse, startPosition);
            List<(int, int, string, bool)> rightHandledExercises = _visualizer.VisualiseRightHandledExercises(courseVisualized);
            return rightHandledExercises;
        }



        public Task<List<string>> GetStatus(Course updatedCourse, List<(int, int, string, bool)> rightHandledExercises)
        {
            DefaultHandlingPositionEnum startPosition = new DefaultHandlingPositionEnum(); // skal fjernes !!
            List<string> status = new List<string>();

            (bool, string) numberOfRightHandled = _validator.ValidateNumberOfRightHandletExercises(rightHandledExercises, updatedCourse);
            status.Add(numberOfRightHandled.Item2);

            (bool, string) lengthOfExerciseList = _validator.ValidateLengthOfExerciseList(updatedCourse);
            status.Add(lengthOfExerciseList.Item2);

            (bool, string) rightHandlingOnlyBetweenTwoChangesOfPositions = _validator.ValidateRightHandlingOnlyBetweenTwoChangesOfPositions
                (rightHandledExercises, updatedCourse);
            status.Add(rightHandlingOnlyBetweenTwoChangesOfPositions.Item2);

            (bool, string) maxNumberOfRepeatedRightHandledExercises = _validator.ValidateMaxNumberOfRepeatedRightHandledExercises(rightHandledExercises, updatedCourse, startPosition);
            status.Add(maxNumberOfRepeatedRightHandledExercises.Item2);


            return Task.FromResult(status);
        }
            

        
        
    }
}