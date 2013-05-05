using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NameThatFace.Quiz;

namespace NameThatFace.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private QuizInfo CurrentQuiz
        {
            get
            {
                return QuizManager.GetCurrentQuiz(HttpContext.Session);
            }
        }

        public ActionResult Index()
        {
            ViewBag.IsComplete = CurrentQuiz.QuizFinished.HasValue;
            ViewBag.InWork = CurrentQuiz.QuizStarted.HasValue;
            return View();
        }

    }
}
