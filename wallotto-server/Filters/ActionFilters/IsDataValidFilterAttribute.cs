using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace wallotto_server.Filters.ActionFilters
{
    public class IsDataValidFilterAttribute : IActionFilter
    {
        public IsDataValidFilterAttribute()
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var parameter = context.ActionArguments
                .SingleOrDefault(x => x.Value.ToString().Contains("DTO")).Value;

            if (parameter is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null.");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
                return;
            }
        }
    }
}