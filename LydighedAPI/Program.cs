using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.Repositories;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container<e.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CourseContext>(DbContextOptions => 
{
    DbContextOptions.LogTo(sql => System.Diagnostics.Debug.WriteLine(sql));
    DbContextOptions.EnableSensitiveDataLogging();
    DbContextOptions.ConfigureWarnings(c => c.Log(RelationalEventId.CommandExecuting));
    DbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});


builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IJudgeRepository, JudgeRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
//builder.Services.AddScoped<CourseBuilder>();


var app = builder.Build();

//using var scope = app.Services.CreateScope();
//var context = scope.ServiceProvider.GetRequiredService<CourseContext>();
//CourseContext.Seed(context); 


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
