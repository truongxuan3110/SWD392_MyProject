using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entities;

namespace OnlineLearning.Services
{
    public class ChapterService
    {
        public static List<Chapter> GetListChapter(int? courseId)
        {
            var listChapter = new List<Chapter>();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    if (courseId != null)
                    {
                        listChapter = context.Chapters.Where(x => x.CourseId == courseId).ToList();
                    }
                    else
                    {
                        listChapter = context.Chapters.ToList();
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listChapter;
        }
        public static Chapter FindChapterById(int chapterId)
        {
            var chapter = new Chapter();
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    chapter = context.Chapters.SingleOrDefault(x => x.Id == chapterId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return chapter;
        }
        public static void AddChapter(Chapter p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    context.Chapters.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateChapter(Chapter p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    var existingChapter = context.Chapters.SingleOrDefault(x => x.Id == p.Id);
                    if (existingChapter != null)
                    {
                        context.Entry(existingChapter).CurrentValues.SetValues(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteChapter(int p)
        {
            try
            {
                using (var context = new OnlineLearningContext())
                {
                    var chapter = context.Chapters.FirstOrDefault(x => x.Id == p);
                    if (chapter != null)
                    {
                        context.Chapters.Remove(chapter);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
