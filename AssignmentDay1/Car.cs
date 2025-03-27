namespace AssignmentDay1
{
    public class Car
    {
        public required string Make { get; set; }

        public required string Model { get; set; }

        public int Year { get; set; }

        public CarType Type { get; set; }

        public override string ToString() 
        {
            return $"Type: {Type} - Make: {Make} - Model: {Model} - Year: {Year}";
        }
    }

    public enum CarType {
        Electric, 
        Fuel
    }
}