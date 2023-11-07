using OnlineLearning.Entities;

namespace OnlineLearning.DTOs
{
    public class LessonAddQuizDTO
    {
        public int LessonId { get; set; }
        public List<Quiz>? ListQuiz { get; set; }
    }
}
