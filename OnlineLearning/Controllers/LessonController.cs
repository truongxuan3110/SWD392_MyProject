using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearning.Repositories;

namespace OnlineLearning.Controllers
{
    [Route("api/[controller]")]
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


    }   
}
