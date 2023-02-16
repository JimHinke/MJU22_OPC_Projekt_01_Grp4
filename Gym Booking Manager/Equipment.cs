using Gym_Booking_Manager.Interfaces;
using System.Reflection.Metadata.Ecma335;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Equipment : Resources, IReservable, ICSVable, IComparable<Equipment>
    {

        public string timeSlot { get; set; } //Hur fungerar detta i Julias kod? Kan man utgå från reservedTimeSlot istället? Känns dubbelt med info?
        public List <string> reservedTimeSlot { get; set; }
        private EquipmentType equipmentType;
        public EquipmentCategory equipmentCategory { get; set; }
        public Availability equipmentAvailability { get; set; }
        //private static List<Equipment> _equipmentList = new List<Equipment>();
        //public static List<Equipment> availableEquipment = new List<Equipment>();
        //public static List<Equipment> equipmentList { get { return _equipmentList; } set { _equipmentList = value; } }
        public static int index = 0;
		public static List<string> TimeSlot = new List<string>()
		{
			"12:00-13:00",
			"13:00-14:00",
			"14:00-15:00"
		};
		public Equipment(string name = "", EquipmentType equipmentType = 0, EquipmentCategory equipmentCategory = 0, Availability availability = Availability.Available, string timeSlot = "",IReservingEntity owner = null) : base(name, TimeSlot, "" ,owner = null)
        {
            this.equipmentAvailability = availability;
            this.equipmentType = equipmentType;
            this.equipmentCategory = equipmentCategory;
			this.timeSlot = timeSlot;
			this.reservedTimeSlot = new List<string>();
			this.owner = owner;
		}
        public enum EquipmentType
        {
            Large,
            Sport
        }

        public enum EquipmentCategory
        {
            Treadmill, TennisRacket, RowingMachine
        }

        public enum Availability
        {
            Available,
            Service,
            PlannedPurchase,
            Reserved
        }
        public Availability SetAvailability(Availability availability)
        {
            return this.equipmentAvailability = availability;
        }
        public override string ToString()
        {
            return $"Namn: {name}, Category: {equipmentCategory}, Availability: {equipmentAvailability}";
        }

        public static void ShowService()
        {
            for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].equipmentAvailability == Availability.Service)
                {
                    Console.WriteLine(i + 1 + " " + equipmentList[i].name);
                }
            }
        }
        public static void ShowPlannedPurchase()
        {
            for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].equipmentAvailability == Availability.PlannedPurchase)
                {
                    Console.WriteLine(i + 1 + " " + equipmentList[i].name);
                }
            }
        }
        public static void ShowAvailable(string timeslot = null)
        { 
            equipmentList = equipmentList.OrderBy(x => x.equipmentAvailability != Availability.Available).ToList();
            equipmentList = equipmentList.OrderBy(x => x.reservedTimeSlot.Contains(timeslot)).ToList();
            index = 0;
            for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].equipmentAvailability == Availability.Available && !equipmentList[i].reservedTimeSlot.Contains(timeslot))
                {
                    index++;
                    Console.WriteLine(i + 1 + " " + equipmentList[i].name);
                }
            }
        }
        public static void ReservEquipment(Equipment equipment, string timeslot, string owner)
        {
            if (equipment.equipmentAvailability == Availability.Available && !equipment.reservedTimeSlot.Contains(timeslot))
            {
                equipment.reservedTimeSlot.Add(timeslot);
                IReservingEntity activity  = new ReservingEntity(owner);
                equipment.owner = activity;

            }
            else
            {
                Console.WriteLine("This Equipment is not available for reservation during that timeslot.");
            }
        }

        public static void ShowAvailableSport(string timeSlot = null)
        {
			equipmentList = equipmentList.OrderBy(x => x.equipmentAvailability != Availability.Available).ToList();
			equipmentList = equipmentList.OrderBy(x => x.reservedTimeSlot.Contains(timeSlot)).ToList();
			equipmentList = equipmentList.OrderBy(x => x.equipmentType != EquipmentType.Sport).ToList();
			index = 0;
			for (int i = 0; i < equipmentList.Count; i++)
			{
				if (equipmentList[i].equipmentAvailability == Availability.Available && equipmentList[i].equipmentType == EquipmentType.Sport && !equipmentList[i].reservedTimeSlot.Contains(timeSlot))
				{
					index++;
					Console.WriteLine(i + 1 + " " + equipmentList[i].name);
				}
			}
        }
        public static void ShowAvailableLarge(string timeSlot = null)
        {
			equipmentList = equipmentList.OrderBy(x => x.equipmentAvailability != Availability.Available).ToList();
			equipmentList = equipmentList.OrderBy(x => x.reservedTimeSlot.Contains(timeSlot)).ToList();
			equipmentList = equipmentList.OrderBy(x => x.equipmentType != EquipmentType.Large).ToList();
			for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].equipmentAvailability == Availability.Available && equipmentList[i].equipmentType == EquipmentType.Large && !equipmentList[i].reservedTimeSlot.Contains(timeSlot))
                {
					index++;
					Console.WriteLine(i + 1 + " " + equipmentList[i].name);
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
                return;
            }
            else
            {
                Console.WriteLine("No equipment in need of service!");
                Console.WriteLine("Press enter to go back...");
                Console.ReadLine();
                return;
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
                    temp[n - 1].SetAvailability(Availability.Service);
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
                Console.WriteLine($"{temp[n - 1].name} - availability set to {temp[n - 1].equipmentAvailability}");
                Console.WriteLine("Press enter...");
                Console.ReadLine();
                Menutracker.RestrictItem();
            }
            else if (temp.Count <= 0)
            {
                Console.WriteLine("No available equipment!");
                Console.WriteLine("Press enter to go back...");
                Console.ReadKey();
                Menutracker.RestrictItem();
            }
        }
        public int CompareTo(Equipment? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            if (this.equipmentCategory != other.equipmentCategory) return this.equipmentCategory.CompareTo(other.equipmentCategory);
            return this.name.CompareTo(other.name);
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        public string CSVify()
        {
            return $"{nameof(equipmentCategory)}:{equipmentCategory.ToString()},{nameof(name)}:{name}";
        }

        public void ViewTimeTable()
        {
            //// Fetch
            //List<Reservation> tableSlice = this.calendar.GetSlice();
            //// Show?
            //foreach (Reservation reservation in tableSlice)
            //{
            //    // Do something?
            //}
        }

        public void MakeReservation(IReservingEntity owner, User customer, AccessLevels accessLevel)
        {
			Console.Clear();
			int index = 1;
			for (int i = 0; i < TimeSlot.Count; i++)
			{
				Console.WriteLine(index + " " + TimeSlot[i]);
				index++;
			}
            int timeSlotChoice = Convert.ToInt32(input("During which time would you like to reserve the equipment?\n"));

			List<Equipment> tempAll = new List<Equipment>();

			for (int i = 0; i < equipmentList.Count; i++)
			{
				if (equipmentList[i].equipmentAvailability == Availability.Available && !equipmentList[i].reservedTimeSlot.Contains(TimeSlot[timeSlotChoice-1]))
				{
                    tempAll.Add(equipmentList[i]);
				}
			}
			if (tempAll.Count > 0)
            {    
                int equip = 0;
                if (accessLevel == AccessLevels.NonPayingNonMember)
                {
                    equip = 2;
				}
                else
                {
                    Console.Clear();
                    Console.WriteLine("1. Large Equipment\n" +
                        "2. Sports Equipment");
                    equip = Convert.ToInt32(input("What kind of equipment would you like to reserve?\n"));

                }
                Console.Clear();
                int n = 0;
                string confirm = "";
				List<Equipment> temp = new List<Equipment>();
				if (equip == 1)
                {
                    foreach (var equipment in tempAll)
                    {
                        if (equipment.equipmentType == EquipmentType.Large)
                        {
                            temp.Add(equipment);
                        }
                    }
                    if (temp.Count != 0) 
                    {
                        ShowAvailableLarge(TimeSlot[timeSlotChoice -1]);				 
                    }
                    else
                    {
                        Console.WriteLine("There are no Large Equipments available");
                        Console.WriteLine("Press enter to go back");
                        Console.ReadLine();
                        return;
                    }
				}
                else if (equip == 2)
                {
					foreach (var equipment in tempAll)
					{
						if (equipment.equipmentType == EquipmentType.Sport)
						{
							temp.Add(equipment);
						}
					}
					if (temp.Count != 0) 
                    { 
                        ShowAvailableSport(TimeSlot[timeSlotChoice - 1]); 
                    }
					else
					{
						Console.WriteLine("There are no Sport Equipments available");
						Console.WriteLine("Press enter to go back");
						Console.ReadLine();
                        return;
					};
				}
				n = Convert.ToInt32(input("What equipment would you like to reserve?\n"));
                Console.Clear();
                confirm = input($"You would like to reserve {temp[n - 1].name} during {TimeSlot[timeSlotChoice - 1]}.\n" +
                    $"Is this correct? Y / N\n").ToLower();
                Console.Clear();
				
                if (confirm == "y")
                {

                    // TBD: Somthing is not quite right in the saving...
                    temp[n - 1].owner = owner;
                    temp[n - 1].reservedTimeSlot.Add(TimeSlot[timeSlotChoice - 1]);
					temp[n - 1].timeSlot = TimeSlot[timeSlotChoice - 1];
                     
					customer.reservedItems.Add(new Equipment(temp[n - 1].name, temp[n-1].equipmentType , temp[n-1].equipmentCategory, 0,temp[n-1].timeSlot, temp[n-1].owner));
					
					// TBD? Save in the Reserved list in Calendar?
					Console.WriteLine($"You have reserved {temp[n - 1].name} during {TimeSlot[timeSlotChoice - 1]}");

                    input("Press enter...");
                    Console.Clear();
                    return;
                }
                else if (confirm == "n")
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("There is no available equipment during your choosen time.");
                return;
			}
        }

        

        // Consider how and when to add a new Space to the database.
        // Maybe define a method to persist it? Any other reasonable schemes?

        //private static List<Tuple<Category, int>> InitializeHourlyCosts()
        //{
        //    // TODO: fetch from "database"
        //    var hourlyCosts = new List<Tuple<Category, int>>
        //    {
        //        Tuple.Create(Category.Hall, 500),
        //        Tuple.Create(Category.Lane, 100),
        //        Tuple.Create(Category.Studio, 400)
        //    };
        //    return hourlyCosts;
        //}

        static public string input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static Equipment FindByName(List<Equipment> equipmentList, string name)
        {
            // Look for an existing Equipment object with the same name
            var existingEquipment = equipmentList.FirstOrDefault(e => e.name == name);

            // If an existing equipment was found, return it
            if (existingEquipment != null)
            {
                return existingEquipment;
            }
            
            // If not, return null
            return null;
        }
    }
}
