using OnlineLearning.Entities;

namespace OnlineLearning.Services
{
    public class LessonService
    {
        public static List<Lesson> GetListLesson(int chapterId)
        {
            var listLesson = new List<Lesson>();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    listLesson = context.Lessons.Where(x => x.ChapterId == chapterId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listLesson;
        }
        public static Lesson FindLessonById(int lessonId)
        {
            var lesson = new Lesson();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    lesson = context.Lessons.SingleOrDefault(x => x.Id == lessonId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return lesson;
        }
        public static void AddLesson(Lesson p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    context.Lessons.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateLesson(Lesson p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    var existingLesson = context.Lessons.Find(p.Id);
                    if (existingLesson != null)
                    {
                        context.Entry(existingLesson).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void Delete(Quiz p)
        {
            
        }
    }
}

