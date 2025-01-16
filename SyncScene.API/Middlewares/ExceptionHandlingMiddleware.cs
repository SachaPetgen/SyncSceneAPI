using System.Net;
using System.Text.Json;
using SyncScene.Domain.Exceptions;

namespace SyncScene.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            await HandleExceptionAsync(context, ex);
        }
    }
    
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        
        // TODO
        context.Response.StatusCode = exception switch
        {
            Exception => (int)HttpStatusCode.BadRequest,
             => (int)HttpStatusCode.Unauthorized,
            AlreadyExistException => ,
            _ => (int)HttpStatusCode.InternalServerError
        };
        
        Console.WriteLine($"Error Details: {exception}");

        var errorResponse = new
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message,
            Details = exception.InnerException?.Message,
            Path = context.Request.Path
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}