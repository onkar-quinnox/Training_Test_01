using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    interface IVehicle
    {
        void Start();
        void Stop();
    }

 
    class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Car started.");
        }

        public void Stop()
        {
            Console.WriteLine("Car stopped.");
        }
    }

   
    class Motorcycle : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Motorcycle started.");
        }

        public void Stop()
        {
            Console.WriteLine("Motorcycle stopped.");
        }
    }

   
    interface IVehicleFactory
    {
        IVehicle CreateVehicle();
    }

 
    class CarFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Car();
        }
    }

    class MotorcycleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle()
        {
            return new Motorcycle();
        }
    }
}
