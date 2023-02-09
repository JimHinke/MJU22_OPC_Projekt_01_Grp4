using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Equipment : Resources
    {
        private EquipmentCatagory equipmentCategory;
        private Availability equipmentAvailability;
		private static List<Equipment> _equipmentList = new List<Equipment>();
        public static List<Equipment> equipmentList { get { return _equipmentList; } set { _equipmentList = value; } }

		public Equipment(string name, EquipmentCatagory equipmentCatagory, Availability availability ,Calendar calendar = null) : base(name,calendar)
        {
            this.equipmentAvailability = availability;
            this.equipmentCategory= equipmentCatagory;
        }
        public enum EquipmentCatagory
        {
            Dumbells,
            Barbells,
            Kettlebells
        }

        public enum Availability
        {
            Available,
            Service,
            PlannedPurchase
        }

        public Availability SetAvailability(Availability availability)
        {
            return this.equipmentAvailability = availability;
        }
		public override string ToString()
		{
			return $"Namn: {name}, Category: {equipmentCategory}, Avilability: {equipmentAvailability}";
		}

        public static void ShowService()
        {
			foreach (var equipment in equipmentList)
			{
				if (equipment.equipmentAvailability == Availability.Service)
				{
					Console.WriteLine(equipment);
				}
			}
		}
        public static void ShowPlannedPurchase()
        {
			foreach (var equipment in equipmentList)
			{
				if (equipment.equipmentAvailability == Availability.PlannedPurchase)
				{
					Console.WriteLine(equipment);
				}
			}
		}
        public static void ShowAvailable()
        {
            foreach (var equipment in equipmentList)
            {
                if (equipment.equipmentAvailability == Availability.Available)
                {
                    Console.WriteLine($"{equipment}");
                }
            }
        }

        public static void RepairEquipment()
        {
			// Catch when n is out of bounds
			List<Equipment> temp = new List<Equipment>();
			foreach (var equipment in equipmentList)
			{
				if (equipment.equipmentAvailability == Availability.Service)
				{
					temp.Add(equipment);
				}
			}
			if (temp.Count > 0)
			{
				Console.Clear();
				Console.WriteLine("Choose Equipment");
				Equipment.ShowService();
				int n = int.Parse(Console.ReadLine());
				temp[n - 1].SetAvailability(Availability.Available);
				Console.Clear();
				Console.WriteLine($"{temp[n - 1].name} - availability set to {temp[n - 1].equipmentAvailability}");

				Console.WriteLine("Press a button...");
				Console.ReadLine();
			}
			else 
			{ 
				Console.WriteLine("No equipment in need of service!");
				Console.WriteLine("Press enter to go back...");
				Console.ReadLine();
				Service.ServiceMenu();
			}
			

		}
		public static void RestrictEquipment()
        {
			List<Equipment> temp = new List<Equipment>();
			foreach (var equipment in equipmentList)
			{
				if (equipment.equipmentAvailability == Availability.Available)
				{
					temp.Add(equipment);
				}
			}
			Console.Clear();

			if (temp.Count > 0) 
			{ 
			Console.WriteLine("Choose equipment");
			Equipment.ShowAvailable();
			int n = int.Parse(Console.ReadLine());
	
			Console.Clear();
			Console.WriteLine("Choose restriction");
			Console.WriteLine("1. Service");
			Console.WriteLine("2. Planned Purchase");
            int res = int.Parse(Console.ReadLine());

            if (res == 1)
            {
			    temp[n-1].SetAvailability(Availability.Service);
			}
            else if (res == 2)
            {
                temp[n - 1].SetAvailability(Availability.PlannedPurchase);
			}
            else
            {
                Console.WriteLine("Not Valid");
            }
			Console.Clear();
			Console.WriteLine($"{temp[n - 1].name} - availability set to {temp[n-1].equipmentAvailability}");
			Console.WriteLine("Press enter...");
			Console.ReadLine();
			Staff.RestrictItem();
			}
			else if (temp.Count <= 0) 
			{
				Console.WriteLine("No available equipment!");
				Console.WriteLine("Press enter to go back...");
				Console.ReadKey();
				Staff.RestrictItem();
			}
		}

	}
}