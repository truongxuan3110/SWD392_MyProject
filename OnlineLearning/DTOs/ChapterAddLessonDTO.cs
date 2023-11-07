using OnlineLearning.Entities;

namespace OnlineLearning.DTOs
{
    public class ChapterAddLessonDTO
    {
        public int ChapterId { get; set; }

        public List<Lesson>? ListLesson { get; set; }
    }
}
