using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Judge
    {
        public Judge(string firstName, string lastName, int? judgeId = null) 
        {
            FirstName = firstName;
            LastName = lastName;
            JudgeId = judgeId;
        }
        public int? JudgeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
