namespace OnlineLearning.DTOs
{
    public class CourseDTOInList
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsPublic { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? LastUpdated { get; set; }

        public int? CategoryId { get; set; }
    }
}
