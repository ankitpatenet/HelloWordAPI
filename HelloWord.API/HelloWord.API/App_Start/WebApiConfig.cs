using System.Net.Http.Headers;
using System.Web.Http;
using HelloWord.DataAdapters;
using HelloWord.DataAdapters.interfaces;
using HelloWord.Repositories;
using HelloWord.Repositories.Interfaces;
using Unity;

namespace HelloWord.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IGetWord, GetWord>();
            container.RegisterType<ISaveWord, SaveWord>();
            container.RegisterType<IHelloWordRepository, HelloWordRepository>();
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}