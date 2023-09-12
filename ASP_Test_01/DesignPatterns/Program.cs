


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

    }
}