// See https://aka.ms/new-console-template for more information

using School.ConsoleApp.UI;

public class Program
{

    static void Main(string[] args)
    {
        var keepLooping = true;
        while (keepLooping)
        {
            try
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

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        AcademicYearPage.SubMenu();
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
            catch (Exception ex)
            {
                // Global exception handler
                Console.WriteLine(ex);
                keepLooping = false;
            }
        }
    }
}

