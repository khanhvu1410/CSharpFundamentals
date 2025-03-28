namespace MiddlewareAssignment.Models
{
    public class Logging
    {
        public required string Schema { get; set; }

        public required string Host { get; set; }

        public required string Path { get; set; }

        public required string QueryString { get; set; }

        public required string RequestBody { get; set; }
    }
}