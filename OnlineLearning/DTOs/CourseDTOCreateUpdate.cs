namespace OnlineLearning.DTOs
{
    public class CourseDTOCreateUpdate
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsPublic { get; set; }

        public int? CategoryId { get; set; }
    }
}
