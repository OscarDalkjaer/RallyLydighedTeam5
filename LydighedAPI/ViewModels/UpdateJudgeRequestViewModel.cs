namespace API.ViewModels
{
    public class UpdateJudgeRequestViewModel
    {      
        public string FirstName { get; }
        public string LastName { get; }
        public int UpdatedJudgeId { get; private set; }

        public UpdateJudgeRequestViewModel(string firstName, string lastName, int updatedJudgeId)
        {
            FirstName = firstName;
            LastName = lastName;
            UpdatedJudgeId = updatedJudgeId;
        }
    }
}
