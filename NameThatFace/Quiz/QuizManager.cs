using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NameThatFace.Quiz
{
    public class QuizManager
    {
        public const string SessionKey = "current_quiz";
        public static Dictionary<string, string> People;
        public const int QuizLength = 5;

        public static int DistanceDifficulty
        {
            get { return 5; }
        }

        public static void ResetQuiz(HttpSessionStateBase session)
        {
            session[SessionKey] = null;
            GenerateNewQuiz();
        }

        public static QuizInfo GetCurrentQuiz(HttpSessionStateBase session)
        {
            var value = session[SessionKey];
            if (value == null || (value is QuizInfo) == false)
            {
                session[SessionKey] = GenerateNewQuiz();
            }
            return (QuizInfo) session[SessionKey];
        }

        public static QuizInfo GenerateNewQuiz(int questions = QuizLength)
        {
            var people = new Dictionary<string, string>
                         {
                             {"alexanderw", "Alexander Williamson"},
                             {"jamesk", "James Killick"},
                             {"ravin", "Ravi Nar"},
                             {"andrewbr", "Andrew Brown"},
                             {"seshm", "Sesh Meenavalli"}
                         };

            return new QuizInfo
                       {
                           PastAnswers = new List<PastAnswer>(),
                           QuizFinished = null,
                           QuizStarted = null,
                           Questions = people
                       };
        }

        public static String GetNextUsername(QuizInfo quiz)
        {
            var allNames = (from o in quiz.Questions select o.Key);
            var answered = (from o in quiz.PastAnswers select o.CorrectUsername);
            var todo = (from o in allNames where answered.Contains(o) == false select o);
            if (todo.Count() == 0) return null;
            return todo.FirstOrDefault();
        }

        public static void AddAnswer(QuizInfo quiz, string username, string answer, double timeTakenMs)
        {
            var correctName = (from o in quiz.Questions where o.Key == username select o).FirstOrDefault();
            quiz.PastAnswers.Add(new PastAnswer
                                     {
                                         Answer = answer,
                                         CorrectFullName = correctName.Value,
                                         TimeTakenMs = timeTakenMs,
                                         CorrectUsername = username
                                     });
        }

        public static bool IsCompleted(QuizInfo quiz)
        {
            var countTotal = quiz.Questions.Count();
            var countAnswered = quiz.PastAnswers.Count();
            return (countTotal == countAnswered);
        }

    }
}