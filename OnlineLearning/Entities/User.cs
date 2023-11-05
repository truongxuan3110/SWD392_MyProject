using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Avatar { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? EncodedPassword { get; set; }
        public string? Address { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
