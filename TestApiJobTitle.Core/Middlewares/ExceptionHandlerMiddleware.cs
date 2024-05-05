using System.Globalization;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using TestApiJobTitle.Common.Exceptions;

namespace TestApiJobTitle.Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception is BusinessException businessException)
        {
            context.Response.StatusCode = (int)businessException.Code;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new
                { Message = businessException.ErrorMessage }));
            return;
        }

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(JsonSerializer.Serialize(exception.Message));
    }
}