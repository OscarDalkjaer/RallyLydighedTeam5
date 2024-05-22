namespace BusinessLogic.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DefaultHandlingPositionEnum DefaultHandlingPosition { get; set; }
        public bool Stationary { get; set; }
        public bool WithCone { get; set; }
        public jumpEnum? TypeOfJump {  get; set; }
        public LevelEnum? Level { get; set; }
        public int IndexNumber { get; set; }
        public bool ActualHandlingPositionIsLeftHandlet {get; set; }

        public Exercise(int exerciseId, int number, string name, string description, 
            DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, jumpEnum? typeOfJump, LevelEnum? level)
        {
            ExerciseId = exerciseId;
            Number = number;
            Name = name;
            Description = description;
            DefaultHandlingPosition = defaultHandlingPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;

        }

        public Exercise(int number, string name, string description,
            DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, jumpEnum? typeOfJump, LevelEnum? level)
        {
            Number = number;
            Name = name;
            Description = description;
            DefaultHandlingPosition = defaultHandlingPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;
        }

        public Exercise(int exerciseId, int number, string name, string description,
            DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, 
            jumpEnum? typeOfJump, LevelEnum? level, int indexNumber, bool actualHandlingPositionIsLeftHandlet)
        {
            ExerciseId = exerciseId;
            Number = number;
            Name = name;
            Description = description;
            DefaultHandlingPosition = defaultHandlingPosition;
            Stationary = stationary;
            WithCone = withCone;
            TypeOfJump = typeOfJump;
            Level = level;
            IndexNumber = indexNumber;
            ActualHandlingPositionIsLeftHandlet = actualHandlingPositionIsLeftHandlet;
        }



        

       
    }
    }
