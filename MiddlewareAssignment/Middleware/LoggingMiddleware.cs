using System.Text;
using MiddlewareAssignment.Models;
using MiddlewareAssignment.Services;

namespace MiddlewareAssignment.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILoggingService _loggingService;

    public LoggingMiddleware(RequestDelegate next, ILoggingService loggingService)
    {
        _next = next;
        _loggingService = loggingService;
    }

    public async Task Invoke(HttpContext context)
    {
        // Read request body
        context.Request.EnableBuffering();
        string requestBody = await ReadRequestBody(context);

        var request = context.Request;
        var logging = new Logging
        {
            Schema = request.Scheme,
            Host = request.Host.ToString(),
            Path = request.Path,
            QueryString = request.QueryString.ToString(),
            RequestBody = requestBody
        };

        await _loggingService.WriteLogs(logging);
        
        await _next(context);
    }

    public async Task<string> ReadRequestBody(HttpContext context)
    {
        context.Request.Body.Position = 0;
        using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;
        return body;
    }
}