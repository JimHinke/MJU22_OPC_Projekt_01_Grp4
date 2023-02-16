using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Menutracker : User
    {

        //MAIN MENUS
        public static void menu()
        {
            Console.WriteLine(logedInUser);
            List<string> menuOptions = new List<string>()
                {
                    "View Logs (NYI)",
                    "Purchase Membership",
                    "Manage Account (NYI)",
                    "Purchase Day Pass(INTE KLAR)",
                    "Cancel Reservation(INTE KLAR)",
                    "View group Schedule",
                    "Manage group Schedule",
                    "Make Reservation(NYI)",
                    "View Item(NYI)",
                    "Restrict item(NYI)",
                    "Add item(NYI)",
                    "Equipment(NYI/?)",
                    "Group Activity(NYI/?)",
                    "Log out"
                };

            if (logedInUser != null && logedInUser.accessLevels == AccessLevels.PayingMember)
            {
                menuOptions.Remove("View Logs (NYI)");
                menuOptions.Remove("Purchase Membership");
                menuOptions.Remove("Purchase Day Pass(INTE KLAR)");
                menuOptions.Remove("Manage group Schedule");
                menuOptions.Remove("Restrict item(NYI)");
                menuOptions.Remove("Add item(NYI)");
                menuOptions.Remove("Group Activity(NYI/?)");
            }
            else if (logedInUser != null && logedInUser.accessLevels == AccessLevels.Member)
            {
                menuOptions.Remove("View Logs (NYI)");
                menuOptions.Remove("Manage group Schedule");
                menuOptions.Remove("Add item");
                menuOptions.Remove("Restrict item");
                menuOptions.Remove("Make Reservation");
                menuOptions.Remove("View Item");
                menuOptions.Remove("Group Activity");
            }

            else if (logedInUser != null && logedInUser.accessLevels == AccessLevels.DayPassUser)
            {
                menuOptions.Remove("View Logs (NYI)");
                menuOptions.Remove("Purchase Day Pass(INTE KLAR)");
                menuOptions.Remove("Add item(NYI)");
                menuOptions.Remove("Restrict item(NYI)");
                menuOptions.Remove("Manage group Schedule");
                menuOptions.Remove("Equipment(NYI/?)");
                menuOptions.Remove("Group Activity(NYI/?)");
            }

            else if (logedInUser != null && logedInUser.accessLevels == AccessLevels.Admin)
            {

            }

            else if (logedInUser.accessLevels == AccessLevels.NonPayingNonMember)
            {
                menuOptions.Remove("View Logs (NYI)");
                menuOptions.Remove("Manage Account (NYI)");
                menuOptions.Remove("Manage group Schedule");
                menuOptions.Remove("Restrict item(NYI)");
                menuOptions.Remove("Add item(NYI)");
                menuOptions.Remove("Equipment(NYI/?)");
                menuOptions.Remove("Group Activity(NYI/?)");
                menuOptions.Remove("Cancel Reservation(INTE KLAR)");

            }

            for (int i = 0; i < menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuOptions[i]}");
            }
        }
        public static void MainMenu()
        {
            Console.WriteLine("-------------Main Menu:-------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create account");
            Console.WriteLine("3. Non member access");
            Console.WriteLine("4. Quit");
            Console.WriteLine("------------------------------------\n");
            try
            {
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        LoginMenu();
                        break;
                    case 2:
                        DayPassMenu();
                        break;
                    case 3:
                        logedInUser = new Customer("No member", "No Phone", "No Email", AccessLevels.NonPayingNonMember);
                        Console.Clear();
                        UserMenu(); ;
                        break;
                    case 4:
                        Console.WriteLine("\nExiting program...");

                        CsvHandler csvHandler = new CsvHandler();
                        csvHandler.WriteFile(Space.spaceList, "Spaces.txt");
                        csvHandler.WriteFile(Equipment.equipmentList, "Equipment.txt");
                        csvHandler.WriteFile(PersonalTrainer.personalTrainers, "PersonalTrainer.txt");
                        //csvHandler.WriteFile(Space.spaceList, "GroupActivity.txt");

                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        public static void LoginMenu()
        {
            //As the loginsystem is not complete we have to set an given user on what login-type you are using.

            //This can be changed betewen PayingMember/DayPassUser
            User testCustomer = new Customer("Test Customer", "0987321", "testCustomer@test.se", AccessLevels.PayingMember) { uniqueID = 10 };

            User testStaff = new Staff("Test Staff 1", "1234", "test1@gmail.com", AccessLevels.Staff) { uniqueID = 20 };
            User testAdmin = new Admin("Test Admin", "098873", "testAdmin@gmail.com", AccessLevels.Admin);
            User testService = new Service("Test Service", "0899991", "testService@gomail.com", AccessLevels.Service);

            Console.WriteLine("-------------Member Access Menu:-------------");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Staff");
            Console.WriteLine("3. Service");
            Console.WriteLine("4. Member");
            Console.WriteLine("7. Go Back");
            Console.WriteLine("---------------------------------------------\n");
            try
            {
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        Console.Clear();
                        User.logedInUser = testAdmin;
                        AdminMenu();
                        break;
                    case 2:
                        Console.Clear();
                        User.logedInUser = testStaff;
                        StaffMenu();
                        break;
                    case 3:
                        Console.Clear();
                        User.logedInUser = testService;
                        ServiceMenu();
                        break;
                    case 4:
                        Console.Clear();
                        User.logedInUser = testCustomer;
                        if (logedInUser.accessLevels == AccessLevels.DayPassUser)
                        {
                            DayPassMenu();
                        }
                        else if (logedInUser.accessLevels == AccessLevels.PayingMember)
                        {
                            PayingMemberMenu();
                        }
                        break;
                    case 5:
                        //None Member Choice
                        break;
                    case 6:
                        MainMenu();
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
                LoginMenu();
            }
        }



        //ADMIN
        public static void AdminMenu()
        {
            while (true)
            {
                //Console.Clear();
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
                        Console.Clear();
                        // View logs 
                        //ListAllLogs();
                        break;
                    case 2:
                        // Purchase membership
                        Console.Clear();
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
                            //customer.AccessLevel = AccessLevels.PayingMember;
                        }
                        else
                        {
                            customer.AccessLevel = AccessLevels.PayingMember;
                        }
                        Console.WriteLine("Member details and starting date:");
                        Console.WriteLine(customer.ToString());
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        AdminMenu();
                        break;
                    case 3:
                        Console.Clear();
                        // Manage Account
                        //Console.WriteLine("Enter the log index to view: ");
                        //int logIndex = int.Parse(Console.ReadLine());
                        //ViewLog(logIndex);
                        break;
                    case 4:
                        Console.Clear();
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
                        AdminMenu();
                        break;
                    case 5:
                        Console.Clear();
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
                        AdminMenu();
                        break;
                    case 6:
                        Console.Clear();
                        GroupSchedule.showActivities();
                        break;
                    case 7:
                        Console.Clear();
                        manageSchedule();
                        break;
                    case 8:
                        Console.Clear();
                        // TODO: Make reservation
                        break;
                    case 9:
                        Console.Clear();
                        // TODO: View items
                        break;
                    case 10:
                        Console.Clear();
                        RestrictItem();
                        break;
                    case 11:
                        Console.Clear();
                        // TODO: Add item
                        break;
                    case 12:
                        Console.Clear();
                        EquipmentType();
                        break;
                    case 13:
                        Console.Clear();
                        // TODO: Group Activity
                        break;
                    case 14:
                        Console.Clear();
                        Menutracker.MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }
            }
        }


        //STAFF
        public static void StaffMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------Staff Main Menu-------------");
                menu();
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
                        Console.Clear();
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
                        StaffMenu();
                        break;
                    case 2:
                        // TODO: Manage Account
                        Console.Clear();
                        StaffMenu();
                        break;
                    case 3:
                        // TODO: Purchase daypass
                        Console.Clear();
                        Console.WriteLine("Enter the name: ");
                        string customerName = Console.ReadLine();
                        Console.WriteLine("Enter the phone number: ");
                        string customerPhone = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
                        string customerEmail = Console.ReadLine();
                        Customer customerToUpgrade = Customer.customerList.Find(c => c.name == customerName && c.phone == customerPhone && c.email == customerEmail);
                        if (customerToUpgrade == null)
                        {
                            customerToUpgrade = new Customer(customerName, customerPhone, customerEmail);
                            customerToUpgrade.AccessLevel = AccessLevels.DayPassUser;
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
                        StaffMenu();
                        break;
                    case 4:
                        // Cancel reservation
                        Console.Clear();
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
                        StaffMenu();
                        break;
                    case 5://Cancel Reservation
                        Console.Clear();
                        StaffMenu();
                        break;
                    case 6:
                        Console.Clear();
                        GroupSchedule.showActivities();
                        Console.Clear();
                        StaffMenu();
                        break;
                    case 7:
                        Console.Clear();
                        manageSchedule();
                        break;
                    case 8:
                        // TODO: Make reservation
                        Console.Clear();
                        break;
                    case 9:
                        // TODO: View items
                        Console.Clear();
                        break;
                    case 10:
                        Console.Clear();
                        RestrictItem();
                        break;
                    case 11:
                        Console.Clear();
                        // TODO: Add item
                        break;
                    case 12:
                        Console.Clear();
                        EquipmentType();
                        break;
                    case 13:
                        Console.Clear();
                        //TODO Group Activity
                        break;
                    case 14:
                        Console.Clear();
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }
            }
        }

        //CUSTOMER
        public static void UserMenu()
        {
            //Console.Clear();
            Console.WriteLine("-------------None Member Access Menu-------------");
            menu();
            Console.WriteLine("-----------------------------------\n");

            try
            {
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        //TODO Purchase Membership
                        Console.Clear();
                        UserMenu();
                        break;
                    case 2:
                        //TODO: Purchase daypass
                        Console.Clear();
                        UserMenu();
                        break;
                    case 3:
                        
                        GroupSchedule.showActivities();
                        UserMenu();
                        break;
                    case 4:
                        //TODO Make Reservation
                        Console.Clear();
                        UserMenu();
                        break;
                    case 5:
                        //TODO View Item
                        Console.Clear();
                        UserMenu();
                        break;
                    case 6:
                        Console.Clear();
                        MainMenu();
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
                UserMenu();
            }
        }
        public static void DayPassMenu()
        {
            Console.WriteLine("-------------Day Pass-------------");
            menu();
            Console.WriteLine("----------------------------------\n");
            try
            {
                int command = int.Parse(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        Console.Clear();
                        // TODO: Purchase membership
                        Console.WriteLine("Enter your name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter your phone number: ");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Enter your email: ");
                        string email = Console.ReadLine();
                        Customer customer = Customer.customerList.Find(c => c.name == name && c.phone == phone && c.email == email);
                        if (customer == null)
                        {
                            customer = new Customer(name, phone, email);
                        }
                        customer.AccessLevel = AccessLevels.DayPassUser;
                        customer.dayPassDate = DateTime.Now;
                        DayPassMenu();
                        break;
                    case 2:
                        Console.Clear();
                        // TODO: Manage Account
                        break;
                    case 3:
                        Console.Clear();
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
                        DayPassMenu();
                        break;
                    case 4:
                        // TODO: View Group Schedule
                        Console.Clear();
                        GroupSchedule.showActivities();
                        break;
                    case 5:
                        Console.Clear();
                        ReserveMenu(AccessLevels.DayPassUser);
                        break;
                    case 6:
                        Console.Clear();
                        // TODO: View Items
                        break;
                    case 7:
                        Console.Clear();
                        MainMenu();
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
                DayPassMenu();
            }

        }
        public static void PayingMemberMenu()
        {
            while (true)
            {
                Console.WriteLine("-------------Paying Member-------------");
                menu();
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
                        Console.Clear();
                        // TODO: Manage Account
                        break;
                    case 2:
                        Console.Clear();
                        // TODO: Cancel reservation
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
                    case 3:
                        Console.Clear();
                        GroupSchedule.showActivities();
                        break;
                    case 4:
                        Console.Clear();
                        //TODO Make reservation
                        Customer.PayingMemberReservation();
                        break;
                    case 5:
                        Console.Clear();
                        // TODO: View items
                        break;
                    case 6:
                        Console.Clear();
                        EquipmentType();
                        break;
                    case 7:
                        Console.Clear();
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid input, type a number");
                        break;
                }

            }
        }

        //SERVICE
        public static void ServiceMenu()
        {
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
                        Console.Clear();
                        Equipment.RepairEquipment();
                        ServiceMenu();
                        break;
                    case 2:
                        Console.Clear();
                        MainMenu();
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



        //OTHER MENU OPTIONS
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
                        GroupSchedule.editActivity();
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
                        EquipmentType();
                        break;
                        Console.Clear();
                        MainMenu();
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
            MainMenu();
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
}
