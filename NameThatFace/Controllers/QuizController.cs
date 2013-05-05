using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NameThatFace.Controllers
{
    public class QuizController : Controller
    {
        //
        // GET: /Quiz/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(string difficulty = "hard")
        {
            switch(difficulty)
            {
                case "easy":
                    return new RedirectResult("~/Quiz/Easy/Index");
                default:
                    return new RedirectResult("~/Quiz/Hard/Index");
            }
        }

    }
}
