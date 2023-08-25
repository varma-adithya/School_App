// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Business;
using School.ConsoleApp.UI;
using School.Data.Models;
using School.Data.Repository;

public class Program
{
    static void Main(string[] args)
    {
		RegisterDependenciesAndStartApp(args);
    }

	private static void RegisterDependenciesAndStartApp(string[] args)
	{

        //setup our DI
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddTransient<IAcademicYearPage, AcademicYearPage>()
            .AddTransient<IAcademicYearService, AcademicYearService>()
            .AddTransient<IRepository<AcademicYear>, Repository<AcademicYear>>()
            .AddDbContext<SchoolDbContext>(options =>
			{
				options.UseSqlite("Data Source=school_database.db");
			})
            .BuildServiceProvider();

		//_repository = new Repository<AcademicYear>(new SchoolDbContext(@"Data Source=C:/Users/abhilashgr/Documents/GitHub/School_App/School.Data/school_database.db"));

	
		StartSchoolApp(serviceProvider);
	}

	private static void StartSchoolApp(IServiceProvider serviceProvider)
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
						var academicYearPage = serviceProvider.GetService<IAcademicYearPage>();
						academicYearPage!.SubMenu();
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

