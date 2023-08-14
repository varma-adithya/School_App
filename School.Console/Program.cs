// See https://aka.ms/new-console-template for more information
using School.Business;
using School.Data.Models;
using School.Data.Repository;
public class Program
{

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Manage Academic Year");
            Console.WriteLine("2. Manage Students");
            Console.WriteLine("3. Manage Subjects");
            Console.WriteLine("4. Manage Teachers");
            Console.WriteLine("5. Manage Classes");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AcademicYearConsole();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

