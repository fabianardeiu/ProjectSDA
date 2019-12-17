using Core;
using Core.Interfaces;
using DataStructure;
using DataStructure.Interfaces;
using Domain;
using System;
using Unity;

namespace Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            //What if delete root????
            var carRepository = new CarRepository(new BST(), new List());
            var car1 = new Car
            {
                Make = "Mercedes-Benz",
                Model = "E Class",
                Year = 2010
            };
            var car2 = new Car
            {
                Make = "Mercedes-Benz",
                Model = "S Class",
                Year = 2011
            };
            var car3 = new Car
            {
                Id = 19,
                Make = "Mercedes-Benz",
                Model = "C Class",
                Year = 2018
            };
            var car4 = new Car
            {
                Make = "Mercedes-Benz",
                Model = "C Class",
                Year = 2000
            };
            carRepository.Add(car1);
            carRepository.Add(car2);
            carRepository.Add(car3);
            carRepository.Add(car4);

            var searchedCar = carRepository.GetById(car1.Id);
            carRepository.Delete(car2);
            var deletedCar = carRepository.GetById(car2.Id);
            IList cars = carRepository.GetAll();


            //IList carsList = new List();
            //carsList.Insert(car1);
            //carsList.Insert(car2);
            //carsList.Insert(car3);
            //carsList.Insert(car4);
            //carsList.IterateList();
            //carsList.Delete(car3);
            //carsList.IterateList();

        }
    }


}
