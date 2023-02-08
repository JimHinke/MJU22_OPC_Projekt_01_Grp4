using Gym_Booking_Manager;
using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				MainMenu();
			}
			
		}

		// Static methods for the program
		public static void MainMenu()
		{
			Console.WriteLine("Choose user:");
			
			Console.WriteLine("1. Admin");
			Console.WriteLine("2. Staff");
			Console.WriteLine("3. Service");
			Console.WriteLine("4. Customer");
			Console.WriteLine("5. Quit");
			int command = int.Parse(Console.ReadLine());

			// TODO: Exception for chars != int

			switch (command)
			{
				case 1:
					AdminMenu();
					break;
				case 2:
					StaffMenu();
					break;
				case 3:
					ServiceMenu();
					break;
				case 4:
					CustomerMenu();
					break;
				case 5:
					Console.WriteLine("Exiting program...");
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Invalid input, type a number");
					break;

			}
		}
		public static void AdminMenu()
		{
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
			Console.WriteLine("---------------------------------");
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
					MainMenu();
					break;
				default:
					Console.WriteLine("Invalid input, type a number");
					break;
			}
		}
		public static void StaffMenu()
		{
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
			Console.WriteLine("---------------------------------");
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
					MainMenu();
					break;
				default:
					Console.WriteLine("Invalid input, type a number");
					break;
			}
		}
		public static void CustomerMenu()
		{
			Console.WriteLine("-------------Customer-------------");
			Console.WriteLine("1. Purchase Membership");
			Console.WriteLine("2. Manage Account (own only)");
			Console.WriteLine("3. Purchase Day Pass");
			Console.WriteLine("4. Cancel Reservation");
			Console.WriteLine("5. View Group Schedule");
			Console.WriteLine("6. Make Reservation");
			Console.WriteLine("7. View Item");
			Console.WriteLine("8. Log out");
			Console.WriteLine("----------------------------------");
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
					MainMenu();
					break; 
				default:
					Console.WriteLine("Invalid input, type a number");
					break;
			}
		}
		public static void ServiceMenu ()
		{
			Console.WriteLine("--------------Service-------------");
			Console.WriteLine("1. Item Repair");
			Console.WriteLine("2. Log out");
			Console.WriteLine("----------------------------------");
			int command = int.Parse(Console.ReadLine());

			switch (command)
			{
				case 1:
					// TODO: Item Repair
					break;
				case 2:
					MainMenu();
					break;
				default:
					Console.WriteLine("Invalid input, type a number");
					break;
			}
		}
	}
}