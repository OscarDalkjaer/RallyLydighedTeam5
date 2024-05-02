using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessModels
{
    public class CourseDataAccessModel
    {
        private readonly IExerciseRepository _exerciseRepository;

        public  int CourseId { get; set; }
        public Exercise nullExercise;
        ExerciseDataAccessModel NullExerciseDataAccessModel { get; set; }
        public List<CourseExerciseRelation> CourseExerciseRelations { get; set; } = new List<CourseExerciseRelation>();
        
        
        protected CourseDataAccessModel(IExerciseRepository exerciseRepository) 
        {
            _exerciseRepository = exerciseRepository;            
        }

        public async Task GetNullExerciseDataAccessModel() 
        {
            nullExercise = await _exerciseRepository.GetNullExercise();
            NullExerciseDataAccessModel = new ExerciseDataAccessModel(
                nullExercise.ExerciseId,
                nullExercise.Number,
                nullExercise.Type
                );                ;
        }

        public CourseDataAccessModel(Course course, int maxLengthOfExerciseList) 
        {
            CourseId = course.CourseId;
            
            for(int i = 1; i < maxLengthOfExerciseList; i++) 
            {
                CourseExerciseRelations.Add(new CourseExerciseRelation(this, NullExerciseDataAccessModel));
            }

        }

        //public CourseDataAccessModel(int courseId, LevelEnum level, List<CourseExerciseRelation> courseExerciseRelations) 
        //{
        //    CourseId = courseId;
        //    Level = level;
        //    CourseExerciseRelations = courseExerciseRelations




        //    //foreach (Exercise exercise in ExerciseList) 
        //    //{
        //    //    CourseExerciseRelation relation = new CourseExerciseRelation();
        //    //}

        //}
    }
}
