using BusinessLogic.Services;
using DataAccess.Repositories;
using DataAccessDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(polycy => polycy
        .WithOrigins("https://localhost:7068")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    );
});

builder.Services.AddControllers();
// builder.Services.AddControllersWithViews();
// builder.Services.AddRazorPages();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// (options =>
// {
//     options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//     {
//         In = ParameterLocation.Header,
//         Name = "Authorization",
//         Type = SecuritySchemeType.ApiKey
//     });
//     options.OperationFilter<SecurityRequirementsOperationFilter>();
// });

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


builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<CourseContext>()
    .AddApiEndpoints();

//builder.Services.AddAuthorization();
// (options =>
// {
//     options.AddPolicy("RequireAdministratorRole",
//          policy => policy.RequireRole("Admin", "User"));
// });

// builder.Services.AddIdentityApiEndpoints<IdentityUser>()
//     .AddRoles<IdentityRole>()
//     .AddEntityFrameworkStores<CourseContext>();

var app = builder.Build();

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

app.UseCors();
app.MapIdentityApi<IdentityUser>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();