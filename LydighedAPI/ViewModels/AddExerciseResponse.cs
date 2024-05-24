using Core.Domain.Entities;


namespace API.ViewModels;

public class AddExerciseResponse
{
    public int Number { get; set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DefaultHandlingPositionEnum DefaultHandlingPosition { get; private set; }
    public bool Stationary { get; private set; }
    public bool WithCone { get; private set; }
    public JumpEnum? TypeOfJump { get; private set; }
    public LevelEnum? Level { get; private set; }
    public TypeEnum Type { get; set; }
    public int ExerciseId { get; set; }


    public AddExerciseResponse(int number, string name, string description,
        DefaultHandlingPositionEnum defaultHandlingPosition, bool stationary, bool withCone, 
        JumpEnum? typeOfJump, LevelEnum? level, int exerciseId)
    {
        Number = number;
        Name = name;
        Description = description;
        DefaultHandlingPosition = defaultHandlingPosition;
        Stationary = stationary;
        WithCone = withCone;
        TypeOfJump = typeOfJump;
        Level = level;
        ExerciseId = exerciseId;

    }
}
