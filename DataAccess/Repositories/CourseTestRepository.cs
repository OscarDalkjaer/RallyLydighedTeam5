using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess.DataAccessModels;

namespace DataAccess.Repositories;

public class CourseTestRepository : ICourseRepository
{
    public List<Course> TestCourses { get; } = new List<Course>();

    public async Task<Course> AddCourse(Course course)
    {
        course.CourseId = TestCourses.Count + 1;
        int maxLengthOfExerciseList = course.GetMaxLengthOfExerciseList(course.Level);
        ExerciseTestRepository exerciseTestRepository = new ExerciseTestRepository();
        Exercise? nullExercise = await exerciseTestRepository.GetExercise(1);
        for (int i = 1; i <= maxLengthOfExerciseList; i++)
        {
            course.ExerciseList.Add(nullExercise);

        }
        TestCourses.Add(course);
        return course;

    }

    public async Task<Course?> GetCourse(int courseId)
    {
        Course? course = TestCourses.SingleOrDefault(c => c.CourseId == courseId);
        return await Task.FromResult(course);
    }

    public async Task<IEnumerable<Course>> GetAllCourses()
    {
        return await Task.FromResult(TestCourses);
    }

    //public async Task<Course?> UpdateCourse(Course course)
    //{
    //    Course? courseToUpdate = TestCourses.SingleOrDefault(c => c.CourseId == course.CourseId);

    //    if (courseToUpdate != null)
    //    {
    //        courseToUpdate.Level = course.Level;
    //        var rels = courseToUpdate.ExerciseList.Select(r => new CourseExerciseRelation
    //        {
    //            Course = courseToUpdate,
    //            Exercise = r
    //        });

    //        courseToUpdate.Relations.AddRange(rels);
    //        return await Task.FromResult(courseToUpdate);
    //    }

    //    return null;
    //}

    public async Task DeleteCourse(int courseId)
    {
        Course? course = TestCourses.SingleOrDefault(c => c.CourseId == courseId);

        if (course != null)
        {
            TestCourses.Remove(course);
        }

        await Task.CompletedTask;
    }

    public Task<Course?> UpdateCourse(Course course)
    {
        throw new NotImplementedException();
    }
}
