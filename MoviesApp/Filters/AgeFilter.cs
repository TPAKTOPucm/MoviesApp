using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace MoviesApp.Filters
{
    public class AgeFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) {}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var age = (DateTime.Now - DateTime.Parse(context.HttpContext.Request.Form["BirthDay"])).TotalDays/365;
            if (age < 7 || age > 99)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
