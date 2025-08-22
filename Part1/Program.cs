using System;

class Program
{
    static void Main()
    {
        // Display a welcome message
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Prompt the user to enter the weight of the package
        Console.Write("Please enter the package weight: ");
        double weight = Convert.ToDouble(Console.ReadLine()); // Convert the input to a double

        // Check if the package weight is over the allowed limit
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return; // End the program
        }

        // Prompt for the package width
        Console.Write("Please enter the package width: ");
        double width = Convert.ToDouble(Console.ReadLine()); // Convert the input to a double

        // Prompt for the package height
        Console.Write("Please enter the package height: ");
        double height = Convert.ToDouble(Console.ReadLine()); // Convert the input to a double

        // Prompt for the package length
        Console.Write("Please enter the package length: ");
        double length = Convert.ToDouble(Console.ReadLine()); // Convert the input to a double

        // Check if the sum of dimensions exceeds the maximum allowed
        double dimensionTotal = width + height + length;

        if (dimensionTotal > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return; // End the program
        }

        // Calculate the shipping quote using the given formula
        double quote = (width * height * length * weight) / 100;

        // Display the result as a dollar amount with 2 decimal places
        Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("F2"));

        // Thank the user
        Console.WriteLine("Thank you!");
    }
}
