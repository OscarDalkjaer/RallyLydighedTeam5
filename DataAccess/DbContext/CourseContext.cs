using BusinessLogic.Models;
using DataAccess.DataAccessModels;
//using DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessDbContext
{
    
    public class CourseContext : DbContext
    {
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<ExerciseDataAccessModel> ExerciseDataAccessModels { get; set; }

        public DbSet<CourseDataAccessModel> CourseDataAccessModels { get; set; }

        public DbSet<CourseExerciseRelation> CourseExerciseRelations { get; set; }


        public CourseContext(DbContextOptions<CourseContext> context) : base(context) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDataAccessModel>()   
                .HasMany(x => x.CourseExerciseRelations);

            modelBuilder.Entity<CourseExerciseRelation>()   //Making a manyToManyRelation
                .HasOne(x => x.CourseDataAccessModel);
            
            modelBuilder.Entity<ExerciseDataAccessModel>().HasData(
                new ExerciseDataAccessModel
                {
                    ExerciseDataAccessModelId = -1,
                    Number = 0,                    
                    Name = "",
                    Description ="",
                    HandlingPosition = DefaultHandlingPositionEnum.Optional,
                    Stationary = false,
                    WithCone = false,
                    TypeOfJump = null,
                    Level = null
                },
                new ExerciseDataAccessModel
                {
                    ExerciseDataAccessModelId = 2,
                    Number = 2,
                    Name = "",
                    Description = "",
                    HandlingPosition = DefaultHandlingPositionEnum.Optional,
                    Stationary = false,
                    WithCone = false,
                    TypeOfJump = null,
                    Level = null
                }
            );
        }
    }
}
