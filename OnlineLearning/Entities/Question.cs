using System;
using System.Collections.Generic;

namespace OnlineLearning.Entities
{
    public partial class Question
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; } = null!;
        public int? QuizId { get; set; }

        public virtual Quiz? Quiz { get; set; }
    }
}
