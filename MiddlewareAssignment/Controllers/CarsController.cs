using Microsoft.AspNetCore.Mvc;
using MiddlewareAssignment.Models;
using MiddlewareAssignment.Services;

namespace MiddlewareAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        } 

        [HttpPost]
        public ActionResult<Car> AddCar([FromBody] Car car)
        {
            try 
            {
                var createdCar = _carService.CreateCar(car);
                return CreatedAtAction("AddCar", createdCar);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new 
                { 
                    message = "An unexpected error occured.", 
                    detail = ex.Message 
                });
            }
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Car>> GetAllCars()
        {
            var cars = _carService.GetAllCars();
            if (cars.Count == 0)
            {
                return NotFound(new { message = "No cars found." });
            }
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            try 
            {
                var car = _carService.GetCarById(id);
                return Ok(car);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new 
                { 
                    message = "An unexpected error occured.", 
                    detail = ex.Message 
                });
            }
        }

        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<Car>> FilterByModel([FromQuery] string model)
        {
            try
            {
                var cars = _carService.FilterByModel(model);
                return Ok(cars);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An unexpected error occured.", 
                    detail = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            try
            {
                _carService.DeleteCar(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new 
                { 
                    message = "An unexpected error occured.", 
                    detail = ex.Message 
                });
            }
        }
    }
}