using Gym_Booking_Manager;
using Gym_Booking_Manager.Interfaces;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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


        protected User(int uniqueID, string name = "", string phone = "", string email = "")
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
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }
        }

        public static void ReserveMenu(string user = "")
        {
            Console.WriteLine("What would you like to reserve?");
            List<string> reservationOptions = new List<string>()
            {
                "Equipment",
                "Space",
                "Personal Trainer",
                "Group Activity",
                "Go Back"
            };

            for (int i = 0; i < reservationOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reservationOptions[i]}");
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
    public enum AccessLevels
    {
        PayingMember,
        DayPassUser,
        NonPayingNonMember
    }

	internal class Customer : User
    {
        public static List<Customer> customerList = new List<Customer>();
        public static IReservingEntity ID;
        public AccessLevels AccessLevel { get; set; }

        public static List<string> logs = new List<string>();
        DateTime createdAt;
        public DateTime dayPassDate { get; set; }
        public static List<Resources> reservedItems;
        public Customer(int uniqueID, string name, string phone, string email, AccessLevels accessLevel = AccessLevels.NonPayingNonMember, List<Resources> resources = null) : base(uniqueID ,name, phone ,email)
        {
            this.createdAt = DateTime.Now;
            AccessLevel = accessLevel;
            customerList.Add(this);
            List<Resources > reservedItems = new List<Resources>();
		}
        public override string ToString()
        {
            return $"Name: {name}\nEmail: {email}\nPhone Number: {phone}\nAccount Created: {createdAt}";
        }
        public static void AddLog(string log)
        {
            logs.Add(log);
        }
        public static void ShowLogs()
        {
            Console.WriteLine("Logs:");
            foreach (string log in logs)
            {
                Console.WriteLine(log);
            }
        }
        public static void SendNotification(Customer customer, string message, bool useSMS)
        {
            string log = "Sending";
            if (useSMS)
            {
                log += " SMS to " + customer.phone + ": " + message;
            }
            else
            {
                log += " email to " + customer.email + ": " + message;
            }
            Console.WriteLine(log);
            Customer.AddLog(log);
        }

        public static void NonPayingNonMemberMenu()//TODO
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
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your phone number: ");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter your email: ");
                    string email = Console.ReadLine();
                    Customer customer = customerList.Find(c => c.name == name && c.phone == phone && c.email == email);
                    if (customer == null)
                    {
                        customer = new Customer(name, phone, email);
                    }
                    customer.AccessLevel = AccessLevels.DayPassUser;
                    customer.dayPassDate = DateTime.Now;
                    PayingMemberMenu();
                    break;
                case 2:
                    // TODO: Manage Account
                    break;
                case 3:
                    // TODO: Purchase daypass
                    Console.WriteLine("Enter the customer's name: ");
                    string customerName = Console.ReadLine();
                    Console.WriteLine("Enter the customer's phone number: ");
                    string customerPhone = Console.ReadLine();
                    Console.WriteLine("Enter the customer's email: ");
                    string customerEmail = Console.ReadLine();
                    Customer customerToUpgrade = Customer.customerList.Find(c => c.name == customerName && c.phone == customerPhone && c.email == customerEmail);
                    if (customerToUpgrade == null)
                    {
                        customerToUpgrade = new Customer(customerName, customerPhone, customerEmail, AccessLevels.DayPassUser);
                    }
                    else
                    {
                        customerToUpgrade.AccessLevel = AccessLevels.DayPassUser;
                    }
                    customerToUpgrade.dayPassDate = DateTime.Now;
                    Customer.PayingMemberMenu();
                    break;
                case 4:
                    Console.WriteLine("Enter the customer's name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter the customer's phone number: ");
                    phone = Console.ReadLine();
                    Console.WriteLine("Enter the customer's email address: ");
                    email = Console.ReadLine();
                    string message = "The Reservation was cancelled.";
                    customer = new Customer(name, phone, email);
                    Customer.SendNotification(customer, message, false);
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

            // TEMPORARY!!!!


            switch (command)
            {
                case 1:
                    // TODO: Purchase membership
                    Console.WriteLine("\nYou cannot buy a daypass for one of the following two reasons: ");
                    Console.WriteLine("1. You already have a daypass.");
                    Console.WriteLine("2. You are a paying member.\n");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
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
                    PayingMemberReservation();
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
            static void PayingMemberReservation()
            {
                while (true)
                {
                    Console.Clear();
                    ReserveMenu("user");
                    int n = int.Parse(Console.ReadLine());
                    switch (n)
                    {
                        case 1:
                            // Equipment
                            Equipment myEquipment = new Equipment();
                            myEquipment.MakeReservation(Customer.ID);
                            break;
                        case 2:
                            // Space
                            Space mySpace = new Space();
                            mySpace.MakeReservation(Customer.ID);
                            break;
                        case 3:
                            // Personal Trainer
                            break;
                        case 4:
                            // Group Activity
                            break;
                        case 5:
                            // Go Back
                            PayingMemberMenu();
                            break;
                    }
                }
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
                    Console.WriteLine("Enter the customer's name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the customer's phone number: ");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter the customer's email: ");
                    string email = Console.ReadLine();
                    Customer customer = Customer.customerList.Find(c => c.name == name && c.phone == phone && c.email == email);
                    if (customer == null)
                    {
                        customer = new Customer(name, phone, email, AccessLevels.PayingMember);
                    }
                    else
                    {
                        customer.AccessLevel = AccessLevels.PayingMember;
                    }
                    Customer.PayingMemberMenu();
                    break;
                case 2:
                    // TODO: Manage Account
                    break;
                case 3:
                    // TODO: Purchase daypass
                    Console.WriteLine("Enter the customer's name: ");
                    string customerName = Console.ReadLine();
                    Console.WriteLine("Enter the customer's phone number: ");
                    string customerPhone = Console.ReadLine();
                    Console.WriteLine("Enter the customer's email: ");
                    string customerEmail = Console.ReadLine();
                    Customer customerToUpgrade = Customer.customerList.Find(c => c.name == customerName && c.phone == customerPhone && c.email == customerEmail);
                    if (customerToUpgrade == null)
                    {
                        customerToUpgrade = new Customer(customerName, customerPhone, customerEmail, AccessLevels.DayPassUser);
                    }
                    else
                    {
                        customerToUpgrade.AccessLevel = AccessLevels.DayPassUser;
                    }
                    customerToUpgrade.dayPassDate = DateTime.Now;
                    Customer.PayingMemberMenu();
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

        public static void ListAllLogs()
        {
            Console.WriteLine("Available Logs: ");
            for (int i = 0; i < Customer.logs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Customer.logs[i]}");
            }
        }

        public static void ViewLog(int logIndex)
        {
            Console.WriteLine(Customer.logs[logIndex - 1]);
        }

        /*public static void CancelMembership(int customerID)
        {
            Customer customerToRemove = null;
            foreach (Customer customer in Customer.customerList)
            {
                if (customer.uniqueID == customerID)
                {
                    customerToRemove = customer;
                    break;
                }
            }
            if (customerToRemove != null)
            {
                Customer.customerList.Remove(customerToRemove);
                Console.WriteLine("Membership canceled successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }*/

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
                    ListAllLogs();
                    break;
                case 2:
                    // TODO: Purchase membership
                    Console.WriteLine("Enter the customer's name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the customer's phone number: ");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter the customer's email: ");
                    string email = Console.ReadLine();
                    Customer customer = Customer.customerList.Find(c => c.name == name && c.phone == phone && c.email == email);
                    if (customer == null)
                    {
                        customer = new Customer(name, phone, email, AccessLevels.PayingMember);
                    }
                    else
                    {
                        customer.AccessLevel = AccessLevels.PayingMember;
                    }
                    Customer.PayingMemberMenu();

                    break;
                case 3:
                    // TODO: Manage Account
                    Console.WriteLine("Enter the log index to view: ");
                    int logIndex = int.Parse(Console.ReadLine());
                    ViewLog(logIndex);
                    /*ADD another case TO Admin:
                    Console.WriteLine("Enter the customer ID to cancel the membership: ");
                    int customerID = int.Parse(Console.ReadLine());
                    CancelMembership(customerID);
                    break;*/
                    break;
                case 4:
                    // TODO: Purchase daypass
                    Console.WriteLine("Enter the customer's name: ");
                    string customerName = Console.ReadLine();
                    Console.WriteLine("Enter the customer's phone number: ");
                    string customerPhone = Console.ReadLine();
                    Console.WriteLine("Enter the customer's email: ");
                    string customerEmail = Console.ReadLine();
                    Customer customerToUpgrade = Customer.customerList.Find(c => c.name == customerName && c.phone == customerPhone && c.email == customerEmail);
                    if (customerToUpgrade == null)
                    {
                        customerToUpgrade = new Customer(customerName, customerPhone, customerEmail, AccessLevels.DayPassUser);
                    }
                    else
                    {
                        customerToUpgrade.AccessLevel = AccessLevels.DayPassUser;
                    }
                    customerToUpgrade.dayPassDate = DateTime.Now;
                    Customer.PayingMemberMenu();
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