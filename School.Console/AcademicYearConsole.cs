using School.Business;

namespace School.Console
{
    public class AcademicYearConsole
    {
        public void AcademicYearSubMenu()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Academic Year Menu:");
                System.Console.WriteLine("1. Add Academic Year");
                System.Console.WriteLine("2. Show All Academic Years");
                System.Console.WriteLine("3. Update Academic Year");
                System.Console.WriteLine("4. Back to Main Menu");
                System.Console.Write("Enter your choice: ");

                int choice = int.Parse(System.Console.ReadLine());

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
                        System.Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void UpdateAcademicYear()
        {
            var year = new AcademicYearService();
            
            System.Console.WriteLine("Enter Start Year:");

        }

        private void ShowAllAcademicYears()
        {
            throw new NotImplementedException();
        }

        private void AddAcademicYear()
        {
            throw new NotImplementedException();
        }
    }
}
