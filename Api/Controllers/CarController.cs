using Core.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarController : Controller
    {
        private readonly IRepository _repo;

        public CarController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult ListCars()
        {
            var cars = _repo.GetAll();
            return Ok(cars.First);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _repo.GetById(id);
            if (car == null)
                return BadRequest("No car could be found.");
            return Ok(car);
        }

        [HttpPost]
        public IActionResult PostCar([FromBody] Car car)
        {
            _repo.Add(car);
            return Ok("Car added.");
        }

        [HttpPut]
        public IActionResult UpdateCar([FromBody] Car car)
        {
            var updatedCar = _repo.Update(car);
            if (updatedCar == null)
                return BadRequest("No car could be found for update.");
            return Ok("Car updated.");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var toDelete = _repo.GetById(id);
            if (toDelete == null)
                return Ok("No car could be found");
            _repo.Delete(toDelete);
            return Ok("Car deleted.");
        }

    }
}
