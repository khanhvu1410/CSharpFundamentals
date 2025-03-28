using MiddlewareAssignment.Models;

namespace MiddlewareAssignment.Services
{
    public interface ILoggingService
    {
        public Task WriteLogs(Logging logging);
    }
}