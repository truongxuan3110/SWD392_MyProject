namespace OnlineLearning.DTOs
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Duration { get; set; }
        public int? TotalQuestion { get; set; }
        public int? PassingScore { get; set; }
        public int? LessonId { get; set; }
    }
}
