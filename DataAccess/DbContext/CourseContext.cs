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

        modelBuilder.Entity<JudgeDataAccessModel>().HasData(
            new JudgeDataAccessModel("Peter", "Madsen", 1),
            new JudgeDataAccessModel("Minna", "Mogensen", 2),
            new JudgeDataAccessModel("Thilde", "Thrane", 3));

        modelBuilder.Entity<EventDataAccessModel>().HasData(
            new EventDataAccessModel("Odense RallyEvent", new DateTime(2024, 08, 08), "5000 Odense", 1),
            new EventDataAccessModel("Billund Rally-Cup", new DateTime(2024, 01, 09), "7190 Billund", 2),
            new EventDataAccessModel("Roskilde Rally", new DateTime(2025, 02, 04), "4000 Roskilde", 3));

        SeedEntityFrameworkIdentityUsewrsAndRoles(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void SeedEntityFrameworkIdentityUsewrsAndRoles(ModelBuilder modelBuilder)
    {
        string userIdForUlla = "9d8b0a60-e3b1-4088-9ff5-6b0a68d80cac";
        string userIdForOscar = "1ca1abc7-24b8-4d66-a7b1-b21adc12101c";
        string userIdForLyanne = "f47c5bf1-740c-4fb9-94b7-941e90ad7d23";

        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = userIdForUlla,
                UserName = "ulla@test.com",
                NormalizedUserName = "ulla@test.com".ToUpper(),
                Email = "ulla@test.com",
                NormalizedEmail = "ulla@test.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
            },
            new IdentityUser
            {
                Id = userIdForOscar,
                UserName = "oscar",
                NormalizedUserName = "oscar".ToUpper(),
                Email = "oscar@test.com",
                NormalizedEmail = "oscar@test.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
            },
            new IdentityUser
            {
                Id = userIdForLyanne,
                UserName = "lyanne",
                NormalizedUserName = "lyanne".ToUpper(),
                Email = "lyanne@test.com",
                NormalizedEmail = "lyanne@test.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null!, "Pa$$w0rd")
            });
    }
}