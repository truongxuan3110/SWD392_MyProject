using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetAllQuestions();
        Question GetQuestionById(int id);

        void AddQuestion(Question p);
        void DeleteQuestion(Question p);
        void UpdateQuestion(Question p);
    }
    public class QuestionRepository : IQuestionRepository
    {
        public void AddQuestion(Question p)
        {
            QuestionService.AddQuestion(p);
        }

        public void DeleteQuestion(Question p)
        {
            QuestionService.DeleteQuestion(p);
        }

        public List<Question> GetAllQuestions() => QuestionService.GetQuestions();

        public Question GetQuestionById(int id) => QuestionService.FindQuestionById(id);

        public void UpdateQuestion(Question p)
        {
            QuestionService.UpdateQuestion(p);
        }
    }
}
