namespace AssignmentDay2
{
    public class Car
    {
        public required string Make { get; set; }

        public required string Model { get; set; }

        public int Year { get; set; }

        public DateTime LastMaintenanceDate { get; set; }

        public CarType Type { get; set; }
    
        public DateTime ScheduleMaintenance() => LastMaintenanceDate.AddMonths(6);

        public void DisplayDetails()
        {
            Console.WriteLine();
            Console.WriteLine($"Car: {Make} {Model} ({Year})");
            Console.WriteLine($"Last Maintenance: {LastMaintenanceDate:yyyy-MM-dd}");
            Console.WriteLine($"Next Maintenance: {ScheduleMaintenance():yyyy-MM-dd}");
            Console.WriteLine();
        }
    }
}