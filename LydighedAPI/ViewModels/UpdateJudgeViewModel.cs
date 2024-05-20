namespace API.ViewModels
{
    public class UpdateJudgeViewModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int UpdatedJudgeId { get; private set; }


        public UpdateJudgeViewModel(string firstName, string lastName, int updatedJudgeId)
        {
            FirstName = firstName;
            LastName = lastName;
            UpdatedJudgeId = updatedJudgeId;
        }
    }
}
