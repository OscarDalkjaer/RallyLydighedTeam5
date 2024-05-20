using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.DataAccessModels;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;
        private readonly IExerciseRepository _exerciseRepository;
        

        public CourseRepository(CourseContext context, IExerciseRepository exerciseRepository)
        {
            _context = context;
            _exerciseRepository = exerciseRepository;
        }


        public async Task<Course?> AddCourse(Course course)
        {
            int maxLengthOfExerciseList = course.GetMaxLengthOfExerciseList(course.Level);

            CourseDataAccessModel courseDataAccessModel = new CourseDataAccessModel(course);
            ExerciseDataAccessModel nullExerciseDataAccessModel = await _context.ExerciseDataAccessModels
                     .SingleAsync(x => x.ExerciseDataAccessModelId == -1);

            for (int i = 1; i <= maxLengthOfExerciseList; i++)
            {
                courseDataAccessModel.AddRelation(nullExerciseDataAccessModel);

            }

            _context.CourseDataAccessModels.Add(courseDataAccessModel);
            await _context.SaveChangesAsync();

            Course courseWithNullValues = courseDataAccessModel.FromDataAccesModelToCourse();
            return courseWithNullValues;          
        }
        

        public async Task<Course?> UpdateCourse(Course course)
        {
            CourseDataAccessModel toUpdate = CourseDataAccessModel.FromCourseToDataAccessModel(course);
            _context.Attach(toUpdate);
           
            await _context.SaveChangesAsync();

            return course;
        }


        public Task AddToExerciseList(Course course, List<ExerciseDataAccessModel> exerciseDataAccessModels)
        {
            if (exerciseDataAccessModels.Count > 0) 
            {
                foreach (ExerciseDataAccessModel exerciseDataAccessModel in exerciseDataAccessModels)
                {
                    course.ExerciseList.Add(new Exercise(
                        exerciseDataAccessModel.ExerciseDataAccessModelId,
                        exerciseDataAccessModel.Number,
                        exerciseDataAccessModel.Name, 
                        exerciseDataAccessModel.Description, 
                        exerciseDataAccessModel.HandlingPosition,
                        exerciseDataAccessModel.Stationary, 
                        exerciseDataAccessModel.WithCone, 
                        exerciseDataAccessModel.TypeOfJump, 
                        exerciseDataAccessModel.Level)
                        );
                }
            }
            return Task.CompletedTask;
        }


        public async Task<Course?> GetCourse(int courseId)
        {
            CourseDataAccessModel? courseDataAccessModel = await _context.CourseDataAccessModels
                .Include(x => x.CourseExerciseRelations)
                .ThenInclude(x => x.ExerciseDataAccessModel)
                .FirstOrDefaultAsync(c => c.CourseDataAccessModelId == courseId);
            Course course = courseDataAccessModel.FromDataAccesModelToCourse();
            return course;
        }


        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            List<CourseDataAccessModel> courseDataAccessModels = await _context.CourseDataAccessModels
                .Include (x => x.CourseExerciseRelations)
                .ThenInclude(x => x.ExerciseDataAccessModel)
                .ToListAsync();
            List<Course> courses = courseDataAccessModels.Select(x => x.FromDataAccesModelToCourse()).ToList();
            return courses;
        }


        public async Task DeleteCourse(int courseId)
        {
            CourseDataAccessModel? courseDataAccessModel = 
                await _context.CourseDataAccessModels.FirstOrDefaultAsync(c => c.CourseDataAccessModelId == courseId);

            if (courseDataAccessModel != null)
            {
                _context.CourseDataAccessModels.Remove(courseDataAccessModel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
