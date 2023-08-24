// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using School.Business;
using School.ConsoleApp.UI;
using School.Data.Models;
using School.Data.Repository;

public class Program
{
    static async Task Main(string[] args)
    {
		await RegisterDependenciesAndStartApp(args);
    }

	private static async Task RegisterDependenciesAndStartApp(string[] args)
	{
		HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddTransient<IAcademicYearPage, AcademicYearPage>();
		builder.Services.AddTransient<IAcademicYearService, AcademicYearService>();
		builder.Services.AddTransient<IRepository<AcademicYear>, Repository<AcademicYear>>();
        builder.Services.AddDbContext<SchoolDbContext>();
		//_repository = new Repository<AcademicYear>(new SchoolDbContext(@"Data Source=C:/Users/abhilashgr/Documents/GitHub/School_App/School.Data/school_database.db"));

		using IHost host = builder.Build();
	
		StartSchoolApp(host.Services);

        await host.RunAsync();
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

