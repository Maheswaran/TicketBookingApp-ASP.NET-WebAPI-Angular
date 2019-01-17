using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using TravelBooking_WebAPI_Service;

namespace TicketBooking_WebAPI_Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MessageHandlers.Add(new MessageHandlerForGlobalRoute());

            DelegatingHandler[] handlers = new DelegatingHandler[] {
                new MessageHandlerForUserController()
            };           

            var routeHandlers = HttpClientFactory.CreatePipeline(new HttpControllerDispatcher(config), handlers);

            config.Routes.MapHttpRoute(
                name: "UserAPI",
                routeTemplate: "api/{Controller}/{id}",
                defaults: new {
                    Controller = "Users",
                    id = RouteParameter.Optional                  
                },
                constraints: null,
                handler: routeHandlers
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }                
            );         
        }
    }
}
