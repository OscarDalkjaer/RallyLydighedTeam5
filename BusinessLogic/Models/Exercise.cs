namespace BusinessLogic.Models
{
    public class Exercise
    {
        public Exercise (int exerciseId, int number, LevelEnum level, TypeEnum type)
        {
            ExerciseId = exerciseId;
            Number = number;
            Level = level;
            Type = type;
        }

        public int ExerciseId { get; private set; }
        public int Number { get; private set; }
        public LevelEnum Level { get; private set; }
        public TypeEnum Type { get; private set; }
    }
}