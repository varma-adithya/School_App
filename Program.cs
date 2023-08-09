using Microsoft.EntityFrameworkCore;
using School_App.Models;
using School_App.DriveUpload;
using School_App.Repository;

class Program
{
    static void Main(string[] args)
    {
        //var options = new DbContextOptionsBuilder<SchoolDbContext>()
        //    .UseSqlite("Data Source=C:/Side/School_App/school_database.db")
        //    .Options;


        //using (var context = new SchoolDbContext(options))
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("Hello:");
        //        Console.WriteLine("Enter menu to go to");
        //        Console.WriteLine("1. Student");
        //        Console.WriteLine("2. Marks");
        //        Console.WriteLine("3. Subject");
        //        Console.WriteLine("4. Update User");
        //        Console.WriteLine("5. Upload");
        //        Console.WriteLine("6. Exit");
        //        Console.Write("Enter your choice: ");
        //        int choice = int.Parse(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1:
        //                var Stud = new Studentfunc(context);
        //                Stud.ShowMenu();
        //                break;
        //            case 2:
        //                break;
        //            case 3:
        //                var Sub = new Subjectsfunc(context);
        //                Sub.ShowMenu();
        //                break;
        //            case 4:
        //                var User = new Userfunc(context);
        //                User.ShowMenu();
        //                return;
        //            case 5:
        //                var Upload = new DriveUpload();
        //                Upload.Upload();
        //                return;
        //            default:
        //                Console.WriteLine("Invalid choice. Please try again.");
        //                break;
        //        }
        //    }
        //}
    }


}
