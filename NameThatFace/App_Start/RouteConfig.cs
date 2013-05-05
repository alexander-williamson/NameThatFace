using System.Web.Mvc;
using System.Web.Routing;

namespace NameThatFace.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "QuizEasy",
                url: "Quiz/Easy/{action}/{id}",
                defaults: new { action = "Index", controller = "QuizEasy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "QuizHard",
                url: "Quiz/Hard/{action}/{id}",
                defaults: new { action = "Index", controller = "QuizHard", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "QuizIndex",
                url: "Quiz/{action}/{id}",
                defaults: new { action = "Index", controller = "Quiz", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}