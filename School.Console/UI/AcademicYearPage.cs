using School.Business;
using School.Data.Models;

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
