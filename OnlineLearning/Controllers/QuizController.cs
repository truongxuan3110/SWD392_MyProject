using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.DTOs;
using OnlineLearning.Entities;
using OnlineLearning.Repositories;
using OnlineLearning.Services;

namespace OnlineLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private IQuizRepository _repository = new QuizRepository();
        private readonly IMapper _mapper;

        public QuizController(IMapper mapper, IQuizRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet("GetAllQuiz")]
        public IActionResult GetQuizs()
        {
            var p = _repository.GetAllQuizzes();
            var result = _mapper.Map<List<QuizDTO>>(p);
            return Ok(result);
        }

        [HttpGet("GetQuizById/{id}")]
        public IActionResult GetQuizById(int id)
        {
            Quiz p = new Quiz();
            p = _repository.GetQuizById(id);
            if (p == null)
                return NotFound();
            return Ok(p);
        }
        [HttpPost("AddQuiz")]
        public IActionResult AddQuiz(QuizAddUpdateDTO a)
        {
            Quiz p = _mapper.Map<Quiz>(a);
            _repository.AddQuiz(p);
            return NoContent();
        }
        [HttpPut("UpdateQuiz/{id}")]
        public IActionResult UpdateQuiz(int id, QuizAddUpdateDTO a)
        {
            var pTmp = _repository.GetQuizById(id);
            if (pTmp == null)
                return NotFound();
            Quiz updateQuiz = _mapper.Map(a, pTmp);
            _repository.UpdateQuiz(updateQuiz);
            return NoContent();
        }
        [HttpDelete("DeleteQuiz/{id}")]
        public IActionResult DeleteQuiz(int id)
        {
            var p = _repository.GetQuizById(id);
            if (p == null)
                return NotFound();
            _repository.DeleteQuiz(p);
            return NoContent();
        }
    }
}
