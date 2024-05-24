using Core.Domain.Entities;

namespace API.ViewModels;

public class UpdateCourseResponse
{
    public int CourseId { get; set; }
    public LevelEnum Level { get; set; }
    public List<UpdateExerciseResponseViewModel> UpdateExerciseVMList { get; set; }
    public List<string> StatusStrings { get; set; }        
    public Event? Event { get; set; } 
    public Judge? Judge { get; set; } 

    public UpdateCourseResponse(int courseId, LevelEnum level, 
        List<UpdateExerciseResponseViewModel> updateExerciseVMList, 
        List<string> statusStrings, Judge? judge, Event? @event)
    {
        CourseId = courseId;
        Level = level;
        UpdateExerciseVMList = updateExerciseVMList;
        StatusStrings = statusStrings;
        Judge = judge;
        Event = @event;
    }
}
