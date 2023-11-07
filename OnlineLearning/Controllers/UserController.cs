using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.DTOs;
using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Controllers
{
    [Route("api/user-management/users/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult getUserList()
        {
            try
            {
                var raw_users = _userService.GetUserList();
              
                return Ok(raw_users);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving courses");
            }
        }

        [HttpGet("{id}")]
        public ActionResult FindUserById(int id)
        {
            try
            {
                var user = _userService.GetUser(id);

                if (user == null)
                {
                    return NotFound(); // Trả về 404 Not Found nếu không tìm thấy khóa học với ID cung cấp
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving user");
            }
        }

        [HttpPost]
        public ActionResult CreateUser(UserDTO userDTO)
        {
            try
            {
                User user = _mapper.Map<User>(userDTO);
                var status = _userService.CreateUser(user);
                if(status == null) return StatusCode(StatusCodes.Status409Conflict, "Conflict data");
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating user");
            }
        }




        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserDTO userDTO)
        {
            User user = _userService.GetUser(id);
            if (user == null)
                return NotFound();

            try
            {
                User updateUser = _mapper.Map(userDTO, user);

                var status = _userService.UpdateUser(updateUser);
                if (status == null) return StatusCode(StatusCodes.Status409Conflict, "Conflict user data");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating course");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var userToDelete = _userService.GetUser(id);

                if (userToDelete == null)
                {
                    return NotFound(); // Trả về 404 Not Found nếu không tìm thấy khóa học với ID cung cấp
                }

                _userService.DeleteUser(id);
                return Ok(); // Trả về 204 No Content nếu xóa thành công
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting course");
            }
        }

    }
}
