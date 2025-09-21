using System;

namespace MathOperationApp
{
    // Define a class named 'MathHandler'
    class MathHandler
    {
        // This is a void method that takes two integers as parameters
        public void PerformOperation(int num1, int num2)
        {
            // Perform a math operation on the first integer (e.g., multiply it by 2)
            int result = num1 * 2;

            // Display the result of the operation on the first integer
            Console.WriteLine("Result of operation on first integer (num1 * 2): " + result);

            // Display the second integer as is
            Console.WriteLine("Second integer (num2): " + num2);
        }
    }

    class Program
    {
        // The Main method is the entry point of the console application
        static void Main(string[] args)
        {
            // Create an instance of the MathHandler class
            MathHandler mathHandler = new MathHandler();

            // Call the PerformOperation method with positional arguments
            mathHandler.PerformOperation(2, 4);

            // Add a blank line for readability
            Console.WriteLine();

            // Call the PerformOperation method using named arguments
            // Here, num1 = 7, num2 = 20 (parameters are explicitly named)
            mathHandler.PerformOperation(num1: 7, num2: 21);

            // Prevent the console window from closing immediately
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
