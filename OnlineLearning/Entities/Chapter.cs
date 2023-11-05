﻿using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Chapter
    {
        public Chapter()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
