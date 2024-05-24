namespace DataAccess.DataAccessModels;

public class JudgeDataAccessModel
{
    public int? JudgeDataAccessModelId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    
    public JudgeDataAccessModel(string firstName, string lastName, int? judgeDataAccessModelId) 
    {
        FirstName = firstName;
        LastName = lastName;
        JudgeDataAccessModelId = judgeDataAccessModelId;
    }

   
}
