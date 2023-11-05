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
    public class QuestionController : ControllerBase
    {
        private IQuestionRepository _repository = new QuestionRepository();
        private readonly IMapper _mapper;

        public QuestionController(IMapper mapper, IQuestionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet("GetAllQuestion")]
        public IActionResult GetQuestions()
        {
            var p = _repository.GetAllQuestions();
            var result = _mapper.Map<List<QuestionDTO>>(p);
            return Ok(result);
        }

        [HttpGet("GetQuestionById/{id}")]
        public IActionResult GetQuestionById(int id)
        {
            Question p = new Question();
            p = _repository.GetQuestionById(id);
            if (p == null)
                return NotFound();
            return Ok(p);
        }
        [HttpPost("AddQuestion")]
        public IActionResult AddQuestion(QuestionAddUpdateDTO a)
        {
            Question p = _mapper.Map<Question>(a);
            _repository.AddQuestion(p);
            return NoContent();
        }
        [HttpPut("UpdateQuestion/{id}")]
        public IActionResult UpdateQuestion(int id, QuestionAddUpdateDTO a)
        {
            var pTmp = _repository.GetQuestionById(id);
            if (pTmp == null)
                return NotFound();
            Question updateQuestion = _mapper.Map(a, pTmp);
            _repository.UpdateQuestion(updateQuestion);
            return NoContent();
        }
        [HttpDelete("DeleteQuestion/{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            var p = _repository.GetQuestionById(id);
            if (p == null)
                return NotFound();
            _repository.DeleteQuestion(p);
            return NoContent();
        }
    }
}
