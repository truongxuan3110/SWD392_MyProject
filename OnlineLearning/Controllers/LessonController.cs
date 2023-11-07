using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.DTOs;
using OnlineLearning.Entities;
using OnlineLearning.Repositories;

namespace OnlineLearning.Controllers
{
    [ApiController]
    public class LessonController : ControllerBase
    {
        private ILessonRepository _repository = new LessonRepository();
        private readonly IMapper _mapper;

        public LessonController(IMapper mapper, ILessonRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        [HttpGet("api/course/chapter/listlesson")]
        public IActionResult GetLessons(int? chapterId)
        {
            var p = _repository.GetAllLesson(chapterId);
            return Ok(p);
        }

        [HttpGet("api/course/chapter/lesson/{id}")]
        public IActionResult GetLesson(int id)
        {
            var Lesson = _repository.GetLessonById(id);
            if (Lesson == null)
            {
                return NotFound();
            }
            return Ok(Lesson);
        }

        [HttpPost("api/course/chapter/lesson/add")]
        public IActionResult AddLesson(LessonAddUpdateDTO Lesson)
        {
            try
            {
                var c = _mapper.Map<Lesson>(Lesson);
                _repository.AddLesson(c);
                return Ok("Add Successful!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("api/course/chapter/Lesson/update/{id}")]
        public IActionResult UpdateLesson(int id, LessonAddUpdateDTO Lesson)
        {
            try
            {
                var c = _mapper.Map<Lesson>(Lesson);
                c.Id = id;
                _repository.UpdateLesson(c);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("api/course/chapter/Lesson/delete")]
        public IActionResult DeleteLesson(int LessonId)
        {
            try
            {
                 _repository.DeleteLesson(LessonId);
                return Ok("Delete Successful!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost("api/course/chapter/lesson/addquiz")]
        public IActionResult AddListQuiz(LessonAddQuizDTO inputDto)
        {
            try
            {
                var context = new OnlineLearningContext();
                var c = context.Lessons.FirstOrDefault(x => x.Id == inputDto.LessonId);
                if (c != null)
                {
                    foreach (var item in inputDto.ListQuiz)
                    {
                        item.LessonId = inputDto.LessonId;
                        context.Quizzes.Update(item);
                        context.SaveChanges();
                    }
                }
                return Ok("Successful!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }   
}
