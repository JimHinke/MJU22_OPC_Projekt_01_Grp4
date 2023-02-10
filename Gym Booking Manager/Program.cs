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

			//Space.spaceList.Add(new Space("SpaceTest1", Space.SpaceCategory.Hall, Space.Availability.Available));
			//Space.spaceList.Add(new Space("SpaceTest2", Space.SpaceCategory.Hall, Space.Availability.Available));
			//Space.spaceList.Add(new Space("SpaceTest3", Space.SpaceCategory.Hall, Space.Availability.Available));
			

            PersonalTrainer testAvPersonalTrainer = new PersonalTrainer("Personlig Tränare");
            PersonalTrainer.personalTrainers.Add(testAvPersonalTrainer);
            Space space = new Space("Hall");
            Space.spaceList.Add(space);


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
                    Customer.NonPayingNonMemberMenu();					
                    break;
                case 5:
                    Customer.PayingMemberMenu();
                    break;
                case 6:
                    Customer.PayingMemberMenu();
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