namespace Core.Domain.Entities;

public class Exercise
{
    public int ExerciseId { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DefaultHandlingPositionEnum DefaultHandlingPosition { get; set; }
    public bool Stationary { get; set; }
    public bool WithCone { get; set; }
    public JumpEnum? TypeOfJump { get; set; }
    public LevelEnum? Level { get; set; }
    public int IndexNumber { get; set; }
    public bool ActualHandlingPositionIsLeftHandlet { get; set; }

    public Exercise(int exerciseId, int number)
    {
        ExerciseId = exerciseId;
        Number = number;
    }

    public Exercise(int exerciseId, int number, string name, string description,
        DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, JumpEnum? typeOfJump, LevelEnum? level)
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
        DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, JumpEnum? typeOfJump, LevelEnum? level)
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
}
