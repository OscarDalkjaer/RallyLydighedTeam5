namespace BusinessLogic.Models
{
    public class Judge
    {

        protected Judge() { }
        public Judge(string firstName, string lastName, int? judgeId = null) 
        {
            FirstName = firstName;
            LastName = lastName;
            JudgeId = judgeId;
        }
        public int? JudgeId { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
