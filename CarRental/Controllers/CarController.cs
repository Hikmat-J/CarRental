using CarRental.Application.Dtos;
using CarRental.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carService;

        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(int skip=0, int count = 10 ,string SortBy="Id", 
            long? number = null, string? color = null, bool? withDriver = null)
        {
            var carsDto = await _carService.GetAll(skip, count, SortBy,number,color,withDriver);
            return Ok(carsDto);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var carsDto = await _carService.GetById(Id);
            return Ok(carsDto);
        }

        [HttpPost]
        [Route("Create")]
        public Task Post(CreateCarDto input)
        {
            return _carService.Create(input);
        }

        [HttpPut]
        [Route("Update")]
        public Task PUt(UpdateCarDto input)
        {
            return _carService.Put(input);
        }

        [HttpDelete]
        [Route("Delete")]
        public Task Delete(CarDto input)
        {
            return _carService.Delete(input);
        }
    }
}