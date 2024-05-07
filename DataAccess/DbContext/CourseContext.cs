using BusinessLogic.Models;
using DataAccess.DataAccessModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessDbContext
{
    
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> context) : base(context)
        {
        }

        public DbSet<Judge> Judges { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<ExerciseDataAccessModel> ExerciseDataAccessModels { get; set; }

        public DbSet<CourseDataAccessModel> CourseDataAccessModels { get; set; }

        public DbSet<CourseExerciseRelation> CourseExerciseRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDataAccessModel>()   //Making a manyToManyRelation
                .HasMany(x => x.CourseExerciseRelations);
            //.WithMany(x => x.CourseDataAccessModels)
            //.UsingEntity<CourseExerciseRelation>();

            modelBuilder.Entity<CourseExerciseRelation>()   //Making a manyToManyRelation
                //.HasMany(x => x.CourseDataAccessModel)
                .HasOne(x => x.CourseDataAccessModel);
            
            modelBuilder.Entity<ExerciseDataAccessModel>().HasData(
                new ExerciseDataAccessModel
                {
                    ExerciseDataAccessModelId = 1,
                    Number = 0,
                    Type = null
                },
                new ExerciseDataAccessModel
                {
                    ExerciseDataAccessModelId = 2,
                    Number = 2,
                    Type = TypeEnum.Jump
                }
            );
        }
    }
}
