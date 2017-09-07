using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HotelManagerReponsity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
            name: "moduleId",
            routeTemplate: "api/{controller}/{action}/{moduleId}",
            defaults: new { moduleId = RouteParameter.Optional }
            );
            // configu file json
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new
            System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }
    }
}
