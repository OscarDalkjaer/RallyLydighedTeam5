using Core.Domain.Entities;
using Core.Domain.Entities;

namespace DataAccess.DataAccessModels
{
    public class ExerciseDataAccessModel
    {
        
        public int ExerciseDataAccessModelId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public DefaultHandlingPositionEnum HandlingPosition { get; set; }
        public bool Stationary { get; set; }
        public bool WithCone { get; set; }
        public JumpEnum? TypeOfJump { get; set; }
        public LevelEnum? Level { get; set; }
       
        public ExerciseDataAccessModel() { }

        public ExerciseDataAccessModel(int exerciseId, int number, string name, string description,
            DefaultHandlingPositionEnum handlingPosition, bool stationary, bool withCone, JumpEnum? typeOfJump, LevelEnum? level)
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
            DefaultHandlingPositionEnum handlingPosition, bool stationary, bool withCone, JumpEnum? typeOfJump, LevelEnum? level)
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
