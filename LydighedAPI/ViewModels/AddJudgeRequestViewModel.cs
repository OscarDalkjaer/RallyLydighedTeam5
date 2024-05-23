namespace API.ViewModels
{
    public class AddJudgeRequestViewModel
    {
        public AddJudgeRequestViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
