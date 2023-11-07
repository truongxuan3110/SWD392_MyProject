using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;
using OnlineLearning.Repositories;

namespace OnlineLearning.Services
{
    public class QuestionService
    {
        public static List<Question> GetQuestions()
        {
            var listQuestions = new List<Question>();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    listQuestions = context.Questions.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listQuestions;
        }
        public static List<Question> GetQuestionsByQuizId(int quizId)
        {
            var listQuestions = new List<Question>();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    listQuestions = context.Questions.Where(x=>x.QuizId==quizId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listQuestions;
        }
        public static Question FindQuestionById(int questionId)
        {
            var question = new Question();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    question = context.Questions.SingleOrDefault(x => x.Id == questionId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return question;
        }
        public static void AddQuestion(Question p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    context.Questions.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateQuestion(Question p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    var existingQuestion = context.Questions.Find(p.Id);
                    if (existingQuestion != null)
                    {
                        context.Entry(existingQuestion).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteQuestion(Question p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    var p1 = context.Questions.SingleOrDefault(c => c.Id == p.Id);
                    context.Questions.Remove(p1);
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
