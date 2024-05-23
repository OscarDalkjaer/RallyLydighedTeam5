namespace API.ViewModels
{
    public class AddJudgeResponseViewModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int? JudgeId { get; }
        public AddJudgeResponseViewModel(string firstName, string lastName, int? judgeId)
        {
            FirstName = firstName;
            LastName = lastName;
        }

       

    }


    
}
}
