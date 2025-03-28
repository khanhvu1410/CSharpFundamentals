using MiddlewareAssignment.Models;

namespace MiddlewareAssignment.Services
{
    public interface ICarService
    {
        public List<Car> GetAllCars();

        public Car GetCarById(int id);

        public Car CreateCar(Car car);

        public List<Car> FilterByModel(string model);
        
        public void DeleteCar(int id);
    }
}