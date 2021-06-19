using DatingApp.Errors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatingApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _Ilogger;
        private readonly IHostEnvironment _Env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _Env = env;
            _Ilogger = logger;

        }

        public async Task InvokeAsync(HttpContext Context)
        {
            try
            {
                await _next(Context);
            }
            catch (Exception ex)
            {
                _Ilogger.LogError(ex, ex.Message);
                Context.Response.ContentType = "Application/json";
                Context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var responce = _Env.IsDevelopment()
                ? new ApiExceptions(Context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                : new ApiExceptions(Context.Response.StatusCode, "Internal Server Error");
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(responce, options);
                await Context.Response.WriteAsync(json);
            }
         
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
