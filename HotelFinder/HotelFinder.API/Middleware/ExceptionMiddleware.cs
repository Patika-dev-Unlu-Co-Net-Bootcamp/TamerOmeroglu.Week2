using HotelFinder.API.Exceptions;
using HotelFinder.API.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HotelFinder.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BadRequestException ex)
            {
                await HandleBadRequestExceptionAsync(httpContext, ex, ex.Message);
            }
            catch (NotFoundException ex)
            {
                await HandleNotFoundExceptionAsync(httpContext, ex, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleBadRequestExceptionAsync(httpContext, ex, ex.Message);
            }
        }
        private async Task HandleBadRequestExceptionAsync(HttpContext context, Exception exception, string msg)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(new ErrorResult()
            {
                StatusCode = context.Response.StatusCode,
                Message = msg
            }.ToString());
        }


        private async Task HandleNotFoundExceptionAsync(HttpContext context, Exception exception, string msg)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync(new ErrorResult()
            {
                StatusCode = context.Response.StatusCode,
                Message = msg
            }.ToString());
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception, string msg)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorResult()
            {
                StatusCode = context.Response.StatusCode,
                Message = msg
            }.ToString());
        }
    }
}
