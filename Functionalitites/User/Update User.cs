using School_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_App.Functionalitites.User
{
    public class Userfunc
    {

        private readonly SchoolDbContext context;

        public Userfunc(SchoolDbContext context)
        {
            this.context = context;
        }

        public void CreateUser()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter User Name: ");
                string inName = Console.ReadLine();

                Console.Write("Enter User Password: ");
                string inDesc = Console.ReadLine();


                var User = new Models.User
                {
                    Username = inName,
                    Password = inDesc
                };

                context.User.Add(User);

                ReadUser(User.UserId);
                Console.WriteLine("Please note User ID!! It is required to search a User");

                context.SaveChanges();

                Console.WriteLine("User added successfully!");
            }
        }

        public void ViewUser()
        {
            Console.Write("Enter User ID to view: ");
            int UserId;
            if (int.TryParse(Console.ReadLine(), out UserId))
            {
                ReadUser(UserId);
            }
            else
            {
                Console.WriteLine("Invalid User ID format.");
            }
        }

        public void ReadUser(int UserId)
        {
            //using (var context = new SchoolDbContext())
            {
                var User = context.User.Find(UserId);
                if (User != null)
                {
                    Console.WriteLine($"User ID: {User.UserId}");
                    Console.WriteLine($"User Name: {User.Username}");
                    Console.WriteLine($"User Password: {User.Password}");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
        }

        public void UpdateUser()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter User ID to update: ");
                int UserId = int.Parse(Console.ReadLine());

                var User = context.User.Find(UserId);
                if (User != null)
                {
                    Console.Write("Enter updated User Name: ");
                    User.Username = Console.ReadLine();

                    Console.Write("Enter updated User Password: ");
                    User.Password = Console.ReadLine();


                    context.SaveChanges();

                    Console.WriteLine("User updated successfully!");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
        }

        public void DeleteUser()
        {
            //using (var context = new SchoolDbContext())
            {
                Console.Write("Enter User ID to delete: ");
                int UserId = int.Parse(Console.ReadLine());

                var User = context.User.Find(UserId);
                if (User != null)
                {
                    context.User.Remove(User);
                    context.SaveChanges();

                    Console.WriteLine("User deleted successfully!");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Show info about User");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        UpdateUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        ViewUser();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
