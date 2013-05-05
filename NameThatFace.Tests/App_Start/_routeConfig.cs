using System.Web;
using System.Web.Routing;
using FakeItEasy;
using Xunit;

namespace NameThatFace.Tests.App_Start
{
    public class _routeConfig
    {

        private HttpContextBase _fakeContext;
        private readonly RouteCollection _fakeRoutes;

        public _routeConfig()
        {
            _fakeRoutes = new RouteCollection();
            NameThatFace.App_Start.RouteConfig.RegisterRoutes(_fakeRoutes);
            _fakeContext = A.Fake<HttpContextBase>();
        }

        [Fact]
        public void DefaultRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);

            Assert.NotNull(routeData);
            Assert.Equal("Home", routeData.Values["controller"]);
            Assert.Equal("Index", routeData.Values["action"]);
        }

        [Fact]
        public void QuizIndexRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Quiz/");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);

            Assert.NotNull(routeData);
            Assert.Equal("Quiz", routeData.Values["controller"]);
            Assert.Equal("Index", routeData.Values["action"]);
        }

        [Fact]
        public void EasyQuizIndexRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Quiz/Easy");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);

            Assert.NotNull(routeData);
            Assert.Equal("QuizEasy", routeData.Values["controller"]);
            Assert.Equal("Index", routeData.Values["action"]);
        }

        [Fact]
        public void EasyQuizNextRoute()
        {
            // assemble
            A.CallTo(() => _fakeContext.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Quiz/Easy/Next");

            // act
            var routeData = _fakeRoutes.GetRouteData(_fakeContext);

            Assert.NotNull(routeData);
            Assert.Equal("QuizEasy", routeData.Values["controller"]);
            Assert.Equal("Next", routeData.Values["action"]);
        }


    }
}
