using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.DTOs;
using OnlineLearning.Entities;
using OnlineLearning.Repositories;

namespace OnlineLearning.Controllers
{
   // [Route("api/course/[controller]")]

    [ApiController]
    public class ChapterController : ControllerBase
    {
        private IChapterRepository _repository = new ChapterRepository();
        private readonly IMapper _mapper;

        public ChapterController(IMapper mapper, IChapterRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("api/course/listchapter")]
        public IActionResult GetChapters(int? courseId)
        {
            var p = _repository.GetAllChapter(courseId);
            return Ok(p);
        }

        [HttpGet("api/course/chapter/{id}")]
        public IActionResult GetChapter(int id)
        {
            var chapter = _repository.GetChapterById(id);
            if (chapter == null)
            {
                return NotFound();
            }
            return Ok(chapter);
        }

        [HttpPost("api/course/chapter/add")]
        public IActionResult AddChapter(ChapterAddUpdateDTO chapter)
        {
            try
            {
                var c = _mapper.Map<Chapter>(chapter);
                _repository.AddChapter(c);
                return Ok("Add Successful!");
            }
            catch (Exception)
            {
                return BadRequest();
            }                 
        }

        [HttpPut("api/course/chapter/update/{id}")]
        public IActionResult UpdateChapter(int id, ChapterAddUpdateDTO chapter)
        {
            try
            {
                var c = _mapper.Map<Chapter>(chapter);
                c.Id = id;
                _repository.UpdateChapter(c);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("api/course/chapter/delete")]
        public IActionResult DeleteChapter(int chapterId)
        {
            try
            {               
                _repository.DeleteChapter(chapterId);
                return Ok("Delete Successful!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("api/course/chapter/addlesson")]
        public IActionResult AddListLesson(ChapterAddLessonDTO inputDto)
        {
            try
            {
                var context = new OnlineLearningContext();
                var c = context.Chapters.FirstOrDefault(x => x.Id == inputDto.ChapterId);
                if (c != null)
                {
                    foreach (var item in inputDto.ListLesson)
                    {
                        item.ChapterId = inputDto.ChapterId;
                        context.Lessons.Update(item);
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
