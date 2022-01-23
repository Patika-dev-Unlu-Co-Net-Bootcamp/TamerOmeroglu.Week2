using HotelFinder.API.Services;
using HotelFinder.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace HotelFinder.API.Attributes
{
    public class SignUpAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var user = context.ActionArguments["User"] as User;

            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "BadRequest" }) { StatusCode = StatusCodes.Status400BadRequest };
            }
            else
            {
                if (user.Username.Length > 10)
                {
                    context.Result = new JsonResult(new { message = "Maximum Username Length Error" }) { StatusCode = StatusCodes.Status400BadRequest };
                }
            }

        }
    }
}
