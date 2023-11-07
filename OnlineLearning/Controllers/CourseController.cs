using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.DTOs;
using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Controllers
{
    [Route("api/course-management/courses/")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(CourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getAllCourse()
        {
            try
            {
                var raw_course = _courseService.GetCourseList();
                var courses = _mapper.Map<List<CourseDTOInList>>(raw_course);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving courses");
            }
        }

        [HttpGet("{id}")]
        public IActionResult FindCourseById(int id)
        {
            try
            {
                var course = _courseService.GetCourse(id);

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




        [HttpPost]
        public IActionResult CreateCourse([FromForm] CourseDTOCreateUpdate courseDtoCU, IFormFile image)
        {
            try
            {
                CourseDTO courseDto = _mapper.Map<CourseDTO>(courseDtoCU);

                courseDto.ImageUrl = Utils.CommonUtil.ConvertToBase64(image); // Lưu hình ảnh dưới dạng chuỗi Base64 vào DTO

                Course course = _mapper.Map<Course>(courseDto);
                _courseService.CreateCourse(course);
                return Ok(course);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating course");
            }
        }




        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromForm] CourseDTOCreateUpdate courseDtoCU, IFormFile? image)
        {
            Course course = _courseService.GetCourse(id);
            CourseDTO courseDTO = _mapper.Map<CourseDTO>(courseDtoCU);
            if (image != null && image.Length > 0)
            {
                courseDTO.ImageUrl =  Utils.CommonUtil.ConvertToBase64(image);
            }
            else
            {
                courseDTO.ImageUrl = course.ImageUrl;
            }
                
           
         
            if (course == null)
                return NotFound();

            try
            {
                Course updateCourse = _mapper.Map(courseDTO, course);
                _courseService.UpdateCourse(updateCourse);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating course");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                var courseToDelete = _courseService.GetCourse(id);

                if (courseToDelete == null)
                {
                    return NotFound(); // Trả về 404 Not Found nếu không tìm thấy khóa học với ID cung cấp
                }

                _courseService.DeleteCourse(id);
                return NoContent(); // Trả về 204 No Content nếu xóa thành công
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting course");
            }
        }

    }
}
