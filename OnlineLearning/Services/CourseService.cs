using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.Entities;
using OnlineLearning.Repositories;

namespace OnlineLearning.Services
{
    
    public class CourseService 
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetCourseList()
        {
            return await _courseRepository.GetCourseList();
        }

        public async Task<Course> CreateCourse(Course course)
        {
            return await _courseRepository.Create(course);
        }

        public async Task<Course> GetCourse(int courseId)
        {
            return await _courseRepository.GetById(courseId);
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            return await _courseRepository.Update(course);
        }

        public async Task DeleteCourse(int courseId)
        {
            await _courseRepository.Delete(courseId);
        }
    }
}
