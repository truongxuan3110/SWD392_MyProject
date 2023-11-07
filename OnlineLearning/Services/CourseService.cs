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

        public  IEnumerable<Course> GetCourseList()
        {
            return  _courseRepository.GetCourseList();
        }

        public Course CreateCourse(Course course)
        {
            return  _courseRepository.Create(course);
        }

        public  Course GetCourse(int courseId)
        {
            return  _courseRepository.GetById(courseId);
        }

        public  void UpdateCourse(Course course)
        {
             _courseRepository.Update(course);
        }

        public void  DeleteCourse(int courseId)
        {
             _courseRepository.Delete(courseId);
        }
    }
}
