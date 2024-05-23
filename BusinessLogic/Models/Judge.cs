
using BusinessLogic.Services;

namespace BusinessLogic.Models
{
    public class Judge
    {     
        public int? JudgeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
               
        public Judge(string name) { }
        public Judge(string firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;           
        }

        public Judge(string firstName, string? lastName, int? judgeId) 
        {
            FirstName = firstName;
            LastName = lastName;
            JudgeId = judgeId;
        }     

        public Judge(int? judgeId) 
        {
            JudgeId = judgeId;
        }

       
    }
}
