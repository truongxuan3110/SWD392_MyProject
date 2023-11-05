﻿using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Course
    {
        public Course()
        {
            Chapters = new HashSet<Chapter>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsPublic { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
