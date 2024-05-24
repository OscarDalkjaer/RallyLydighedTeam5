using Core.Domain.Entities;
using Core.Domain.Entities;

namespace Core.Application.UpdateCourse
{
    public class CourseVisualizer
    {
        public List<(int, int, string, bool)> VisualiseCourse(Course course)
        {
            course.ExerciseList = course.ExerciseList
               .Select((exercise, index) => { exercise.IndexNumber = index; return exercise; })
               .ToList();

            if (course.IsStartPositionLeftHandled == true)
            {
                course.ExerciseList[0].ActualHandlingPositionIsLeftHandlet =
                    course.ExerciseList[0].DefaultHandlingPosition != DefaultHandlingPositionEnum.ChangeOfPosition;
            }
            else
            {
                course.ExerciseList[0].ActualHandlingPositionIsLeftHandlet = false;
            }

            foreach (Exercise x in course.ExerciseList)
            {
                if (x.IndexNumber > 0 && x.IndexNumber < course.ExerciseList.Count)
                {   // If actual exercise is not making a change of position, actual handlingPosition is the same as the former exercise
                    x.ActualHandlingPositionIsLeftHandlet =
                        course.ExerciseList[x.IndexNumber].DefaultHandlingPosition != DefaultHandlingPositionEnum.ChangeOfPosition ?
                        course.ExerciseList[x.IndexNumber - 1].ActualHandlingPositionIsLeftHandlet
                        : !course.ExerciseList[x.IndexNumber - 1].ActualHandlingPositionIsLeftHandlet;
                }
            }

            //returning a list showing for each exercise: id, number, name and actual handlingposition
            List<(int, int, string, bool)> courseVisualized = new List<(int, int, string, bool)>();
            courseVisualized.Add((course.ExerciseList[0].ExerciseId, course.ExerciseList[0].IndexNumber, course.ExerciseList[0].Name,
                course.ExerciseList[0].ActualHandlingPositionIsLeftHandlet));
            courseVisualized.AddRange(course.ExerciseList.Skip(1).Select(x => (x.ExerciseId, x.IndexNumber, x.Name,
                x.ActualHandlingPositionIsLeftHandlet)).ToList());
            return courseVisualized;
        }

        public List<(int, int, string, JumpEnum?)> VisualiseJumpPropertyForExercise(Course course)
        {
            List<(int, int, string, JumpEnum?)> visualisedJumpExercises = course.ExerciseList.Select(x =>
            (x.ExerciseId, x.Number, x.Name, x.TypeOfJump)).ToList();
            return visualisedJumpExercises;
        }

        public (int, int, int, int, int) VisualiseLevelDistributionOfTheExercises(Course course)
        {
            int countOfBeginnerLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Beginner);
            int countOfAdvancedLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Advanced);
            int countOfExpertLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Expert);
            int countOfChampionLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.Champion);
            int countOfOpeClassLevelExercises = course.ExerciseList.Count(x => x.Level == LevelEnum.OpenClass);
            return (countOfBeginnerLevelExercises, countOfAdvancedLevelExercises, countOfExpertLevelExercises,
                countOfChampionLevelExercises, countOfOpeClassLevelExercises);

        }


        /// <summary>
        /// Return a list of exercises actually being rightHandled
        /// </summary>
        public List<(int, int, string, bool)> VisualiseRightHandledExercises(List<(int, int, string, bool)> visualisedCourse)
        {
            List<(int, int, string, bool)> exercisesWithRightHandling = visualisedCourse.Where(item => !item.Item4).ToList();
            return exercisesWithRightHandling;
        }
    }
}
