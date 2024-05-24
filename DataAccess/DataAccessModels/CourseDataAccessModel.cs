using Core.Domain.Entities;
using Core.Domain.Entities;

namespace DataAccess.DataAccessModels
{
    public class CourseDataAccessModel
    {
        public  int CourseDataAccessModelId { get; protected set; }
        public List<CourseExerciseRelation> CourseExerciseRelations { get; protected set; } = [];
        public  LevelEnum Level { get; protected set; }
        public JudgeDataAccessModel? JudgeDataAccessModel { get; protected set; }
        public EventDataAccessModel? EventDataAccessModel { get; protected set; }
        public int? ExerciseCount { get; protected set; }
        public ThemeEnum? Theme { get; protected set; }


        protected CourseDataAccessModel() { }
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
                CourseExerciseRelations = relations,
                Level = course.Level,
                JudgeDataAccessModel = new JudgeDataAccessModel(course.Judge.FirstName, course.Judge.LastName, course.Judge.JudgeId),
                EventDataAccessModel = new EventDataAccessModel(course.Event.Name, course.Event.Date, course.Event.Location
                , course.Event.EventId),
                ExerciseCount = course.ExerciseCount,
                Theme = course.Theme,
            };
        }

        public Course FromDataAccesModelToCourse() 
        {
            Course course = new Course(this.Level);
            course.CourseId = this.CourseDataAccessModelId;
            course.Level = this.Level;
            if (JudgeDataAccessModel != null)
            {
                course.Judge = new Judge(this.JudgeDataAccessModel.FirstName, this.JudgeDataAccessModel.LastName, this.JudgeDataAccessModel.JudgeDataAccessModelId);
            }
            if (EventDataAccessModel != null)
            {
                course.Event = new Event(this.EventDataAccessModel.Name, this.EventDataAccessModel.Date, this.EventDataAccessModel.Location,
                this.EventDataAccessModel.EventDataAccessModelId);
            }
            course.ExerciseCount = this.ExerciseCount;
            course.Theme = this.Theme;
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
