﻿using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.DataAccessModels;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly CourseContext _context;
    public ExerciseRepository(CourseContext context)
    {
        _context = context;
    }

    public async Task AddExercise(Exercise exercise)
    {
        var dataModel = new ExerciseDataAccessModel(exercise.Number, exercise.Name, exercise.Description, exercise.HandlingPosition,
            exercise.Stationary, exercise.WithCone, exercise.TypeOfJump, exercise.Level) ;
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
            exerciseToUpdate.HandlingPosition = exercise.HandlingPosition;
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
            .SingleOrDefaultAsync(e => e.ExerciseDataAccessModelId== exerciseId);

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

        if(exerciseDataAccessModel != null) 
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

    //public async Task<ExerciseDataAccessModel?> GetNullExerciseDataAccessModel()
    //{
    //    ExerciseDataAccessModel? nullExerciseDataAccessModel = _context.ExerciseDataAccessModels.SingleOrDefault(x =>
    //    x.ExerciseId == 1);
    //    return nullExerciseDataAccessModel;

    //}
}
