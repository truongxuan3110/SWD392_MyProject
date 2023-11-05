namespace OnlineLearning.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; } = null!;
        public int? QuizId { get; set; }
    }
}
