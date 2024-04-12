namespace API.ViewModels
{
    public class AddJudgeViewModel
    {
        public AddJudgeViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
