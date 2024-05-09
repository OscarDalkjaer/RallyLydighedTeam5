using BusinessLogic.Models;
using DataAccess.Migrations;

namespace DataAccess.DataAccessModels
{
    public class ExerciseDataAccessModel
    {
        
        public int ExerciseDataAccessModelId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public HandlingPositionEnum HandlingPosition { get; set; }
        public bool Stationary { get; set; }
        public bool WithCone { get; set; }
        public jumpEnum? TypeOfJump { get; set; }
        public LevelEnum? Level { get; set; }
        //public List<CourseDataAccessModel> CourseDataAccessModels { get; set; } = [];

        public ExerciseDataAccessModel() { }

        //public ExerciseDataAccessModel(int exerciseId, int? number, TypeEnum? type) 
        //{
        //    ExerciseDataAccessModelId = exerciseId;
        //    Number = number;
        //    Type = type;

        //}

        public ExerciseDataAccessModel(int exerciseId, int number, string name, string description,
            HandlingPositionEnum handlingPosition, bool stationary, bool withCone, jumpEnum? typeOfJump, LevelEnum? level)
        {
            ExerciseDataAccessModelId = exerciseId;
            Number = number;
            Name = name;
            Description = description;
            HandlingPosition = handlingPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;
        }

        public ExerciseDataAccessModel(int number, string name, string description,
            HandlingPositionEnum handlingPosition, bool stationary, bool withCone, jumpEnum? typeOfJump, LevelEnum? level)
        {
            Number = number;
            Name = name;
            Description = description;
            HandlingPosition = handlingPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;
        }
    }
}
