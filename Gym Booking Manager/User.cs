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
        public static User logedInUser { get; set; } = null;
        public ReservingEntity ID { get; set; }
		public List<Resources> reservedItems { get; set; }
		public static List<Customer> userList { get; set; } = new List<Customer>();
		protected User(string name = "", string phone = "", string email = "", AccessLevels accessLevels = 0)
        {
            this.uniqueID = new Random().Next(0, 1000);
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.accessLevels = accessLevels;
			ID = new ReservingEntity(uniqueID);
		}
        
        public override string ToString()
        {
            return "ID: " + uniqueID + "\nName: " + name + "\nPhone: " + phone + "\nEmail: " + email + "\nAccessLevel: " + accessLevels;
        }
		static public string input(string prompt)
		{
			Console.Write(prompt);
			return Console.ReadLine();
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
        public AccessLevels AccessLevel { get; set; }

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
        private static List<Customer> _customerList = new List<Customer>();
		public static List<Customer> customerList { get { return _customerList; } set { _customerList = value; } }
        DateTime createdAt;
        public DateTime dayPassDate { get; set; }
		public Customer(string name, string phone, string email, AccessLevels accessLevels = 0) : base(name, phone, email, accessLevels)
        {
            this.createdAt = DateTime.Now;
            //this.AccessLevel = accessLevel;
            customerList.Add(this);
            this.reservedItems = new List<Resources>();
            uniqueID = new Random().Next(0, 1000);
        }
		public static void ViewReservedItemList(User customer)
		{
			var reservedItemsList = customer.reservedItems
				.OrderBy(x => x.GetType() == typeof(Equipment) ? 0 :
							  x.GetType() == typeof(Space) ? 1 :
							  x.GetType() == typeof(PersonalTrainer) ? 2 :
							  3)
				.ToList();

			for (int i = 0; i < reservedItemsList.Count; i++)
			{
				if (reservedItemsList[i] is Equipment equipment)
				{
					Console.WriteLine($"{i + 1}. {equipment.name}, {equipment.equipmentCategory}, {equipment.timeslot}");
				}
				else if (reservedItemsList[i] is Space space)
				{
					Console.WriteLine($"{i + 1}. {space.name}, {space.spaceCategory}, {space.timeslot}");
				}
				else if (reservedItemsList[i] is PersonalTrainer trainer)
				{
					Console.WriteLine($"{i + 1}. {trainer.name}, {trainer.trainerCategory}, {trainer.timeslot}");
				}
			}
		}

		// Cancel reservation | Not quite functional, removes item from customer but not customer from item.
		// Probably due to problem i saving in MakeReservation()
		public static void CancelReservation(IReservingEntity owner, User customer, AccessLevels accessLevels)
		{
			if (customer.reservedItems.Count > 0)
			{
				while (customer.reservedItems.Count > 0)
				{
					Console.Clear();
					Customer.ViewReservedItemList(customer);
					string userInput = input("What reservation would you like to cancel?\n" +
						"Or press 'Q' to go back\n");

					if (userInput.ToUpper() == "Q")
					{
						return;
					}
					int i = int.Parse(userInput);
					int x = 0;
					string confirm = "";
					Console.Clear();
					if (customer.reservedItems[i - 1] is Equipment equipment)
					{
						confirm = input($"You want to cancel your reservation of {equipment.name} at {equipment.timeslot}\n" +
							$"Is this correct? Y / N\n").ToLower();

						if (confirm == "y")
						{
							foreach (Equipment equip in Equipment.equipmentList)
							{
								if (equip.name == equipment.name && equip.owner == equipment.owner && equip.reservedTimeSlot.Contains(equipment.timeslot))
								{
									equip.reservedTimeSlot.Remove(equipment.timeslot);
									equip.owner = null;
									equip.timeslot = "";
									customer.reservedItems.Remove(equipment);
								}
								else
								{
									Console.WriteLine("Something is wrong");
									Console.ReadLine();
								}
							}
							Console.WriteLine($"You have canceled your reservation of {equipment.name} at {equipment.timeslot}");
							input("Press enter...");
							return;
						}
						else
						{
							return;
						}
					}
					else if (customer.reservedItems[i - 1] is Space space)
					{
						confirm = input($"You want to cancel your reservation of {space.name} at {space.timeslot}\n" +
							$"Is this correct? Y / N\n").ToLower();

						if (confirm == "y")
						{
							foreach (Space OSpace in Space.spaceList)
							{
								if (OSpace.name == space.name && OSpace.owner == space.owner && OSpace.reservedTimeSlot.Contains(space.timeslot))
								{
									OSpace.reservedTimeSlot.Remove(space.timeslot);
									OSpace.owner = null;
									OSpace.timeslot = "";
								}
							}
							customer.reservedItems.Remove(space);
							Console.WriteLine($"You have canceled your reservation of {space.name} at {space.timeslot}");
							input("Press enter...");
							return;
						}
						else
						{
							return;
						}
					}
					else if (customer.reservedItems[i - 1] is PersonalTrainer personalTrainer)
					{
						confirm = input($"You want to cancel your reservation of {personalTrainer.name} at {personalTrainer.timeslot}\n" +
							$"Is this correct? Y / N\n").ToLower();

						if (confirm == "y")
						{
							foreach (PersonalTrainer PT in PersonalTrainer.personalTrainers)
							{
								if (PT.name == personalTrainer.name && PT.owner == personalTrainer.owner && PT.reservedTimeSlot.Contains(personalTrainer.timeslot))
								{
									PT.reservedTimeSlot.Remove(personalTrainer.timeslot);
									PT.owner = null;
									PT.timeslot = "";
								}
							}
							customer.reservedItems.Remove(personalTrainer);
							Console.WriteLine($"You have canceled your reservation of {personalTrainer.name} at {personalTrainer.timeslot}");
							input("Press enter...");
							return;
						}
						else
						{
							return;
						}
					}
					Console.Clear();
				}
			}
			else
			{
				Console.WriteLine("There are no reserved items.\n" +
					"Press enter to continue!");
				Console.ReadLine();
				Console.Clear();
			}
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
    }
}
