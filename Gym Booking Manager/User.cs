using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal abstract class User
    {        
        public int uniqueID { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        protected User(string name = "", string phone = "", string email = "")
        {
            this.uniqueID = new Random().Next(0, 1000);
            this.name = name;
            this.phone = phone;
            this.email = email;
        }        
        public override string ToString()
        {
            return "ID: " + uniqueID + " Name: " + name + " Phone: " + phone + " Email: " + email;
        }
        public static void manageSchedule()
        {
            Console.Clear();
            Console.WriteLine("--------------Manage Group Schedule-------------");
            Console.WriteLine("1. Create New Group Activity");
            Console.WriteLine("2. Edit Group Activity");
            Console.WriteLine("3. Delete Group Activity");
            Console.WriteLine("4. Go Back");
            Console.WriteLine("----------------------------------\n");
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    Console.Clear();
                    GroupSchedule.addActivity();
                    break;
                case 2:
                    //TODO Edit Group Activity
                    Console.Clear();
                    break;
                case 3:
                    //TODO Delete Group Activity
                    Console.Clear();
                    GroupSchedule.addActivity();
                    break;
                case 4:
                    Console.Clear();
                    Program.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;
        }
    }
        public static void menu(string user = "")
        {
            List<string> menuOptions = new List<string>()
            {
                "View Logs",
                "Purchase Membership",
                "Manage Account (own only)",
                "Purchase Day Pass",
                "Cancel Reservation",
                "View group Schedule",
                "Manage group Schedule",
                "Make Reservation",
                "View Item",
                "Restrict item",
                "Add item",
                "Log out"
            };

            if (user == "staff")
            {
                menuOptions.Remove("View Logs");
            }
            else if (user == "user")
            {
                menuOptions.Remove("View Logs");
                menuOptions.Remove("Add item");
                menuOptions.Remove("Restrict item");
                menuOptions.Remove("Manage group Schedule");
            }

            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i+1}. {menuOptions[i]}");
            }
        }
    }

    internal class Service : User
    {  
        public Service(string name, string phone, string email) : base(name, phone, email)
        {
        }

        public static void ServiceMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------Service-------------");
            Console.WriteLine("1. Item Repair");
            Console.WriteLine("2. Log out");
            Console.WriteLine("----------------------------------\n");
            int command = int.Parse(Console.ReadLine());
                     
            switch (command)
            {
                case 1:
                    // TODO: Item Repair
                    Equipment.RepairEquipment();
                    ServiceMenu();
                    break;
                case 2:
                    Console.Clear();
                    Program.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;            
            }
        }
    }

    internal class Customer : User
    {
        DateTime createdAt;
        string accessLevel { get; set; }
        public Customer(string name, string phone, string email, string accessLevel = "") : base(name, phone, email)
        {
            this.createdAt = DateTime.Now;
            accessLevel = accessLevel;
        }
        public override string ToString()
        {
            return $"Name: {name}\nEmail: {email}\nPhone Number: {phone}\nAccount Created: {createdAt}";
        }

        public static void NonPayingNonMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------NonPayingNonMember-------------");
            menu("user");
            Console.WriteLine("--------------------------------------------\n");            
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    // TODO: Purchase membership
                    break;
                case 2:
                    // TODO: Manage Account
                    break;
                case 3:
                    // TODO: Purchase daypass
                    break;
                case 4:
                    // TODO: Cancel reservation
                    break;
                case 5:
                    // TODO: View group schedule
                    break;
                case 6:
                    // TODO: Make reservation
                    break;
                case 7:
                    // TODO: View items
                    break;
                case 8:
                    Console.Clear();
                    Program.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;
            }
        }

        public static void PayingMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------PayingMember-------------");
            menu("user");
            Console.WriteLine("--------------------------------------");
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    // TODO: Purchase membership
                    break;
                case 2:
                    // TODO: Manage Account
                    break;
                case 3:
                    Console.WriteLine("\nYou cannot buy a daypass for one of the following two reasons: ");
                    Console.WriteLine("1. You already have a daypass.");
                    Console.WriteLine("2. You are a paying member.\n");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case 4:
                    // TODO: Cancel reservation
                    break;
                case 5:
                    // TODO: View group schedule
                    break;
                case 6:
                    // TODO: Make reservation
                    break;
                case 7:
                    // TODO: View items
                    break;
                case 8:
                    Console.Clear();
                    Program.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number.");
                    break;
            }
        }
    }

    internal class Staff : User
    {
        public Staff(string name, string phone, string email) : base(name, phone, email)
        {
        }

        public static void StaffMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------Staff-------------");
            menu("staff");
            Console.WriteLine("---------------------------------\n");
            int command = int.Parse(Console.ReadLine());
            switch (command)
            {
                case 1:
                    // TODO: Purchase membership
                    break;
                case 2:
                    // TODO: Manage Account
                    break;
                case 3:
                    // TODO: Purchase daypass
                    break;
                case 4:
                    // TODO: Cancel reservation
                    break;
                case 5:
                    Console.Clear();
                    GroupSchedule.showActivities();
                    break;
                case 6:
                    // TODO: Manage group schedule
                    manageSchedule();
                    break;
                case 7:
                    // TODO: Make reservation
                    break;
                case 8:
                    // TODO: View items
                    break;
                case 9:
                    // TODO: Restrict item
                    RestrictItem();
                    break;
                case 10:
                // TODO: Add item
                case 11:
                    Console.Clear();
                    Program.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;
            }
        }
        public static void RestrictItem()
        {
            Console.Clear();
            Console.WriteLine("----------Restrict Item---------");
			Console.WriteLine("1. Equipment");
            Console.WriteLine("2. Space");
            Console.WriteLine("3. Go back");
			Console.WriteLine("--------------------------------");
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    Equipment.RestrictEquipment();
					break;
                case 2:
                    Space.RestrictSpace();
                    break;
                case 3:
                    StaffMenu();
                    break;

            }

		}
    }

    internal class Admin : Staff
    {
        public Admin(string name, string phone, string email) : base(name, phone, email)
        {
        }

        public static void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------Admin-------------");
            menu();
            Console.WriteLine("---------------------------------\n");
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    // TODO: Show logs here
                    break;
                case 2:
                    // TODO: Purchase membership
                    break;
                case 3:
                    // TODO: Manage Account
                    break;
                case 4:
                    // TODO: Purchase daypass
                    break;
                case 5:
                    // TODO: Cancel reservation
                    break;
                case 6:
                    // TODO: View group schedule
                    break;
                case 7:
                    // TODO: Update group schedule
                    break;
                case 8:
                    // TODO: Make reservation
                    break;
                case 9:
                    // TODO: View items
                    break;
                case 10:
                    // TODO: Restrict item
                    break;
                case 11:
                    // TODO: Add item
                    break;
                case 12:
                    Console.Clear();
                    Program.MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;
            }
        }
    }
}