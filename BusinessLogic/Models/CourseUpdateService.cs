using BusinessLogic.Services;

namespace BusinessLogic.Models
{
    public class CourseUpdateService
    {
        private readonly IJudgeRepository _judgeRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly CourseValidator _courseValidator = new CourseValidator();

        public CourseUpdateService(IJudgeRepository judgeRepository, 
            IEventRepository eventRepository, IExerciseRepository exerciseRepository) 
        {
            _judgeRepository = judgeRepository;
            _eventRepository = eventRepository;
            _exerciseRepository = exerciseRepository;          
        }

        public async Task<Course> IsCourseReadyForUpdate(int courseId, LevelEnum level,
            List<int> exerciseNumbers, bool isStartPositionLeftHandled, int? judgeId, int? eventId)
        {
            Course courseToUpdate = new Course(courseId, level);
            if(judgeId != 0) 
            {
                int judgeIdValue = judgeId.Value;
                await TryGetJudge(judgeIdValue, courseToUpdate);
            }
            if(eventId != 0)
            {
                int eventIdValue = eventId.Value;
                await TryGetEvent(eventIdValue, courseToUpdate);
            }

            courseToUpdate.IsStartPositionLeftHandled = isStartPositionLeftHandled;

            List<Exercise>? exercisesFromExerciseNumbers = await _exerciseRepository
               .GetExercisesFromNumbers(exerciseNumbers);
            foreach (Exercise exercise in exercisesFromExerciseNumbers)
            {
                courseToUpdate.ExerciseList.Add(exercise);
            }
                     
            _courseValidator.ValidateLengthOfExerciseList(courseToUpdate);
            _courseValidator.ValidateRightHandlingOnlyBetweenTwoChangesOfPositions(courseToUpdate);
            _courseValidator.ValidateMaxNumberOfRepeatedRightHandledExercises(courseToUpdate);
            _courseValidator.ValidateMaxNumberOfStationaryExercises(courseToUpdate);
            _courseValidator.ValidateMaxNumberOfExercisesWithCone(courseToUpdate);
            _courseValidator.ValidateMaxNumberOfExercisesInNonTypicalSpeed(courseToUpdate);
            _courseValidator.ValidateNumberOfRightHandletExercises(courseToUpdate);
            _courseValidator.ValidateLevelDistributionOfTheExercises(courseToUpdate);
            _courseValidator.ValidateMaxNumberOfDifferentTypesOfJump(courseToUpdate);

            courseToUpdate.StatusStrings = _courseValidator.StatusStrings;
            return courseToUpdate;
        }


        public async Task TryGetJudge (int judgeId, Course course) 
        {
            Judge? preRegisteredJudge = await _judgeRepository.GetJudge(judgeId);
            if (preRegisteredJudge != null) 
            {
                course.Judge = preRegisteredJudge;
            }
            else 
            {
                throw new Exception("Der er ikke oprettet en dommer med valgte ID i databasen");
            }
        }

        public async Task TryGetEvent(int eventId, Course course) 
        {
            Event? preRegisteredEvent = await _eventRepository.GetEvent(eventId);
            if(preRegisteredEvent != null) 
            {
                course.Event = preRegisteredEvent;
            }
            else 
            {
                throw new Exception("Der er ikke oprettet et event med valgte ID i databasen");
            }
        }
    }
}
