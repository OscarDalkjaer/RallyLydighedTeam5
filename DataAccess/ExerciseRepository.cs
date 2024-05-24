using Core.Domain.Entities;
using Core.Domain.Entities;
using Core.Domain.Services;
using DataAccess.DataAccessModels;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ExerciseRepository : IExerciseRepository
{
    private readonly CourseContext _context;
    public ExerciseRepository(CourseContext context)
    {
        _context = context;
    }

    public async Task AddExercise(Exercise exercise)
    {
        var dataModel = new ExerciseDataAccessModel(exercise.Number, exercise.Name, exercise.Description, exercise.DefaultHandlingPosition,
            exercise.Stationary, exercise.WithCone, exercise.TypeOfJump, exercise.Level);
        _context.ExerciseDataAccessModels.Add(dataModel);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Exercise>> GetAllExercises()
    {
        var dataModels = await _context.ExerciseDataAccessModels.ToListAsync();
        return dataModels.Select(x => new Exercise(x.ExerciseDataAccessModelId, x.Number, x.Name, x.Description, x.HandlingPosition,
            x.Stationary, x.WithCone, x.TypeOfJump, x.Level));
    }

    public async Task<ExerciseDataAccessModel?> GetExerciseDataAccessModel(int exerciseId)
    {
        return await _context.ExerciseDataAccessModels.FirstOrDefaultAsync(e => e.ExerciseDataAccessModelId == exerciseId);
    }

    public async Task UpdateExercise(Exercise exercise)
    {
        ExerciseDataAccessModel? exerciseToUpdate = await _context.ExerciseDataAccessModels
            .SingleOrDefaultAsync(e => e.ExerciseDataAccessModelId == exercise.ExerciseId);

        if (exerciseToUpdate != null)
        {
            exerciseToUpdate.Number = exercise.Number;
            exerciseToUpdate.Name = exercise.Name;
            exerciseToUpdate.Description = exercise.Description;
            exerciseToUpdate.HandlingPosition = exercise.DefaultHandlingPosition;
            exerciseToUpdate.Stationary = exercise.Stationary;
            exerciseToUpdate.WithCone = exercise.WithCone;
            exerciseToUpdate.TypeOfJump = exercise.TypeOfJump;
            exerciseToUpdate.Level = exercise.Level;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteExercise(int exerciseId)
    {
        ExerciseDataAccessModel? exercise = await _context.ExerciseDataAccessModels
            .SingleOrDefaultAsync(e => e.ExerciseDataAccessModelId == exerciseId);

        if (exercise != null)
        {
            _context.ExerciseDataAccessModels.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Exercise?> GetExercise(int exerciseId)
    {
        ExerciseDataAccessModel? exerciseDataAccessModel = await _context.ExerciseDataAccessModels
            .SingleOrDefaultAsync(x => x.ExerciseDataAccessModelId == exerciseId);

        if (exerciseDataAccessModel != null)
        {
            Exercise exercise = new Exercise(
                exerciseDataAccessModel.ExerciseDataAccessModelId,
                exerciseDataAccessModel.Number,
                exerciseDataAccessModel.Name,
                exerciseDataAccessModel.Description,
                exerciseDataAccessModel.HandlingPosition,
                exerciseDataAccessModel.Stationary,
                exerciseDataAccessModel.WithCone,
                exerciseDataAccessModel.TypeOfJump,
                exerciseDataAccessModel.Level);

            return exercise;
        }
        return null;
    }

    public async Task<(List<Exercise>, List<string>)> GetExercisesFromNumbers(List<int> exerciseNumbers) //mangler en test
    {
        List<ExerciseDataAccessModel> dataAccessModels = new List<ExerciseDataAccessModel>();
        List<Exercise> exercises = new List<Exercise>();
        List<string> exercisePregisteredStatus = new List<string>();

        foreach (int number in exerciseNumbers)
        {
            if (number > 0)
            {

                ExerciseDataAccessModel? model = await _context.ExerciseDataAccessModels.SingleOrDefaultAsync(x
                => x.Number == number);

                if (model == null)
                {
                    exercisePregisteredStatus.Add(new string($"Øvelsen med nummer {number} er ikke registreret i databasen"));
                    ExerciseDataAccessModel nullModel = new ExerciseDataAccessModel(-1, 0, "", "", DefaultHandlingPositionEnum.Optional, false, false, null, LevelEnum.Beginner);
                    dataAccessModels.Add(nullModel);
                }

                dataAccessModels.Add(model);
            }
        }
        foreach (ExerciseDataAccessModel model in dataAccessModels)
        {
            if (model != null)
            {
                Exercise exercise = new Exercise(model.ExerciseDataAccessModelId, model.Number, model.Name,
                model.Description, model.HandlingPosition, model.Stationary, model.WithCone,
                model.TypeOfJump, model.Level);
                exercises.Add(exercise);
            }
            else
            {
                Exercise notRegisteredExercise = new Exercise(0, 0);
            }

        }
        return (exercises, exercisePregisteredStatus);
    }
}
