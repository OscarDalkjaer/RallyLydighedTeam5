using API.ViewModels;
using BusinessLogic.Models;
using BusinessLogic.Services;
using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class UpdateCourseRequestViewModel
    //IValidatableObject er en indbygget interface i .NET Framework og .NET Core. Det bruges til at
    //udføre brugerdefineret validering på modeller. Ved at implementere IValidatableObject i din model
    //kan du specificere brugerdefinerede valideringslogikker, der udføres efter de standard datavalideringsattributter.
    {
       

        public int CourseId { get; set; }
        public LevelEnum Level { get; set; }
        
        
        //public List<UpdateExerciseViewModel> UpdateExerciseVMList { get;  }

        //public Event Event { get; set; } = new Event("Der er ikke tilknyttet et event endnu");
        //public Judge Judge { get; set; } = new Judge("Der er ikke tilknyttet en dommer endnu");
        //
        public List<int> ExerciseNumbers { get; set; }
        //public UpdateCourseRequestViewModel(int courseId, 
        //    LevelEnum level, List<UpdateExerciseViewModel> updateExerciseVMList)
        //{
        //    CourseId = courseId;
        //    Level = level;
        //    UpdateExerciseVMList = updateExerciseVMList;

        //}
       // [Range(1, int.MaxValue, ErrorMessage = "DommerId skal være større end 0 ")]
        public int JudgeId { get; set; }
        public int EventId { get; set; }

       
        //public UpdateCourseRequestViewModel(JudgeCountIdService judgeCountIdService)
        //{
        //    _judgeCountIdService = judgeCountIdService;
        //    InitializeMaxJudgeId();
        //}
        
        public UpdateCourseRequestViewModel(int courseId,
            LevelEnum level, List<int> updatedExerciseNumbers)
        {
            CourseId = courseId;
            Level = level;
            ExerciseNumbers = updatedExerciseNumbers;
           
        }

        
        //public async Task<int?> GetMaxJudgeId()
        //{
            
        //    return MaxJudgeId = await _judgeCountIdService.GetMaxJudgeId();

        //}

        public UpdateCourseRequestViewModel() { }

       
       
    }
}






