using School.Business;
using School.Data.Models;
using Spectre.Console;

namespace School.ConsoleApp.UI
{
	public class AcademicYearPage : IAcademicYearPage
	{
        private IAcademicYearService _acService;
        
        public AcademicYearPage( IAcademicYearService acService )
        {
            _acService = acService;
        }

		public void SubMenu()
        {
            while (true)
            {

                Console.Clear();
                var selection = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Main Menu")
                    .PageSize(10)
                    .AddChoices("Add Academic Year", "Show All Academic Years", "Update Academic Year", "Manage Teachers", "Back to Main Menu"));


                switch (selection)
                {
                    case "Add Academic Year":
                        AddAcademicYear();
                        break;
                    case "Show All Academic Years":
                        ShowAllAcademicYears();
                        break;
                    case "Update Academic Year":
                        UpdateAcademicYear();
                        break;
                    case "Manage Teachers":
                        return;
                    case "Back to Main Menu":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void AddAcademicYear()
        {
            Console.Clear();
            Console.WriteLine("Enter start year in the Format yyyy");

            if (int.TryParse(Console.ReadLine(), out int startYear))
            {
                var academicYear = new AcademicYear { StartYear = startYear, EndYear = startYear + 1 };
                _acService.AddAcademicYear(academicYear);

                Console.WriteLine("Academic year added successfully");
                Console.WriteLine("Enter any key to go back");
                Console.ReadKey();
                return;
            }
            else
                AddAcademicYear();
        }

        public void UpdateAcademicYear()
        {
            Console.WriteLine("Enter Academic Year ID:");
            int.TryParse(Console.ReadLine(), out int academicYrId);
            var academicYear = _acService.GetAcademicYear(academicYrId);

            if (academicYear != null)
            {
                Console.WriteLine("Enter new start year in the Format yyyy");
                int.TryParse(Console.ReadLine(), out int newAcademicyr);
                academicYear.StartYear = newAcademicyr;
                academicYear.EndYear = newAcademicyr + 1;
                _acService.UpdateAcademicYear(academicYear);
                Console.WriteLine("Academic year updated successfully");
                Console.WriteLine("Enter any key to go back");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Academic Year not found.");
            }


        }

        public void ShowAcademicYearDetails(int academicYearId)
        {
            var academicYear = _acService.GetAcademicYear(academicYearId);

            if (academicYear != null)
            {
                Console.WriteLine($"Academic Year Id: {academicYear.Id}");
                Console.WriteLine($"Start Date: {academicYear.StartYear}");
                Console.WriteLine($"End Date: {academicYear.EndYear}");
                Console.WriteLine("Enter any key to go back");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Academic Year not found.");
            }
        }

        public void ShowAllAcademicYears()
        {
            foreach (var year in _acService.GetAllAcademicYear())
            {
                Console.WriteLine($"Academic Year Id: {year.Id}");
                Console.WriteLine($"Start Date: {year.StartYear}");
                Console.WriteLine($"End Date: {year.EndYear}");
            }
            Console.WriteLine("Enter any key to go back");
            Console.ReadKey();
            return;

        }
    }
}
