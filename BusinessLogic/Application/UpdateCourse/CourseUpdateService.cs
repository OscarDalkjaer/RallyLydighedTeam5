using Core.Domain.Entities;
using Core.Domain.Entities;
using Core.Domain.Services;

namespace Core.Application.UpdateCourse
{
    public class CourseUpdateService
    {
        private readonly IJudgeRepository _judgeRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly CourseValidator _courseValidator = new CourseValidator();

        public CourseUpdateService(IJudgeRepository judgeRepository, IEventRepository eventRepository, IExerciseRepository exerciseRepository)
        {
            _judgeRepository = judgeRepository;
            _eventRepository = eventRepository;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Course> IsCourseReadyForUpdate(int courseId, LevelEnum level,
            List<int> exerciseNumbers, bool isStartPositionLeftHandled, int? judgeId, int? eventId, 
            ThemeEnum? theme)
        {
            Course? courseToUpdate = new Course(courseId, level);

            if (judgeId > 0)
            {
                courseToUpdate!.Judge = await TryGetJudge(judgeId.Value);
            }
            if (eventId > 0)
            {
                courseToUpdate!.Event = await TryGetEvent(eventId.Value);
            }

            courseToUpdate.IsStartPositionLeftHandled = isStartPositionLeftHandled;

            (List<Exercise>, List<string>) exercisesAndStatus = await _exerciseRepository.GetExercisesFromNumbers(exerciseNumbers);

            List<Exercise>? exercisesFromExerciseNumbers = exercisesAndStatus.Item1;
            List<string>? exerciseRegistrationStatuses = exercisesAndStatus.Item2;

            courseToUpdate.ExerciseCount = exercisesFromExerciseNumbers.Count();
            courseToUpdate.Theme = theme;


            foreach (Exercise exercise in exercisesFromExerciseNumbers)
            {
                courseToUpdate.ExerciseList.Add(exercise);
            }

            _courseValidator.ValidateRightHandlingIsAllowedStartPosition(courseToUpdate);
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

            foreach (string statusString in exerciseRegistrationStatuses)
            {
                courseToUpdate.StatusStrings.Insert(0, statusString);
            }
            return courseToUpdate;
        }


        public async Task<Judge> TryGetJudge(int judgeId)
        {
            Judge? preRegisteredJudge = await _judgeRepository.GetJudge(judgeId);
            if (preRegisteredJudge != null)
            {
                return preRegisteredJudge;
            }
            else
            {
                throw new Exception("Der er ikke oprettet en dommer med valgte ID i databasen");
            }
        }

        public async Task<Event> TryGetEvent(int eventId)
        {
            Event? preRegisteredEvent = await _eventRepository.GetEvent(eventId);
            if (preRegisteredEvent != null)
            {
                return preRegisteredEvent;
            }
            else
            {
                throw new Exception("Der er ikke oprettet et event med valgte ID i databasen");
            }
        }
    }
}
