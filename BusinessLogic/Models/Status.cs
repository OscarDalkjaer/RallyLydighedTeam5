using BusinessLogic.Models;

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
            if (!string.IsNullOrEmpty(numberOfRightHandled.Item2)) 
            {
                status.Add(numberOfRightHandled.Item2);
            }
           
            (bool, string) lengthOfExerciseList = _validator.ValidateLengthOfExerciseList(updatedCourse);
            if(!string.IsNullOrEmpty(lengthOfExerciseList.Item2)) 
            {
                status.Add(lengthOfExerciseList.Item2);
            }
            
            (bool, string) rightHandlingOnlyBetweenTwoChangesOfPositions = _validator
                .ValidateRightHandlingOnlyBetweenTwoChangesOfPositions(rightHandledExercises, updatedCourse);
            if(!string.IsNullOrEmpty(rightHandlingOnlyBetweenTwoChangesOfPositions.Item2)) 
            {
                status.Add(rightHandlingOnlyBetweenTwoChangesOfPositions.Item2);
            }
            
            (bool, string) maxNumberOfRepeatedRightHandledExercises = _validator.ValidateMaxNumberOfRepeatedRightHandledExercises(rightHandledExercises, updatedCourse, startPosition);
            if(!string.IsNullOrEmpty(maxNumberOfRepeatedRightHandledExercises.Item2)) 
            {
                status.Add(maxNumberOfRepeatedRightHandledExercises.Item2);
            }
            
            (bool, string) maxNumberOfStationaryExercises = _validator.ValidateMaxNumberOfStationaryExercises(updatedCourse);
            if (!string.IsNullOrEmpty(maxNumberOfStationaryExercises.Item2)) 
            {
                status.Add(maxNumberOfStationaryExercises.Item2);
            }
            
            (bool, string) maxNumberOfExercisesInNonTypicalSpeed = _validator.ValidateMaxNumberOfExercisesInNonTypicalSpeed(updatedCourse);
            if(!string.IsNullOrEmpty(maxNumberOfExercisesInNonTypicalSpeed.Item2)) 
            {
                status.Add(maxNumberOfExercisesInNonTypicalSpeed.Item2);
            }
            
            (bool, string) levelDistributionOfTheExercises = _validator.ValidateLevelDistributionOfTheExercises(updatedCourse);
            if (!string.IsNullOrEmpty(levelDistributionOfTheExercises.Item2)) 
            {
                status.Add(levelDistributionOfTheExercises.Item2);
            }
            
            (bool, string) maxNumberOfDifferentTypesOfJump = _validator.ValidateMaxNumberOfDifferentTypesOfJump(updatedCourse);
            if(!string.IsNullOrEmpty(maxNumberOfDifferentTypesOfJump.Item2)) 
            {
                status.Add(maxNumberOfDifferentTypesOfJump.Item2);
            }
            

            return Task.FromResult(status);
        }
            

        
        
    }
}