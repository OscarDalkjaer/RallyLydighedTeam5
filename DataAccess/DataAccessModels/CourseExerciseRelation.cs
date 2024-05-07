﻿namespace DataAccess.DataAccessModels
{

    public class CourseExerciseRelation
    {

        public CourseDataAccessModel CourseDataAccessModel { get; set; } = null!;
        public ExerciseDataAccessModel ExerciseDataAccessModel { get; set; } = null!;

        public int CourseExerciseRelationId { get; set; }
        public int CourseDataAccessModelId { get; set; }
        public int ExerciseDataAccessModelId { get; set; }

        protected CourseExerciseRelation() { }

        public CourseExerciseRelation(CourseDataAccessModel courseDataAccessModel, ExerciseDataAccessModel exerciseDataAccessModel)
            : this(courseDataAccessModel.CourseDataAccessModelId, exerciseDataAccessModel.ExerciseDataAccessModelId)
        {
            CourseDataAccessModel = courseDataAccessModel;
            ExerciseDataAccessModel = exerciseDataAccessModel;
        }

        public CourseExerciseRelation(int courseDataAccessModelId, int exerciseDataAccessModelId)
        {
            CourseDataAccessModelId = courseDataAccessModelId;
            ExerciseDataAccessModelId = exerciseDataAccessModelId;
        }

        //List<CourseExerciseRelation> courseExerciseRelations
        //        = courseDataAccessModel.CourseExerciseRelations;

        //    foreach (CourseExerciseRelation relation in courseExerciseRelations) 
        //    {
        //        course.ExerciseList.Add(new Exercise(
        //            relation.ExerciseDataAccessModel.ExerciseId,
        //            relation.ExerciseDataAccessModel.Number,
        //            relation.ExerciseDataAccessModel.Type
        //            ));
        //    }

        //    return course;

    }

}
 