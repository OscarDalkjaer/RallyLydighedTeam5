using BusinessLogic.Models;

namespace DataAccess.DataAccessModels
{
    public class ExerciseDataAccessModel
    {
        
        public int ExerciseDataAccessModelId { get; set; }
        public int? Number { get; set; }

        public string Name { get; set; }
        public TypeEnum? Type { get; set; }
        public string Description { get; set; }
        public List<CourseDataAccessModel> CourseDataAccessModels { get; set; } = [];

        public ExerciseDataAccessModel() { }

        public ExerciseDataAccessModel(int exerciseId, int? number, TypeEnum? type) 
        {
            ExerciseDataAccessModelId = exerciseId;
            Number = number;
            Type = type;

        }

        public ExerciseDataAccessModel(int number, string name,  string description, TypeEnum type) 
        {
            Number = number;
            Description = description;
            Type = type;
        }
    }
}
