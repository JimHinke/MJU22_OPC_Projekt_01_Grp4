using Gym_Booking_Manager;
using System.Runtime.CompilerServices;
using static Gym_Booking_Manager.Equipment;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
	internal class Program
	{


		static void Main(string[] args)
		{
			// FUL TESTAR!	
			Equipment.equipmentList.Add(new Equipment("Test1", Equipment.EquipmentCatagory.Kettlebells ,Equipment.Availability.Available));
			Equipment.equipmentList.Add(new Equipment("Test2", Equipment.EquipmentCatagory.Kettlebells, Equipment.Availability.Available));
			Equipment.equipmentList.Add(new Equipment("Test3", Equipment.EquipmentCatagory.Kettlebells, Equipment.Availability.Available));
			Equipment.equipmentList.Add(new Equipment("Test4", Equipment.EquipmentCatagory.Kettlebells, Equipment.Availability.Available));
			Equipment.equipmentList.Add(new Equipment("Test5", Equipment.EquipmentCatagory.Kettlebells, Equipment.Availability.Available));

			Space.spaceList.Add(new Space("SpaceTest1", Space.SpaceCategory.Hall, Space.Availability.Available));
			Space.spaceList.Add(new Space("SpaceTest2", Space.SpaceCategory.Hall, Space.Availability.Unavailable));
			Space.spaceList.Add(new Space("SpaceTest3", Space.SpaceCategory.Hall, Space.Availability.Available));

			Console.WriteLine(Equipment.equipmentList);
			Equipment.equipmentList[1].SetAvailability(Availability.Service);
			Equipment.ShowAvailable();
			Console.WriteLine();
			Equipment.equipmentList[3].SetAvailability(Availability.PlannedPurchase);
			Equipment.ShowPlannedPurchase();
			Console.WriteLine();
			Equipment.ShowService();
			Console.WriteLine();
			Console.WriteLine(Space.spaceList);
			Console.WriteLine();
			Space.ShowAvailable();
			Console.WriteLine();
			Space.ShowUnavailable();
			Space.spaceList[2].SetAvailability(Space.Availability.Unavailable);
			Space.ShowUnavailable();

			//User userContext;
			while (true)
			{
				MainMenu();
			}
        }

		// Static methods for the program
		public static void MainMenu()
		{            
            Console.WriteLine("-------------Choose user:-------------");
			Console.WriteLine("1. Admin");
			Console.WriteLine("2. Staff");
			Console.WriteLine("3. Service");
			Console.WriteLine("4. NonPayingNonMember");
            Console.WriteLine("5. NonPayingDayPass");
            Console.WriteLine("6. PayingMember");
            Console.WriteLine("7. Quit");
			Console.WriteLine("--------------------------------------\n");
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
                    NonPayingNonMember.NonPayingNonMemberMenu();					
                    break;
                case 5:
                    NonPayingDayPass.NonPayingDayPassMenu();
                    break;
                case 6:
                    PayingMember.PayingMemberMenu();
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
	}
}