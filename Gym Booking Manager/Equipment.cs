using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Equipment : Resources
    {
        private EquipmentCatagory equipmentCategory;
        private Availability availability;
		// Temp for testing NOTE: Too tired to battle with private atm
		public static List<Equipment> equipmentList = new List<Equipment>();	

		public Equipment(string name, Availability availability ,Calendar calendar = null) : base(name,calendar)
        {
            this.availability = availability;
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
            return this.availability = availability;
        }
		public override string ToString()
		{
			return $"{name}, {availability}";
		}

        public static void ShowService()
        {
			foreach (var equipment in equipmentList)
			{
				if (equipment.availability == Availability.Service)
				{
					Console.WriteLine(equipment);
				}
			}
		}

        public static void ShowPlannedPurchase()
        {
			foreach (var equipment in equipmentList)
			{
				if (equipment.availability == Availability.PlannedPurchase)
				{
					Console.WriteLine(equipment);
				}
			}
		}

        public static void ShowAvailable()
        {
            int index = 1;
            //foreach (var equipment in equipmentList)
            //{
            //    if (equipment.availability == Availability.Available)
            //    {
            //        Console.WriteLine(equipment);
            //    }
            //}
            for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].availability == Availability.Available)
                {
                    Console.WriteLine(index + " " + equipmentList[i].name);
                    index++;
                }
            }
        }

	}
}