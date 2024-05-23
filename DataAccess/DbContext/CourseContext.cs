using BusinessLogic.Models;
using DataAccess.DataAccessModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessDbContext;

public class CourseContext : IdentityDbContext<IdentityUser>
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

        base.OnModelCreating(modelBuilder);
    }
}
