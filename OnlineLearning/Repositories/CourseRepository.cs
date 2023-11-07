using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;

namespace OnlineLearning.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourseList();
        Course Create(Course course);
        Course GetById(int courseId);
        void Update(Course course);
        void Delete(int courseId);
    }
    public class CourseRepository : ICourseRepository
    {
        private readonly OnlineLearningContext _context;

        public CourseRepository(OnlineLearningContext context)
        {
            _context = context;
        }

        public Course Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }

        public void Delete(int courseId)
        {
            var course = GetById(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public Course GetById(int courseId)
        {
            return _context.Courses.Find(courseId);
        }

        public IEnumerable<Course> GetCourseList()
        {
            return _context.Courses.ToList();
        }

        public void Update(Course course)
        {
            course.LastUpdated = DateTime.Now;
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
