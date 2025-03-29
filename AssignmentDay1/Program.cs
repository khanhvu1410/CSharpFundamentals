namespace AssignmentDay1;

class Program
{
    private static List<Car> cars = 
    [
        new Car { Make = "Tesla", Model = "Tesla Model 1", Year = 2024, Type = CarType.Electric },
        new Car { Make = "Toyota", Model = "Toyota Model 1", Year = 2025, Type = CarType.Fuel },
        new Car { Make = "Toyota", Model = "Toyota Model 2", Year = 2023, Type = CarType.Electric },
        new Car { Make = "Tesla", Model = "Tesla Model 2", Year = 2022, Type = CarType.Fuel }
    ];

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine(@"
                Menu:
                1. Add a Car
                2. View All Cars
                3. Search Car by Make
                4. Filter Cars by Type
                5. Remove a Car by Model
                6. Exit
            ");

            int choice = GetValidChoice("Enter your choice: ");

            switch (choice) 
            {
                case 1:
                    AddCar();
                    break;
                
                case 2:
                    ShowCars(cars);
                    break;
                
                case 3:
                    SearchCarByMake();
                    break;
                
                case 4:
                    FilterCarByType();
                    break;
                
                case 5:
                    RemoveCarByModel();
                    break;
                
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private static void ShowCars(List<Car> cars)
    {
        if (cars.Count == 0)
        {
            Console.WriteLine("No cars found.");
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }

    public static void AddCar() 
    {
        var type = GetValidCarType("Enter car type (Fuel/Electric): ");
        var make = GetValidString("Enter Make: ");
        var model = GetValidString("Enter Model: ");
        var year = GetValidInteger("Enter Year: ");
        var car = new Car {
            Make = make,
            Model = model,
            Year = year,
            Type = type
        };
        cars.Add(car);
        Console.WriteLine("Car added successfully.");
    }

    private static void SearchCarByMake() 
    {
        var makeSearch = GetValidString("Enter Make: ");
        var searchedCars = cars.Where(c => c.Make.Contains(makeSearch, StringComparison.OrdinalIgnoreCase)).ToList();
        ShowCars(searchedCars);
    }

    private static void FilterCarByType()
    {
        var carType = GetValidCarType("Enter Type: ");
        var filteredCars = cars.Where(c => c.Type == carType).ToList();
        ShowCars(filteredCars);
    }

    public static void RemoveCarByModel()
    {
        var modelInput = GetValidString("Enter Model: ");
        var carToRemove = cars.Find(c => c.Model.Equals(modelInput, StringComparison.OrdinalIgnoreCase));
        if (carToRemove != null)
        {
            cars.Remove(carToRemove);
            Console.WriteLine("Car removed successfully.");
        }
        else 
            Console.WriteLine("Car not found.");
    }

    // Method to validate none-empty string input
    public static string GetValidString(string message)
    {
        string? input;
        Console.Write(message);
        while(string.IsNullOrWhiteSpace(input = Console.ReadLine())) 
        {
            Console.Write($"Invalid input. {message}");
        }
        return input;
    }

    // Method to validate integer input 
    public static int GetValidInteger(string message)
    {
        int result;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out result)) 
        {
            Console.Write($"Invalid Input. {message}");
        }
        return result;
    }

    public static int GetValidChoice(string message)
    {
        int result = GetValidInteger(message);
        while (result < 1 || result > 6)
        {
            Console.WriteLine("Invalid input! Please enter a choice between 1 and 6.");
            result = GetValidInteger(message);
        }
        return result;
    }

    // Method to validate and parse CarType input
    public static CarType GetValidCarType(string message)
    {
        var typeInput = GetValidString(message);
        while (!typeInput.Equals("Fuel", StringComparison.OrdinalIgnoreCase)  && 
                !typeInput.Equals("Electric", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Invalid input! Please enter 'Fuel' for FuelCar or 'Electric' for ElectricCar.");
            typeInput = GetValidString(message);
        }
        CarType type = typeInput.Equals("Fuel", StringComparison.OrdinalIgnoreCase) ? CarType.Fuel : CarType.Electric;
        return type;
    }
}