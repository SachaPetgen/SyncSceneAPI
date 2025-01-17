using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;
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
        context.Response.ContentType = "application/problem+json";

        var problemDetails = new ProblemDetails
        {
            Instance = context.Request.Path,
            Detail = exception.Message
        };
        
        switch (exception)
        {
            case BaseCustomException baseCustomException:
                problemDetails.Status = baseCustomException.StatusCode;
                problemDetails.Title = baseCustomException.Message;
                break;
            case DbUpdateException :
                
                if (exception.InnerException != null)
                {
                    problemDetails.Detail += $" Inner Exception: {exception.InnerException.Message}";
                }
                
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                problemDetails.Title = "A database error occurred.";
                break;
            default:
                problemDetails.Status = (int)HttpStatusCode.InternalServerError;
                problemDetails.Title = "An unexpected error occurred.";
                break;
        }

        context.Response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }
}