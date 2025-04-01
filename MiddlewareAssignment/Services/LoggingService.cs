using System.Text;
using MiddlewareAssignment.Models;

namespace MiddlewareAssignment.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly string _logFilePath = "logs.txt";

        public async Task WriteLogs(Logging logging)
        {
            try
            {
                // Create log entry
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("----- HTTP Request Log -----");
                stringBuilder.AppendLine($"Schema: {logging.Schema}");
                stringBuilder.AppendLine($"Host: {logging.Host}");
                stringBuilder.AppendLine($"Path: {logging.Path}");
                stringBuilder.AppendLine($"Query String: {logging.QueryString}");
                stringBuilder.AppendLine($"Request Body: {logging.RequestBody}");
                stringBuilder.AppendLine($"Timestamp: {DateTime.UtcNow}");
                stringBuilder.AppendLine("----------------------------\n");

                var logText = stringBuilder.ToString();

                var logDirectory = Path.GetDirectoryName(_logFilePath);

                if (!string.IsNullOrEmpty(logDirectory) && !Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                await File.AppendAllTextAsync(_logFilePath, logText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}