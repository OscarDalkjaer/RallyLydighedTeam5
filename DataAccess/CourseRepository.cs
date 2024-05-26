using Core.Domain.Entities;
using Core.Domain.Services;
using DataAccess.DataAccessModels;
using DataAccessDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _context;

        public CourseRepository(CourseContext context)
        {
            _context = context;
        }

        public async Task<Course?> AddCourse(Course course)
        {
            int maxLengthOfExerciseList = course.GetMaxLengthOfExerciseList(course.Level);

            CourseDataAccessModel courseDataAccessModel = new CourseDataAccessModel(course);
            ExerciseDataAccessModel nullExerciseDataAccessModel = await _context.ExerciseDataAccessModels
                     .SingleAsync(x => x.ExerciseDataAccessModelId == -1);

            ExerciseRepository exerciseRepository = new ExerciseRepository(_context);
            ExerciseDataAccessModel? start =  await exerciseRepository.GetExerciseDataAccessModel(1);
            ExerciseDataAccessModel? end = await exerciseRepository.GetExerciseDataAccessModel(2);

            if(start != null) 
            {
                courseDataAccessModel.AddRelation(start);
            }
           
            for (int i = 1; i < maxLengthOfExerciseList; i++)
            {
                courseDataAccessModel.AddRelation(nullExerciseDataAccessModel);

            }

            if (end != null)
            {
                courseDataAccessModel.AddRelation(end);
            }

            _context.CourseDataAccessModels.Add(courseDataAccessModel);
            await _context.SaveChangesAsync();

            Course courseWithNullValues = courseDataAccessModel.FromDataAccesModelToCourse();
            return courseWithNullValues;
        }

        public async Task UpdateCourse(Course course)
        {
            CourseDataAccessModel toUpdate = CourseDataAccessModel.FromCourseToDataAccessModel(course);
            _context.Entry(toUpdate).State = EntityState.Modified;
            _context.Update(toUpdate);

            await _context.SaveChangesAsync();
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
                .Include(x => x.CourseExerciseRelations)
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

        public async Task<List<Course>> GetAllCoursesWithSpecifiedTheme(ThemeEnum theme)
        {
            List<Course> courses = new List<Course>();
            List<CourseDataAccessModel> accessmodels = _context.CourseDataAccessModels.Where(x => x.Theme == theme).ToList();
            foreach (var accessmodel in accessmodels)
            {
                Course course = accessmodel.FromDataAccesModelToCourse();
                courses.Add(course);
            }
            return courses;

        }

        public async Task<List<Course>> GetAllCoursesWithSpecifiedRangeOfExerciseCount(int rangeLow, int rangeHigh)
        {
            List<Course> courses = new List<Course>();

            IEnumerable<CourseDataAccessModel> accessmodels = await _context.CourseDataAccessModels
                .Where(x => x.ExerciseCount >= rangeLow && x.ExerciseCount <= rangeHigh).ToListAsync();

            foreach (var accessmodel in accessmodels)
            {
                Course course = accessmodel.FromDataAccesModelToCourse();
                courses.Add(course);
            }

            return courses;
        }
    }
}
