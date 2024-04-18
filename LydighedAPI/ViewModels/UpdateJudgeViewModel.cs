namespace API.ViewModels
{
    public class UpdateJudgeViewModel
    {
        public UpdateJudgeViewModel(string firstName, string lastName, int updatedJudgeId)
        {
            FirstName = firstName;
            LastName = lastName;
            UpdatedJudgeId = updatedJudgeId;

        }

        public string FirstName { get; }
        public string LastName { get; }
        public int UpdatedJudgeId { get; private set; }
    }
}
