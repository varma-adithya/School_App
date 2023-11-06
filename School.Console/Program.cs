using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.Business;
using School.ConsoleApp.UI;
using School.Data.Models;
using School.Data.Repository;
using Spectre.Console;

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
			.AddTransient<IStudentPage, StudentPage>()
			.AddTransient<IStudentService, StudentService>()
			.AddTransient<IRepository<StudentDetail>, Repository<StudentDetail>>()
            .AddDbContext<SchoolDbContext>(options =>
			{
				options.UseSqlite("Data Source=school_database.db");
			})
            .BuildServiceProvider();
	
		StartSchoolApp(serviceProvider);
	}

	private static void StartSchoolApp(IServiceProvider serviceProvider)
	{
		var keepLooping = true;
		while (keepLooping)
		{
			Console.Clear();
			var selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
				.Title("Main Menu")
				.PageSize(10)
				.AddChoices("Manage Academic Year","Manage Students","Manage Subjects","Manage Teachers","Manage Classes","Exit"));
			try
			{
				switch (selection)
				{
					case "Manage Academic Year":
						var academicYearPage = serviceProvider.GetService<IAcademicYearPage>();
						academicYearPage!.SubMenu();
						break;
					case "Manage Students":
						var studentPage = serviceProvider.GetService<IStudentPage>();
						studentPage!.SubMenu();
						break;
					case "Manage Subjects":
						break;
					case "Manage Teachers":
						break;
					case "Manage Classes":
						break;
					case "Exit":
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

