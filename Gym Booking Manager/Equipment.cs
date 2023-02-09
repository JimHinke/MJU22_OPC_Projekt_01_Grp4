using System;
using System.Collections.Generic;
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
			return $"Namn: {name}, Category: {equipmentCategory} Avilability: {equipmentAvailability}";
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
                    Console.WriteLine(equipment);
                }
            }
        }

	}
}