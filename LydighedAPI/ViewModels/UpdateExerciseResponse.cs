namespace API.ViewModels;

public class UpdateExerciseResponse
{
    public int UpdateExerciseResponseViewModelId { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public UpdateExerciseResponse(int updateExerciseResponseViewModelId, int number, string name, string description)
    {
        UpdateExerciseResponseViewModelId = updateExerciseResponseViewModelId;
        Number = number;
        Name = name;
        Description = description;
    }
}
