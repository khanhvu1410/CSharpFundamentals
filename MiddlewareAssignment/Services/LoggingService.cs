using System.Text;
using MiddlewareAssignment.Models;

namespace MiddlewareAssignment.Services
{
    public class LoggingService : ILoggingService
    {
        public async Task WriteLogs(Logging logging)
        {
            // Create log entry
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"[{DateTime.UtcNow}] Request Details:");
            stringBuilder.AppendLine($"Schema: {logging.Schema}");
            stringBuilder.AppendLine($"Host: {logging.Host}");
            stringBuilder.AppendLine($"Path: {logging.Path}");
            stringBuilder.AppendLine($"Query String: {logging.QueryString}");
            stringBuilder.AppendLine($"Request Body: {logging.RequestBody}\n");

            var logText = stringBuilder.ToString();

            // Write log to file
            await File.AppendAllTextAsync("logs.txt", logText);
        }
    }
}