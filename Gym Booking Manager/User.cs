using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
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
        public Customer(string name, string phone, string email) : base(name, phone, email)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return $"Name: {name}\nEmail: {email}\nPhone Number: {phone}";
        }
    }

    class NonPayingNonMember : Customer
    {
        public NonPayingNonMember(string name, string phone, string email) : base(name, phone, email)
        {
        }
        
        public static void NonPayingNonMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------NonPayingNonMember-------------");
            Console.WriteLine("1. Purchase Membership");
            Console.WriteLine("2. Manage Account (own only)");
            Console.WriteLine("3. Purchase Day Pass");
            Console.WriteLine("4. Cancel Reservation");
            Console.WriteLine("5. View Group Schedule");
            Console.WriteLine("6. Make Reservation");
            Console.WriteLine("7. View Item");
            Console.WriteLine("8. Log out");
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
    }

    class NonPayingDayPass : Customer
    {
        public NonPayingDayPass(string name, string phone, string email) : base(name, phone, email)
        {
        }
        
        public static void NonPayingDayPassMenu()
        {
            Console.Clear(); 
            Console.WriteLine("-------------NonPayingDayPass-------------");
            Console.WriteLine("1. Purchase Membership");
            Console.WriteLine("2. Manage Account (own only)");
            Console.WriteLine("3. Purchase Day Pass");
            Console.WriteLine("4. Cancel Reservation");
            Console.WriteLine("5. View Group Schedule");
            Console.WriteLine("6. Make Reservation");
            Console.WriteLine("7. View Item");
            Console.WriteLine("8. Log out");
            Console.WriteLine("------------------------------------------\n");
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
    }

    class PayingMember : Customer
    {
        public PayingMember(string name, string phone, string email) : base(name, phone, email)
        {
        }

        public override string ToString()
        {
            return "ID: " + uniqueID + " Name: " + name + " Phone: " + phone + " Email: " + email;
        }

        public static void PayingMemberMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------PayingMember-------------");
            Console.WriteLine("1. Purchase Membership");
            Console.WriteLine("2. Manage Account (own only)");
            Console.WriteLine("3. Purchase Day Pass");
            Console.WriteLine("4. Cancel Reservation");
            Console.WriteLine("5. View Group Schedule");
            Console.WriteLine("6. Make Reservation");
            Console.WriteLine("7. View Item");
            Console.WriteLine("8. Log out");
            Console.WriteLine("---------------------------------------\n");
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
            Console.WriteLine("1.  Purchase membership");
            Console.WriteLine("2.  Manage account");
            Console.WriteLine("3.  Purchase daypass");
            Console.WriteLine("4.  Cancel reservation");
            Console.WriteLine("5.  View group schedule");
            Console.WriteLine("6.  Update group schedule");
            Console.WriteLine("7.  Make reservation");
            Console.WriteLine("8.  View item");
            Console.WriteLine("9.  Restrict item");
            Console.WriteLine("10. Add item");
            Console.WriteLine("11. Log out");
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
                    // TODO: View group schedule
                    break;
                case 6:
                    // TODO: Update group schedule
                    PersonalTrainer testAvPersonalTrainer = new PersonalTrainer("Personlig Tränare");
                    PersonalTrainer.personalTrainers.Add(testAvPersonalTrainer);
                    Space space = new Space("Hall");
                    Space.spaceList.Add(space);
                    GroupSchedule.addActivity();
                    break;
                case 7:
                    // TODO: Make reservation
                    break;
                case 8:
                    // TODO: View items
                    break;
                case 9:
                    // TODO: Restrict item
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
            Console.WriteLine("1.  View Logs");
            Console.WriteLine("2.  Purchase membership");
            Console.WriteLine("3.  Manage account");
            Console.WriteLine("4.  Purchase daypass");
            Console.WriteLine("5.  Cancel reservation");
            Console.WriteLine("6.  View group schedule");
            Console.WriteLine("7.  Update group schedule");
            Console.WriteLine("8.  Make reservation");
            Console.WriteLine("9.  View item");
            Console.WriteLine("10. Restrict item");
            Console.WriteLine("11. Add item");
            Console.WriteLine("12. Log out");
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