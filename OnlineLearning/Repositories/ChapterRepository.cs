using OnlineLearning.Entities;
using OnlineLearning.Services;

namespace OnlineLearning.Repositories
{
    public interface IChapterRepository
    {
        List<Chapter> GetAllChapter(int courseId);
        Chapter GetChapterById(int id);
        void AddChapter(Chapter p);
        void DeleteChapter(Chapter p);
        void UpdateChapter(Chapter p);
    }

    public class ChapterRepository : IChapterRepository
    {
        public void AddChapter(Chapter p)
        {
            ChapterService.AddChapter(p);
        }

        public void DeleteChapter(Chapter p)
        {
            throw new NotImplementedException();
        }

        public List<Chapter> GetAllChapter(int courseId)
        {
            return ChapterService.GetListChapter(courseId);
        }

        public Chapter GetChapterById(int id)
        {
            return ChapterService.FindChapterById(id);
        }

        public void UpdateChapter(Chapter p)
        {
            ChapterService.UpdateChapter(p);
        }
    }


}
