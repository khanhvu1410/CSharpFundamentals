using MiddlewareAssignment.Models;

namespace MiddlewareAssignment.Services;

public class CarService : ICarService
{
    private static List<Car> Cars = [
        new Car { Id = 1, Make = "Tesla", Model = "Model S", Year = 2024 },
        new Car { Id = 2, Make = "Ford", Model = "Mustang", Year = 2025 },
        new Car { Id = 3, Make = "Toyota", Model = "Camry", Year = 2023 },
        new Car { Id = 4, Make = "Audi", Model = "Sedans", Year = 2022 }
    ];

    public Car CreateCar(Car car)
    {
        var existingCar = Cars.Find(c => c.Id == car.Id);

        if (existingCar != null)
        {
            throw new InvalidOperationException($"Car with ID {car.Id} already exists.");
        }

        Cars.Add(car);  

        return car;       
    }

    public List<Car> GetAllCars()
    {
        return Cars;
    }

    public Car GetCarById(int id)
    {
        var car = Cars.Find(c => c.Id == id);
        
        if (car == null)
        {
            throw new KeyNotFoundException($"Car with ID {id} not found.");
        }
        
        return car;
    }

    public List<Car> FilterByModel(string model)
    {
        var filteredCars = Cars.Where(c => c.Model.Equals(model, StringComparison.OrdinalIgnoreCase)).ToList();

        if (filteredCars.Count == 0)
        {
            throw new KeyNotFoundException($"No {model} cars found.");
        }

        return filteredCars;
    }

    public void DeleteCar(int id)
    {
        var car = Cars.Find(c => c.Id == id);
        
        if (car == null)
        {
            throw new KeyNotFoundException($"Car with ID {id} is not found.");
        }
        
        Cars.Remove(car);
    }
}