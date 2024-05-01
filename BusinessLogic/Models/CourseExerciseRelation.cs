namespace BusinessLogic.Models
{
    public class CourseExerciseRelation
    {
        public int Id { get; set; }
        public Course Course { get; set; } = null!;
        public Exercise Exercise { get; set; } = null!;
    }
    
}
