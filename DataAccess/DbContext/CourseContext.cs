using BusinessLogic.Models;
using DataAccess.DataAccessModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessDbContext;

public class CourseContext : IdentityDbContext <IdentityUser>
{
    public CourseContext(DbContextOptions<CourseContext> context) : base(context)
    {
    }

    // public CourseContext()
    // {

    // }
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     // docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=Passw0rd' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
    //     // dotnet ef database update --project DataAccess

    //     optionsBuilder.UseSqlServer("Server=localhost;Database=RallyTeam5DB;User Id=sa;Password=Passw0rd;TrustServerCertificate=True;");
    //     base.OnConfiguring(optionsBuilder);
    // }



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
        
        modelBuilder.Entity<ExerciseDataAccessModel>().HasData(
            new ExerciseDataAccessModel
            {
                ExerciseDataAccessModelId = 1,
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

        base.OnModelCreating(modelBuilder);
    }
}
