using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;

namespace OnlineLearning.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCourseList();
        Task<Course> Create(Course course);
        Task<Course> GetById(int courseId);
        Task<Course> Update(Course course);
        Task Delete(int courseId);
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly OnlineLearningContext _context;

        public CourseRepository(OnlineLearningContext context)
        {
            _context = context;
        }

        public async Task<Course> Create(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task Delete(int courseId)
        {
            var course = await GetById(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Course> GetById(int courseId)
        {
            return await _context.Courses.FindAsync(courseId);
        }

        public async Task<IEnumerable<Course>> GetCourseList()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return course;
        }
    }
}
