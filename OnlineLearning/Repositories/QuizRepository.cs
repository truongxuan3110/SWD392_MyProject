using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Repositories
{
    public interface IQuizRepository
    {
        List<Quiz> GetAllQuizzes();
        List<Quiz> GetAllQuizzesByLessonId(int lessonId);
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

        public List<Quiz> GetAllQuizzesByLessonId(int lessonId) => QuizService.GetQuizzesByLessonId(lessonId);

        public Quiz GetQuizById(int id) => QuizService.FindQuizById(id);

        public void UpdateQuiz(Quiz p)
        {
            QuizService.UpdateQuiz(p);
        }
    }
}
