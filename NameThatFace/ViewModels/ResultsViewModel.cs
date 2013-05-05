using NameThatFace.Quiz;

namespace NameThatFace.ViewModels
{
    public class ResultsViewModel
    {
        public QuizInfo QuizInfo { get; set; }
        public int CorrectCount { get; set; }
        public int AnsweredCount { get; set; }
    }
}