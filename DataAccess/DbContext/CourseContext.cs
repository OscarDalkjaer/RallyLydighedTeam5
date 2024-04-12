using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public DbSet<Course> Courses { get; set; }


        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Judge> Judges { get; set; }
    }
}
