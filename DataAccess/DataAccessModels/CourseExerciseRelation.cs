namespace DataAccess.DataAccessModels{
  
    public class CourseExerciseRelation
    {
        public CourseDataAccessModel CourseDataAccessModel { get; private set; }
        public ExerciseDataAccessModel? ExerciseDataAccessModel { get; private set; }
        public int? RelationId { get; private set; }


        protected CourseExerciseRelation() { }

        public CourseExerciseRelation(CourseDataAccessModel courseDataAccessModel, 
            ExerciseDataAccessModel? exerciseDataAccessModel) 
        {
            CourseDataAccessModel = courseDataAccessModel;
            ExerciseDataAccessModel = exerciseDataAccessModel;
        }
        
        
    }
    
}
 