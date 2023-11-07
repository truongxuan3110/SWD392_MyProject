using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Repositories
{
    public interface ILessonRepository
    {
        List<Lesson> GetAllLesson(int? chapterId);
        Lesson GetLessonById(int id);
        void AddLesson(Lesson p);
        void DeleteLesson(int p);
        void UpdateLesson(Lesson p);
    }

    public class LessonRepository : ILessonRepository
    {
        public void AddLesson(Lesson p)
        {
            LessonService.AddLesson(p);
        }

        public void DeleteLesson(int p)
        {
            LessonService.Delete(p);
        }

        public List<Lesson> GetAllLesson(int? chapterId)
        {
            return LessonService.GetListLesson(chapterId);
        }

        public Lesson GetLessonById(int id)
        {
            return LessonService.FindLessonById(id);
        }

        public void UpdateLesson(Lesson p)
        {
            LessonService.UpdateLesson(p);
        }
    }
}
