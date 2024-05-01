namespace BusinessLogic.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public int Number { get; set; }
        public TypeEnum? Type { get; set; }
        //public List<Course> CourseList { get; set; } = new List<Course>();
        //public List<CourseExerciseRelation> Relations { get; set; }


        public Exercise(int exerciseId, int number, TypeEnum? type)
        {
            ExerciseId = exerciseId;
            Number = number;
            Type = type;
        }

        public Exercise()
        {
        }

        public Exercise(int number, TypeEnum? type)
        {

            Number = number;
            Type = type;
        }
    }
    }
