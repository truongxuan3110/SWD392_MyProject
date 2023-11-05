using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;

namespace OnlineLearning.Services
{
    public class QuizService
    {
        public static List<Quiz> GetQuizzes()
        {
            var listQuizs = new List<Quiz>();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    listQuizs = context.Quizzes.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listQuizs;
        }
        public static Quiz FindQuizById(int QuizId)
        {
            var Quiz = new Quiz();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    Quiz = context.Quizzes.SingleOrDefault(x => x.Id == QuizId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return Quiz;
        }
        public static void AddQuiz(Quiz p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    context.Quizzes.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateQuiz(Quiz p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    var existingQuiz = context.Quizzes.Find(p.Id);
                    if (existingQuiz != null)
                    {
                        context.Entry(existingQuiz).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteQuiz(Quiz p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    var p1 = context.Quizzes.Include(x => x.Questions)
                        .SingleOrDefault(c => c.Id == p.Id);
                    foreach (var question in p1.Questions.ToList())
                    {
                        QuestionService.DeleteQuestion(question);
                    }
                    context.Quizzes.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
