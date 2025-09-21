using System;

namespace EmployeeComparisonApp
{
    // Define the Employee class
    public class Employee
    {
        // Property for Employee Id
        public int Id { get; set; }

        // Property for Employee First Name
        public string FirstName { get; set; }

        // Property for Employee Last Name
        public string LastName { get; set; }

        // Overload the '==' operator to compare Employee objects by Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // If both are null, they are equal
            if (ReferenceEquals(emp1, emp2))
                return true;

            // If either is null, but not both, they are not equal
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
                return false;

            // Compare Ids
            return emp1.Id == emp2.Id;
        }

        // Overload the '!=' operator (must be overloaded in pair with '==')
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override Equals method to match operator == behavior
        public override bool Equals(object obj)
        {
            var other = obj as Employee;
            if (other == null) return false;
            return this.Id == other.Id;
        }

        // Override GetHashCode as best practice when overriding Equals
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    class Program
    {
        // Entry point of the console application
        static void Main(string[] args)
        {
            // Create first Employee object and assign values
            Employee emp1 = new Employee
            {
                Id = 101,
                FirstName = "Rawda",
                LastName = "Wawi"
            };

            // Create second Employee object and assign values
            Employee emp2 = new Employee
            {
                Id = 102,  // Change this to 101 to test equality
                FirstName = "Rawda",
                LastName = "Wawi"
            };

            // Compare the two Employee objects using the overloaded '==' operator
            if (emp1 == emp2)
            {
                Console.WriteLine("emp1 and emp2 are equal (have the same Id).");
            }
            else
            {
                Console.WriteLine("emp1 and emp2 are NOT equal (different Ids).");
            }

            // Compare the two Employee objects using the overloaded '!=' operator
            if (emp1 != emp2)
            {
                Console.WriteLine("emp1 and emp2 are different (Ids do not match).");
            }
            else
            {
                Console.WriteLine("emp1 and emp2 are the same (Ids match).");
            }

            // Pause the console so it doesn't close immediately
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
