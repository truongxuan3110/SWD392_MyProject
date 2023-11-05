using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> getAllCourse()
        {
            try
            {
                var courses = await _courseService.GetCourseList();
                return Ok(courses);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving courses");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> FindCourseById(int id)
        {
            try
            {
                var course = await _courseService.GetCourse(id);

                if (course == null)
                {
                    return NotFound(); // Trả về 404 Not Found nếu không tìm thấy khóa học với ID cung cấp
                }

                return Ok(course);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving course");
            }
        }

    }
}
