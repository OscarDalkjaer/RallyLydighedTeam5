using BusinessLogic.Models;

namespace DataAccess.DataAccessModels
{
    public class CourseDataAccessModel
    {
        public  int CourseDataAccessModelId { get; set; }
        public List<CourseExerciseRelation> CourseExerciseRelations { get; protected set; } = [];
        public  LevelEnum Level { get; set; }
        public Judge? Judge { get; set; }
        public Event? Event { get; set; }

        public CourseDataAccessModel() { }
        public CourseDataAccessModel(Course course) 
        {
            CourseDataAccessModelId = course.CourseId;
            Level = course.Level;
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
            course.CourseId = this.CourseDataAccessModelId;
            List<ExerciseDataAccessModel> exerciseDataAccessModels  = this.CourseExerciseRelations
                .Select(x => x.ExerciseDataAccessModel).ToList();
            List<Exercise> exercises = exerciseDataAccessModels.Select(x => 
                new Exercise(x.ExerciseDataAccessModelId, x.Number, x.Name, x.Description, x.HandlingPosition,
            x.Stationary, x.WithCone, x.TypeOfJump, x.Level)).ToList();

            foreach (var exercise in exercises) course.ExerciseList.Add(exercise);
            return course;                      
        }
    }
}
