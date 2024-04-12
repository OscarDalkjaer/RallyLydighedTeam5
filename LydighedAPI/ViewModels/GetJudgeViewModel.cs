using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetJudgeViewModel
    {
        public GetJudgeViewModel(Judge judge) 
        {
            FirstName = judge.FirstName;
            LastName = judge.LastName;

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}