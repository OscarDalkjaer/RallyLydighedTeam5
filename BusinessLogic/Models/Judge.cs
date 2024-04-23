namespace BusinessLogic.Models
{
    public class Judge
    {
        public int? JudgeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Judge() { }

        public Judge(string firstName, string lastName, int? judgeId = null) 
        {
            FirstName = firstName;
            LastName = lastName;
            JudgeId = judgeId;
        }      
    }
}
