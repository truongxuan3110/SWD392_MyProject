using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Duration { get; set; }
        public int? TotalQuestion { get; set; }
        public int? PassingScore { get; set; }
        public int? LessonId { get; set; }

        public virtual Lesson? Lesson { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
