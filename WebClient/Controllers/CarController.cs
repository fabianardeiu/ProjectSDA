using Core.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    [Route("web/[controller]")]

    public class CarController : Controller
    {
        private readonly IRepository _carRepo;

        public CarController(IRepository carRepo)
        {
            _carRepo = carRepo;
        }

        [Route("", Name = "Cars")]
        [HttpGet]
        public IActionResult Cars()
        {
            var cars = _carRepo.GetAll();
            return View(cars);
        }

        [Route("/create", Name = "CreateCar")]
        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        [Route("/create", Name = "PostCar")]
        public IActionResult CreateCar(Car car)
        {
            _carRepo.Add(car);
            return RedirectToRoute("Cars");
        }

        [HttpGet]
        [Route("/delete/{id}/confirm", Name = "DeleteConfirmation")]

        public IActionResult _DeleteCar(int id)
        {
            var toDelete = _carRepo.GetById(id);
            return PartialView(toDelete);
        }

        [HttpPost]
        [Route("/delete/{id}", Name="DeleteCar")]
        public IActionResult DeleteCar(int id)
        {
            _carRepo.Delete(_carRepo.GetById(id));
            return RedirectToRoute("Cars");
        }

        [HttpGet]
        [Route("/update/{id}", Name = "UpdateCar")]
        public IActionResult UpdateCar(int id)
        {
            var toUpdate = _carRepo.GetById(id);
            return View(toUpdate);
        }

        [HttpPost]
        [Route("/update/{id}", Name = "PutCar")]
        public IActionResult UpdateCar(Car car)
        {
            _carRepo.Update(car);
            return RedirectToRoute("Cars");
        }
    }
}
