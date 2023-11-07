using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.DTOs;
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
        public IActionResult GetChapters(int courseId)
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

        [HttpPost("api/course/addchapter")]
        public IActionResult AddChapter(ChapterAddUpdateDTO chapter)
        {
            _repository.AddChapter(chapter);

        }
    }
}
