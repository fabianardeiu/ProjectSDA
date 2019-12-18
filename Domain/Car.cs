using DataStructure.Interfaces;
using System;

namespace Domain
{
    public class Car : IData
    {
        private static readonly Random _random = new Random();
        public Car()
        {
            Id = _random.Next();
        }
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
