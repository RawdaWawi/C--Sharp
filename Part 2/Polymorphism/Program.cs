using System;

namespace EmployeeQuitApp
{
    // Define an interface named IQuittable
    public interface IQuittable
    {
        // Declare a method named Quit with no return type and no parameters
        void Quit();
    }

    // Define the Employee class
    // Employee implements the IQuittable interface
    public class Employee : IQuittable
    {
        // Property for Employee Id
        public int Id { get; set; }

        // Property for Employee First Name
        public string FirstName { get; set; }

        // Property for Employee Last Name
        public string LastName { get; set; }

        // Implement the Quit method from the IQuittable interface
        public void Quit()
        {
            // You can customize this message or behavior as needed
            Console.WriteLine($"{FirstName} {LastName} (Employee ID: {Id}) has quit the company.");
        }
    }

    class Program
    {
        // Main method is the entry point of the application
        static void Main(string[] args)
        {
            // Create an instance of the Employee class and assign values
            Employee employee = new Employee
            {
                Id = 21,
                FirstName = "Rawda",
                LastName = "Wawi"
            };

            // Use polymorphism: create an IQuittable object and assign the Employee instance to it
            // This works because Employee implements IQuittable
            IQuittable quittableEmployee = employee;

            // Call the Quit method through the interface reference
            quittableEmployee.Quit();

            // Pause the console to allow the user to see the result
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
