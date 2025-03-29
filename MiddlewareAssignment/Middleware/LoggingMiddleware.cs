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
        // Read request details
        var schema = context.Request.Scheme;
        var host = context.Request.Host.ToString();
        var path = context.Request.Path;
        var queryString = context.Request.QueryString.ToString();

        // Read request body
        context.Request.EnableBuffering();
        string requestBody = await ReadRequestBody(context);

        var logging = new Logging
        {
            Schema = schema,
            Host = host,
            Path = path,
            QueryString = queryString,
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