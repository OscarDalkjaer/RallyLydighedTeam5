using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using DataAccessDbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessModels
{
    public class CourseDataAccessModel
    {
        public  int CourseDataAccessModelId { get; set; }
        public List<CourseExerciseRelation> CourseExerciseRelations { get; protected set; } = [];
        public  LevelEnum Level { get; set; }


        public CourseDataAccessModel() { }
        public CourseDataAccessModel(Course course) 
        {
            CourseDataAccessModelId = course.CourseId;
            Level = course.Level;
           // CourseExerciseRelations = new List<CourseExerciseRelation>();   

        }

        
        public Course ToCourse()
        {
            // TODO: Map all data til et Course
            return new Course(LevelEnum.Expert);
        }

        public void AddRelation(ExerciseDataAccessModel exerciseDataAccessModel)
        {
            CourseExerciseRelations.Add(new CourseExerciseRelation(this,exerciseDataAccessModel));
        }

        public static CourseDataAccessModel FromCourseToDataAccessModel(Course course)
        {
            List<CourseExerciseRelation> relations = course.ExerciseList
                .Select(x => new CourseExerciseRelation(course.CourseId, x.ExerciseId))
                .ToList();
            
            return new CourseDataAccessModel
            {
                CourseDataAccessModelId = course.CourseId,
                CourseExerciseRelations = relations
            };
        }

        public Course FromDataAccesModelToCourse() 
        {
            Course course = new Course(this.Level);

            List<ExerciseDataAccessModel> exerciseDataAccessModels  = this.CourseExerciseRelations
                .Select(x => x.ExerciseDataAccessModel).ToList();
            List<Exercise> exercises = exerciseDataAccessModels.Select(x => 
                new Exercise(x.ExerciseDataAccessModelId, x.Number, x.Type)).ToList();

            foreach (var exercise in exercises) course.ExerciseList.Add(exercise);
            return course;
                      
        }
    }
}
