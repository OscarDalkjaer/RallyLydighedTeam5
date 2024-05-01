using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class CourseBuilder
    {

        private readonly IExerciseRepository exerciseRepository;
        public CourseBuilder(IExerciseRepository exerciseRepository)
        {
             this.exerciseRepository = exerciseRepository;
        }
   
       

        public async Task<Course> BuildCourseWithExercises(LevelEnum _level)
        {
            Course course = new Course(_level);
            await ExerciseListInitiate(_level, course);
            return course;       
            
        }

        public async Task ExerciseListInitiate(LevelEnum level, Course course)
        {
            Exercise nullExercise = await exerciseRepository.GetNullExercise();
            switch (level)
            {
                case LevelEnum.Beginner:
                    for (int i = 1; i <= 15; i++)
                    {
                        course.Relations.Add(new CourseExerciseRelation
                        {
                            Course = course,
                            Exercise = nullExercise
                        });
                    }
                    break;
                case LevelEnum.Advanced:
                    for (int i = 1; i <= 17; i++)
                    {
                        course.Relations.Add(new CourseExerciseRelation
                        {
                            Course = course,
                            Exercise = nullExercise
                        });
                    }
                    break;
                case LevelEnum.Expert:
                    for (int i = 1; i <= 20; i++)
                    {
                        course.Relations.Add(new CourseExerciseRelation
                        {
                            Course = course,
                            Exercise = nullExercise
                        });
                    }
                    break;
                case LevelEnum.Champion:
                    for (int i = 1; i <= 20; i++)
                    {
                        course.Relations.Add(new CourseExerciseRelation
                        {
                            Course = course,
                            Exercise = nullExercise
                        });
                    }
                    break;
                case LevelEnum.OpenClass:
                    for (int i = 1; i <= 18; i++)
                    {
                        course.Relations.Add(new CourseExerciseRelation
                        {
                            Course= course,
                            Exercise = nullExercise
                        });
                    }
                    break;
                default: break;
            }
        }


    }
}
