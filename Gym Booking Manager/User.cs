using Gym_Booking_Manager;
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
using System.Xml;
using System.Xml.Linq;
#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class User
    {
        public int uniqueID { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public AccessLevels accessLevels { get; set; }

        public static User logedInUser = null;

        protected User(string name = "", string phone = "", string email = "", AccessLevels accessLevels = 0)
        {
            this.uniqueID = new Random().Next(0, 1000);
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.accessLevels = accessLevels;
        }

        public static List<User> userList = new List<User>();

        public override string ToString()
        {
            return "ID: " + uniqueID + " Name: " + name + " Phone: " + phone + " Email: " + email + " AccessLevel:" + accessLevels;
        }

    }

    public enum AccessLevels
    {
        PayingMember,
        NonPayingNonMember,
        Staff,
        DayPassUser,
        Service,
        Member,
        Admin
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
    internal class Service : User
    {
        public Service(string name, string phone, string email, AccessLevels accessLevels = AccessLevels.Service) : base(name, phone, email, accessLevels)
        {
            
        }
    }
    internal class Customer : User
    {
        public static List<Customer> customerList = new List<Customer>();
        public AccessLevels AccessLevel { get; set; }
        public static List<string> logs = new List<string>();
        DateTime createdAt;
        public DateTime dayPassDate { get; set; }
        public List<Resources> reservedItems { get; set; }
        public static IReservingEntity ID;
        public Customer(string name, string phone, string email, AccessLevels accessLevels = 0) : base(name, phone, email, accessLevels)
        {
            this.createdAt = DateTime.Now;
            //this.AccessLevel = accessLevel;
            customerList.Add(this);
            this.reservedItems = new List<Resources>();
            uniqueID = new Random().Next(0, 1000);
            ID = new ReservingEntity(uniqueID);
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



        public static void PayingMemberReservation()
        {
            Console.Clear();
            Menutracker.ReserveMenu(AccessLevels.PayingMember);
        }

    }
    internal class Staff : User
    {
        public Staff(string name, string phone, string email, AccessLevels accessLevels = AccessLevels.Staff) : base(name, phone, email, accessLevels)
        {
            
        }
    }
    internal class Admin : User
    {
        public Admin(string name, string phone, string email, AccessLevels accessLevels = AccessLevels.Admin) : base(name, phone, email, accessLevels)
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
    }
}
