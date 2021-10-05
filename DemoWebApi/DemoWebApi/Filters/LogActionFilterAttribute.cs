using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace DemoWebApi.Filters
{
 
    public class LogActionFilterAttribute :Attribute,IActionFilter
    {
        private readonly ILogger logger;

        public LogActionFilterAttribute(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger("My logger");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this.Log("OnActionExecuting", context.RouteData);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.Log("OnActionExecuted", context.RouteData);
        }

        //public void OnResultExecuting(ResultExecutingContext context)
        //{
        //    this.Log("OnResultExecuting", context.RouteData);
            
        //}

        //public void OnResultExecuted(ResultExecutedContext context)
        //{
        //    this.Log("OnResultExecuted", context.RouteData);
        //}

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            string message = $"MethodName :{methodName} , controller:{controllerName} , action:{actionName}";
            this.logger.LogInformation(message);
        }
    }
}
