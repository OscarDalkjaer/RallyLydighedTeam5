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
            modelBuilder.Entity<CourseDataAccessModel>()   
                .HasMany(x => x.CourseExerciseRelations);
            //.WithMany(x => x.CourseDataAccessModels)
            //.UsingEntity<CourseExerciseRelation>();

            modelBuilder.Entity<CourseExerciseRelation>()   //Making a manyToManyRelation
                //.HasMany(x => x.CourseDataAccessModel)
                .HasOne(x => x.CourseDataAccessModel);

            modelBuilder.Entity<ExerciseDataAccessModel>()
                .HasData(Seeder.ExerciseDataAccessModels);

            modelBuilder.Entity<Judge>()
                .HasData(new Judge("Peter", "Madsen", 3));

            modelBuilder.Entity<Event>()
                .HasData(new Event("Odense RallyEvent", new DateTime(2024, 08, 08), "5000 Odense", -1));

                



        }
    }
}
