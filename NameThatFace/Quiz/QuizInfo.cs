using System;
using System.Collections.Generic;

namespace NameThatFace.Quiz
{
    public class QuizInfo
    {
        public DateTime? QuizStarted { get; set; }
        public DateTime? QuizFinished { get; set; }
        public Dictionary<string, string> Questions { get; set; } 
        public List<PastAnswer> PastAnswers { get; set; }
    }
}