namespace API.ViewModels
{
    public class UpdateJudgeResponseViewModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int? UpdatedJudgeId { get; private set; }

        public UpdateJudgeResponseViewModel(string firstName, string lastName, int? updatedJudgeId)
        {
            FirstName = firstName;
            LastName = lastName;
            UpdatedJudgeId = updatedJudgeId;
        }
    }
}
