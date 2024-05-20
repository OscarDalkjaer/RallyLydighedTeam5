using BusinessLogic.Models;

namespace API.ViewModels
{
    public class GetJudgeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? JudgeId { get; set; }


        public GetJudgeViewModel() { }

        public GetJudgeViewModel(int? judgeId, string firstName, string lastName) 
        {
            FirstName = firstName;
            LastName = lastName;

        }     
    }
}