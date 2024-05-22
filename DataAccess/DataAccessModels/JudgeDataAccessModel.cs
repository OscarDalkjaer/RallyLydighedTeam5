using BusinessLogic.Models;

namespace DataAccess.DataAccessModels
{
    public class JudgeDataAccessModel
    {
        public int? JudgeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public JudgeDataAccessModel(Judge judge) 
        {
            JudgeId = judge.JudgeId;
            FirstName = judge.FirstName;
            LastName = judge.LastName;            
        }

       
    }
}
