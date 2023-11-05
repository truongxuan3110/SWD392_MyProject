using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Repositories
{
    public interface IQuizRepository
    {
        List<Quiz> GetAllQuizzes();
        Quiz GetQuizById(int id);

        void AddQuiz(Quiz p);
        void DeleteQuiz(Quiz p);
        void UpdateQuiz(Quiz p);
    }
    public class QuizRepository : IQuizRepository
    {
        public void AddQuiz(Quiz p)
        {
            QuizService.AddQuiz(p);
        }

        public void DeleteQuiz(Quiz p)
        {
            QuizService.DeleteQuiz(p);
        }

        public List<Quiz> GetAllQuizzes() => QuizService.GetQuizzes();

        public Quiz GetQuizById(int id) => QuizService.FindQuizById(id);

        public void UpdateQuiz(Quiz p)
        {
            QuizService.UpdateQuiz(p);
        }
    }
}
