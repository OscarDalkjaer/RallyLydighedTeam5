﻿using BusinessLogic.Models;
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

        public DbSet<JudgeDataAccessModel> JudgeDataAccessModels { get; set; }
        public DbSet<EventDataAccessModel> EventDataAccessModels { get; set; }
        public DbSet<ExerciseDataAccessModel> ExerciseDataAccessModels { get; set; }
        public DbSet<CourseDataAccessModel> CourseDataAccessModels { get; set; }
        public DbSet<CourseExerciseRelation> CourseExerciseRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDataAccessModel>()   
                .HasMany(x => x.CourseExerciseRelations);
           
            modelBuilder.Entity<CourseExerciseRelation>()  
                .HasOne(x => x.CourseDataAccessModel);

            modelBuilder.Entity<ExerciseDataAccessModel>()
                .HasData(Seeder.ExerciseDataAccessModels);

            modelBuilder.Entity<JudgeDataAccessModel>()
                .HasData(
                new JudgeDataAccessModel("Peter", "Madsen", 1),
                new JudgeDataAccessModel("Minna", "Mogensen", 2),
                new JudgeDataAccessModel("Thilde", "Thrane", 3)
                );

            modelBuilder.Entity<EventDataAccessModel>()
                .HasData(
                new EventDataAccessModel("Odense RallyEvent", new DateTime(2024, 08, 08), "5000 Odense", 1),
                new EventDataAccessModel("Billund Rally-Cup", new DateTime(2024, 01, 09), "7190 Billund", 2),
                new EventDataAccessModel("Roskilde Rally", new DateTime(2025, 02, 04), "4000 Roskilde", 3)
                );

                

                



        }
    }
}
