namespace OnlineLearning.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; } = null!;
        public string? Avatar { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? EncodedPassword { get; set; }
        public string? Address { get; set; }
    }
}
