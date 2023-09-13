


using DesignPatterns.Factory;
using DesignPatterns.Singleton;
using System;

class Program
{
    static void Main(string[] args)
    {
        
       // Singleton Design Pattern

        SingletonDesign fromEmployee = SingletonDesign.GetInstance;
        fromEmployee.PrintDetails("From Employee");
        SingletonDesign fromStudent = SingletonDesign.GetInstance;
        fromStudent.PrintDetails("From Student");


        //Factory Design Pattern
        IVehicleFactory carFactory = new CarFactory();
        IVehicle car = carFactory.CreateVehicle();
        car.Start();
        car.Stop();

        IVehicleFactory bikeFactory = new MotorcycleFactory();
        IVehicle bike = bikeFactory.CreateVehicle();
        bike.Start();
        bike.Stop();

    }
}