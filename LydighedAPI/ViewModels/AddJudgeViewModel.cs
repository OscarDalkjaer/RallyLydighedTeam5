namespace API.ViewModels
{
    public class AddJudgeViewModel
    {
        public AddJudgeViewModel(string firstName, object lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public object LastName { get; }
    }
}
