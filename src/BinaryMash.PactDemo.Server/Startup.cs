using System.Web.Http;
using BinaryMash.PactDemo.Server.Windsor.Installers;
using Castle.Windsor;
using Owin;

namespace BinaryMash.PactDemo.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var webApiConfiguration = ConfigureWebApi();
            app.Use(typeof(AddHeader));
            app.UseWebApi(webApiConfiguration);

            //HttpConfiguration config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes();
            //config.DependencyResolver = httpDependencyResolver;
            //appBuilder.UseWebApi(config);
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            var container = new WindsorContainer().Install(new Installer());
            var httpDependencyResolver = new WindsorHttpDependencyResolver(container);
            config.DependencyResolver = httpDependencyResolver;

            return config;
        }
    }
}
