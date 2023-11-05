using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Lesson
    {
        public Lesson()
        {
            Quizzes = new HashSet<Quiz>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? ChapterId { get; set; }

        public virtual Chapter? Chapter { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
