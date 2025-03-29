using MiddlewareAssignment.Middleware;
using MiddlewareAssignment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICarService, CarService>();
builder.Services.AddSingleton<ILoggingService, LoggingService>();
builder.Services.AddControllers();

var app = builder.Build();

// Register middleware
app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.Run();