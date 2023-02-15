﻿using Gym_Booking_Manager;
using Gym_Booking_Manager.Interfaces;
using System;
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
        protected User(string name = "", string phone = "", string email = "")
        {
            this.uniqueID = new Random().Next(0, 1000);
            this.name = name;
            this.phone = phone;
            this.email = email;
        }
        public static List<User> userList = new List<User>();
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
            Console.WriteLine("------------------------------------------------\n");
            try
            {
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
                        //Console.Clear();
                        //Program.MainMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }
            }
            catch (FormatException e)
            {
                //FormatException error message
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
        //---------------------Equipment --------------------------------------------------
        public static void EquipmentType()
        {
            Console.WriteLine("--------------Equipment Menu-------------");
            Console.WriteLine("1. View Equipment by Service");
            Console.WriteLine("2. View Equipment by Planned Purchase");
            Console.WriteLine("3. View Available Equipment by Time Slot");
            Console.WriteLine("4. View Available Sport Equipment");
            Console.WriteLine("5. View Available Large Equipment");
            Console.WriteLine("6. Reserve Equipment");
            Console.WriteLine("7. Go back");
            Console.WriteLine("------------------------------------------\n");
            Console.Write("\nSelect an option: ");
            try
            {
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:// ShowService
                        Equipment.ShowService();
                        break;
                    case 2:// PlannedPurchase
                        Equipment.ShowPlannedPurchase();
                        break;
                    case 3: // Available 
                        Console.Write("\nEnter a timeslot Example \"9am-10am\"): ");
                        string timeslot = Console.ReadLine();
                        Equipment.ShowAvailable(timeslot);
                        break;
                    case 4:// AvailableSport
                        Equipment.ShowAvailableSport();
                        break;
                    case 5:// AilableLarge
                        Equipment.ShowAvailableLarge();
                        break;
                    case 6: // TODO: Reservation Time Slots
                        break;
                    case 7:
                        Console.WriteLine("\nExiting program...");
                        User.EquipmentType();
                        break;
                        Console.Clear();
                        Program.MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }
            }
            catch (FormatException e)
            {
                //FormatException error message
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
        //--------------------The Above Equiptment Menu Is Ready------------------------
        //---------------------Equipment Menu Options Below Can be Deleted or Modified--------------------------------------------------
        public static void ViewEquipmentByType()
        {
            Console.WriteLine("--------------View Equipment by Type-------------");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Go back");
            Console.WriteLine("------------------------------------------\n");
            Console.Write("\nSelect an option: ");

            try
            {
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("\nGoing back to previous menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please type a number between 1 and 4.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please type a number.");
            }
        }
        public static void ViewEquipmentByService()
        {
            Console.WriteLine("--------------View Equipment by Service-------------");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Option 4");
            Console.WriteLine("5. Go back");
            Console.WriteLine("------------------------------------------\n");
            Console.Write("\nSelect an option: ");

            try
            {
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("\nGoing back to previous menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid input, please type a number between 1 and 5.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please type a number.");
            }
        }
        public static void ViewEquipmentByPlannedPurchase()
        {
            Console.WriteLine("------- View Equipment by Planned Purchase Menu--------");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Option 4");
            Console.WriteLine("5. Go back");
            Console.WriteLine("------------------------------------------\n");
            Console.Write("\nSelect an option: ");

            try
            {
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("\nGoing back to previous menu...");
                        // Code to return to the previous menu
                        break;
                    default:
                        Console.WriteLine("Invalid input, please type a number between 1 and 5.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please type a number.");
            }
        }
        public static void ViewAvailableEquipmentByTimeSlot()
        {
            Console.WriteLine("-------------- View Available Equipment by Time Slot Menu --------------");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Go back to the previous menu");
            Console.WriteLine("-------------------------------------------------------------------------\n");

            Console.Write("Select an option: ");

            try
            {
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("\nGoing back to the previous menu...");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please select a valid option.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            // After displaying the available equipment, you can return to the main menu
            Program.MainMenu();
        }
        //--------------------The Above Menu Options can be changed or Deleted-------------------------------
        //---------------------Equipment Menu Options Above--------------------------------------------------

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
                    "Equipment",
                    "Group Activity",
                    "Log out"
                };

            if (user == "staff")
            {
                menuOptions.Remove("View Logs");
            }
            else if (user == "payingmember")
            {
                menuOptions.Remove("Purchase Membership");
                menuOptions.Remove("Purchase Day Pass");
                menuOptions.Remove("Manage group Schedule");
                menuOptions.Remove("Restrict item");
                menuOptions.Remove("Add item");
                menuOptions.Remove("Group Activity");
            }
            else if (user == "user")
            {
                menuOptions.Remove("View Logs");
                menuOptions.Remove("Manage group Schedule");
                menuOptions.Remove("Add item");
                menuOptions.Remove("Restrict item");
                menuOptions.Remove("Make Reservation");
                menuOptions.Remove("View Item");
                menuOptions.Remove("Group Activity");
            }

            else if (user == "daypass")
            {
                menuOptions.Remove("View Logs");
                menuOptions.Remove("Purchase Day Pass");
                menuOptions.Remove("Add item");
                menuOptions.Remove("Restrict item");
                menuOptions.Remove("Manage group Schedule");
                menuOptions.Remove("Equipment");
                menuOptions.Remove("Group Activity");
            }

            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }
        }

        public static void ReserveMenu(AccessLevels accessLevels)
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
            if (accessLevels == AccessLevels.NonPayingNonMember)
            {
                reservationOptions.Remove("Space");
				reservationOptions.Remove("Personal Trainer");
				reservationOptions.Remove("Group Activity");
			}
            for (int i = 0; i < reservationOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reservationOptions[i]}");
            }
			int n = int.Parse(Console.ReadLine());
            // Choosing cutomer
			int x = 0;
            if (accessLevels == AccessLevels.NonPayingNonMember)
            {
                switch (n)
                {
                    case 1:
						// Equipment
						Equipment myEquipment = new Equipment();
						myEquipment.MakeReservation(Customer.ID, Customer.customerList[x], Customer.customerList[x].AccessLevel);
						break;
					case 2:
						// Go Back
						// Usermenu
						break;
                    default:
                        Console.WriteLine("Not a valid choice");
                        break;
                }
            }
            else
            {
		        // TODO: Find user ind3ex based on unique ID in customer list
		        Customer.ID = new ReservingEntity(Customer.customerList[x].uniqueID);
		        switch (n)
		        {
			        case 1:
				        // Equipment
				        Equipment myEquipment = new();
				        myEquipment.MakeReservation(Customer.ID, Customer.customerList[x], Customer.customerList[x].AccessLevel);
				        break;
			        case 2:
				        // Space
				        Space mySpace = new();
				        mySpace.MakeReservation(Customer.ID, Customer.customerList[x], Customer.customerList[x].AccessLevel);
				        break;
			        case 3:
				        // Personal Trainer
                        PersonalTrainer myTrainer = new();
                        myTrainer.MakeReservation(Customer.ID, Customer.customerList[x], Customer.customerList[x].AccessLevel);
				        break;
			        case 4:
				        Console.Clear();
				        GroupSchedule.showActivities();
				        Console.WriteLine("What group activity do you want to participate in? ");
				        string activityChoice = Console.ReadLine();
				        for (int i = 0; i < GroupSchedule.groupScheduleList.Count; i++)
				        {
					        if (GroupSchedule.groupScheduleList[i].typeOfActivity.Contains(activityChoice))
					        {
						        GroupSchedule.addCustomerToActivity(userList[0], GroupSchedule.groupScheduleList[i]);
					        }
				        }
				        //PayingMemberMenu();
				        break;
			        case 5:
				        // Go Back
				        //PayingMemberMenu();
				        break;
                    default:
                        break;
		        }

            }

		}
        public static void LoginMenu()
        {
            Console.WriteLine("-------------Member Access Menu:-------------");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Staff");
            Console.WriteLine("3. Service");
            Console.WriteLine("4. Paying Member");
            Console.WriteLine("5. Day Pass");
            Console.WriteLine("6. User");
            Console.WriteLine("7. Quit");
            Console.WriteLine("---------------------------------------------\n");
            try
            {
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        Admin.AdminMenu();
                        break;
                    case 2:
                        Staff.StaffMenu();
                        break;
                    case 3:
                        Service.ServiceMenu();
                        break;
                    case 4:
                        Customer.PayingMemberMenu();
                        break;
                    case 5:
                        // Day Pass
                        Customer.DayPassMenu();
                        break;
                    case 6: // User
                        Customer.UserMenu();
                        break;
                    case 7:
                        Console.WriteLine("\nExiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }
            }
            catch (FormatException e)
            {
                //FormatException error message
                Console.WriteLine("Error: Please enter a valid number.");
                User.LoginMenu();
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
            try
            {
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
            catch (FormatException e)
            {
                //FormatException error message
                Console.WriteLine("Error: Please enter a valid number.");
            }
        }
    }
    public enum AccessLevels
    {
        PayingMember,
        DayPassUser,
        NonPayingNonMember
    }

	public class ReservingEntity : IReservingEntity
	{
		public string owner { get; set; }
        public AccessLevels AccessLevel;

		public ReservingEntity(int id, AccessLevels accessLevels = 0)
		{
			owner = id.ToString();
        }
        public ReservingEntity(string id)
        {
            owner = id;
        }
	}

	internal class Customer : User
    {
        public static List<Customer> customerList = new List<Customer>();
        public AccessLevels AccessLevel { get; set; }
        public static List<string> logs = new List<string>();
        DateTime createdAt;
        public DateTime dayPassDate { get; set; }
        public List<Resources> reservedItems {get; set;}
        public static IReservingEntity ID;
        public Customer(string name, string phone, string email, AccessLevels accessLevel = AccessLevels.NonPayingNonMember) : base(name, phone ,email)
        {
            this.createdAt = DateTime.Now;
            this.AccessLevel = accessLevel;
            customerList.Add(this);
            this.reservedItems = new List<Resources>();
            uniqueID = new Random().Next(0, 1000);
            ID = new ReservingEntity(uniqueID);
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
        public static void UserMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------User Menu-------------");
            menu("user");
            Console.WriteLine("-----------------------------------\n");

            try
            {
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        // Purchase membership
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
                        Console.WriteLine("\nMember details and starting date:");
                        Console.WriteLine("Name: {0}", customer.name);
                        Console.WriteLine("Phone: {0}", customer.phone);
                        Console.WriteLine("Email: {0}", customer.email);
                        Console.WriteLine("Membership start date: {0}", customer.dayPassDate.ToString("yyyy/MM/dd"));
                        Console.WriteLine("Press Enter to return to User Menu");
                        Console.ReadKey();
                        UserMenu();
                        break;
                    case 2:// Todo: Manage Account
                        break;
                    case 3:// TODO: Purchase daypass
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
                        Console.WriteLine(customerToUpgrade.ToString());
                        Console.WriteLine("You have purchased a Day Pass.");
                        Console.WriteLine("Press Enter to return to User Menu.");
                        Console.ReadLine();
                        Customer.UserMenu();
                        break;
                    case 4:// Cancel Reservation
                        Console.WriteLine("Enter the customer's name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the customer's phone number: ");
                        phone = Console.ReadLine();
                        Console.WriteLine("Enter the customer's email address: ");
                        email = Console.ReadLine();
                        string message = "The Reservation was cancelled.";
                        customer = new Customer(name, phone, email);
                        Customer.SendNotification(customer, message, false);
                        Console.WriteLine("Press Enter to return to User Menu");
                        Console.ReadKey();
                        UserMenu();
                        break;
                    case 5:// TODO: View Group Schedule
                        break;
                    case 6:
                        Console.Clear();
                        Customer.UserMenu();
                        break;
                    default:
                        Console.WriteLine("Logged out");
                        break;
                }
            }
            catch (FormatException e)
            {
                //FormatException error message
                Console.WriteLine("Error: Please enter a valid number.");
                Customer.UserMenu();
            }
        }
        public static void DayPassMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------Day Pass-------------");
            menu("daypass");
            Console.WriteLine("----------------------------------\n");
            try
            {
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
                        Customer.DayPassMenu();
                        break;
                    case 2:
                        // TODO: Manage Account
                        break;
                    case 3:
                        // TODO: Cancel Reservation
                        Console.WriteLine("Enter the customer's name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the customer's phone number: ");
                        phone = Console.ReadLine();
                        Console.WriteLine("Enter the customer's email address: ");
                        email = Console.ReadLine();
                        string message = "The Reservation was cancelled.";
                        customer = new Customer(name, phone, email);
                        Customer.SendNotification(customer, message, false);
                        Customer.DayPassMenu();
                        break;
                    case 4:// TODO: View Group Schedule
                        break;
                    case 5:
                        // TODO: Make Reservation
                        ReserveMenu(AccessLevels.DayPassUser);
                        break;
                    case 6:
                        // TODO: View Items
                        break;
                    case 7:
                        Console.Clear();
                        Program.MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }
            }
            catch (FormatException e)
            {
                //FormatException error message
                Console.WriteLine("Error: Please enter a valid number.");
                Customer.DayPassMenu();
            }

        }

        public static void PayingMemberMenu() // Access Level Issues
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------Paying Member-------------");
                menu("payingmember");
                Console.WriteLine("---------------------------------------");
                int command;

                try
                {
                    command = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    continue;
                }

                switch (command)
                {
                    case 1:
                        // TODO: View Logs
                        break;
                    case 2:
                        // TODO: Manage Account
                        break;
                    case 3://CancelReservation
                        Console.WriteLine("Enter the name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Enter the email address: ");
                        string email = Console.ReadLine();
                        string message = "The Reservation was cancelled.";
                        Customer customer = new Customer(name, phone, email);
                        Customer.SendNotification(customer, message, false);
                        Console.WriteLine("Press Enter to return to Paying Member Menu");
                        Console.ReadKey();
                        break;
                    case 4:
                        // TODO: View group schedule
                        break;
                    case 5:// Make reservation
                        PayingMemberReservation();
                        break;
                    case 6:
                        // TODO: View items
                        break;
                    case 7:
                        EquipmentType();
                        break;
                    case 8:
                        Console.Clear();
                        Program.MainMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }

            }
        }

        static void PayingMemberReservation()
        {
            Console.Clear();
            ReserveMenu(AccessLevels.PayingMember);                      
        }

    }

    internal class Staff : User
    {
        public Staff(string name, string phone, string email) : base(name, phone, email)
        {
        }

        public static void StaffMenu()
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("--------------Staff Main Menu-------------");
                menu("staff");
                Console.WriteLine("------------------------------------------\n");
                int command;

                try
                {
                    command = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    continue;
                }
                switch (command)
                {
                    case 1:
                        // Purchase membership
                        Console.WriteLine("Enter the name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
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
                        Console.WriteLine("Member details and starting date:");
                        Console.WriteLine(customer.ToString());
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Staff.StaffMenu();
                        break;
                    case 2:
                        // TODO: Manage Account
                        break;
                    case 3:
                        // TODO: Purchase daypass
                        Console.WriteLine("Enter the name: ");
                        string customerName = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string customerPhone = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
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
                        Console.WriteLine(customerToUpgrade.ToString());
                        Console.WriteLine("You have purchased a Day Pass.");
                        Console.WriteLine("Press Enter to return to the Staff Main Menu.");
                        Console.ReadLine();
                        Staff.StaffMenu();
                        break;
                    case 4:
                        // Cancel reservation
                        Console.WriteLine("Enter the name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        phone = Console.ReadLine();
                        Console.WriteLine("Enter the email address: ");
                        email = Console.ReadLine();
                        string message = "The Reservation was cancelled.";
                        customer = new Customer(name, phone, email);
                        Customer.SendNotification(customer, message, false);
                        Console.WriteLine("Press Enter to return to User Menu");
                        Console.ReadKey();
                        Staff.StaffMenu();
                        break;
                    case 5:// View group Schedule
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
                        break;
                    case 11:
                        EquipmentType();
                        break;
                    case 12://TODO Group Activity
                        break;
                    case 13:
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }
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
        public static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------Admin-------------");
                menu();
                Console.WriteLine("---------------------------------\n");
                int command;
                try
                {
                    command = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                    continue;
                }
                switch (command)
                {
                    case 1:
                        // View logs 
                        ListAllLogs();
                        break;
                    case 2:
                        // Purchase membership
                        Console.WriteLine("Enter the name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
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
                        Console.WriteLine("Member details and starting date:");
                        Console.WriteLine(customer.ToString());
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Admin.AdminMenu();
                        break;
                    case 3:
                        // Manage Account
                        Console.WriteLine("Enter the log index to view: ");
                        int logIndex = int.Parse(Console.ReadLine());
                        ViewLog(logIndex);
                        break;
                    case 4:
                        // Purchase daypass
                        Console.WriteLine("Enter the name: ");
                        string customerName = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string customerPhone = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
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
                        Console.WriteLine(customerToUpgrade.ToString());
                        Console.WriteLine("You have purchased a Day Pass.");
                        Console.WriteLine("Press Enter to return to Admin Menu.");
                        Console.ReadLine();
                        Admin.AdminMenu();
                        break;
                    case 5:
                        // Cancel reservation
                        Console.WriteLine("Enter the name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        phone = Console.ReadLine();
                        Console.WriteLine("Enter the email address: ");
                        email = Console.ReadLine();
                        string message = "The Reservation was cancelled.";
                        customer = new Customer(name, phone, email);
                        Customer.SendNotification(customer, message, false);
                        Console.WriteLine("Press Enter to return to Admin Menu");
                        Console.ReadKey();
                        Admin.AdminMenu();
                        break;
                    case 6:
                        // TODO: View group schedule
                        break;
                    case 7:
                        // TODO: Manage group Schedule
                        manageSchedule();
                        break;
                    case 8:
                        // TODO: Make reservation
                        break;
                    case 9:
                        // TODO: View items
                        break;
                    case 10:
                        RestrictItem();
                        break;
                    case 11:
                        // TODO: Add item
                        break;
                    case 12:
                        EquipmentType();
                        break;
                    case 13:// TODO: Group Activity
                        break;
                    case 14:
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
}