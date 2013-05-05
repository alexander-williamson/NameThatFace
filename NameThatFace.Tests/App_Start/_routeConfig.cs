using System.Web;
using System.Web.Routing;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NameThatFace.Tests.App_Start
{
    [TestClass]
    public class _routeConfig
    {

        private HttpContextBase _fakeContext;
        private RouteCollection _fakeRoutes;

        [TestInitialize]
        public void Initialise()
        {
            _fakeRoutes = new RouteCollection();
            NameThatFace.App_Start.RouteConfig.RegisterRoutes(_fakeRoutes);
            _fakeContext = A.Fake<HttpContextBase>();
        }

        [TestMethod]
        public void DefaultRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);
            
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
        }

        [TestMethod]
        public void QuizIndexRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Quiz/");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Quiz", routeData.Values["controllerB"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
        }

        [TestMethod]
        public void EasyQuizIndexRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Quiz/Easy");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("QuizEasy", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
        }

        [TestMethod]
        public void EasyQuizNextRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Quiz/Easy/Next");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("QuizEasy", routeData.Values["controller"]);
            Assert.AreEqual("Next", routeData.Values["action"]);
        }


    }
}
