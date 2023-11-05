namespace OnlineLearning.DTOs
{
    public class QuestionAddUpdateDTO
    {
        public string QuestionContent { get; set; } = null!;
        public int? QuizId { get; set; }
    }
}
