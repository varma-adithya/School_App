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

            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    AcademicYearSubMenu();
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

    static void AcademicYearSubMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Academic Year Menu:");
            Console.WriteLine("1. Add Academic Year");
            Console.WriteLine("2. Show All Academic Years");
            Console.WriteLine("3. Update Academic Year");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    AddAcademicYear();
                    break;
                case 2:
                    ShowAllAcademicYears();
                    break;
                case 3:
                    UpdateAcademicYear();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddAcademicYear()
    {
        Console.Clear();
        Console.WriteLine("Enter start year in the Format yyyy");
        int.TryParse(Console.ReadLine(), out int startYear);
        var acService = new AcademicYearService(new Repository<AcademicYear>(new SchoolDbContext()));
        acService.AddAcademicYear(new AcademicYear { StartYear = startYear, EndYear = startYear + 1 });
    }

    static void UpdateAcademicYear()
    {
        throw new NotImplementedException();
    }

    static void ShowAllAcademicYears()
    {
        throw new NotImplementedException();
    }

    
}

