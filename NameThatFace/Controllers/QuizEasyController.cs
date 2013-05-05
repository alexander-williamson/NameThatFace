using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using NameThatFace.Quiz;
using NameThatFace.ViewModels;

namespace NameThatFace.Controllers
{
    public class QuizEasyController : Controller
    {
        //
        // GET: /Quiz/

        private QuizInfo CurrentQuiz
        {
            get { return QuizManager.GetCurrentQuiz(HttpContext.Session); }
        }

        public ActionResult Index()
        {
            if (QuizManager.IsCompleted(CurrentQuiz))
            {
                return new RedirectResult("Results/");
            }

            var lastAnswered = 0;
            var answers = (from o in CurrentQuiz.PastAnswers select o);
            var pos = 0;
            for(var i = 0; pos == 0 && i < answers.Count() -1; i++)
            {
                var answer = answers.ElementAt(i);
                if (!string.IsNullOrWhiteSpace(answer.Answer))
                {
                    pos = i;
                }
            }

            return new RedirectResult("Question/"+ (pos+1));
        }

        public RedirectResult New()
        {
            QuizManager.ResetQuiz(HttpContext.Session);
            return new RedirectResult("Question/1");
        }

        public ActionResult Question(int id)
        {
            // human numbering (starts at 1)
            id = id - 1;

            var username = (from o in CurrentQuiz.Questions select o.Key).ElementAt(id);
            var model = new QuestionViewModel { Id = id, Username = username };
            return View(model);
        }

        public class AnswerRequestModel
        {
            [Required]
            public int Id { get; set; }

            [Required]
            public double Start { get; set; }

            [Required]
            public double Finish { get; set; }

            [Required]
            [MinLength(1), MaxLength(255)]
            public string Answer { get; set; }
        }

        public ActionResult Answer(AnswerRequestModel requestModel)
        {
            if (ModelState.IsValid == false)
            {
                var username = (from o in CurrentQuiz.Questions select o.Key).ElementAt(requestModel.Id - 1);
                var model = new QuestionViewModel { Id = requestModel.Id - 1, Username = username };
                return View("Question", model);
            }

            var correctUsername = (from o in CurrentQuiz.Questions select o.Key).ElementAt(requestModel.Id - 1);
            var begin = new DateTime(1970, 1, 1).AddMilliseconds(requestModel.Start);
            var end = new DateTime(1970, 1, 1).AddMilliseconds(requestModel.Finish);

            var timeTakenMs = end.Subtract(begin).TotalMilliseconds;

            QuizManager.AddAnswer(CurrentQuiz, correctUsername, requestModel.Answer, timeTakenMs);

            if (QuizManager.IsCompleted(CurrentQuiz))
            {
                return new RedirectResult("Results");
            }

            var newQuestionId = requestModel.Id + 1;
            return new RedirectResult("Question/" + newQuestionId);

        }

        public ActionResult Results()
        {
            var correctAnswers = 0;
            var usernamesLowercase = (from o in CurrentQuiz.Questions select o.Key.ToLower());
            foreach (string element in usernamesLowercase)
            {
                var matchingAnswers = (from o in CurrentQuiz.PastAnswers where o.CorrectUsername.ToLower() == element select o);
                if (matchingAnswers.Count() > 0 && matchingAnswers.First().Answer.ToLower() == matchingAnswers.First().CorrectFullName.ToLower())
                { 
                    correctAnswers++;
                }
            }

            var model = new ResultsViewModel
                            {
                                AnsweredCount = CurrentQuiz.PastAnswers.Count,
                                CorrectCount = correctAnswers,
                                QuizInfo = CurrentQuiz
                            };

            return View(model);
        }

    }
}
