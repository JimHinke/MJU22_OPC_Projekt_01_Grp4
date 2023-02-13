using Gym_Booking_Manager.Interfaces;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Equipment : Resources, IReservable, ICSVable, IComparable<Equipment>, IReservingEntity
    {
        public string owner { get; set; }
        public string timeSlot { get; set; }
        public List <string> reservedTimeSlot { get; set; }
        private EquipmentType equipmentType;
        private EquipmentCategory equipmentCategory { get; set; }
        public Availability equipmentAvailability { get; set; }
        private static List<Equipment> _equipmentList = new List<Equipment>();
        public static List<Equipment> availableEquipment = new List<Equipment>();
        public static List<Equipment> equipmentList { get { return _equipmentList; } set { _equipmentList = value; } }
        public static int index = 0;


        public Equipment(string name = "", EquipmentType equipmentType = 0, EquipmentCategory equipmentCategory = 0, string timeSlot = "", Availability availability = Availability.Available, string owner = null, Calendar calendar = null) : base(name, calendar)
        {
            this.equipmentAvailability = availability;
            this.equipmentType = equipmentType;
            this.equipmentCategory = equipmentCategory;
            this.owner = owner;
            this.timeSlot = timeSlot;
            this.reservedTimeSlot = new List<string>();
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
            return $"Namn: {name}, Category: {equipmentCategory}, Avilability: {equipmentAvailability}";
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
        public static void ShowAvailable(string timeslot)
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
        public static void ReservEquipment(Equipment equipment, string timeslot,string customer)
        {
            if (equipment.equipmentAvailability == Availability.Available && !equipment.reservedTimeSlot.Contains(timeslot))
            {
                equipment.reservedTimeSlot.Add(timeslot);
                equipment.owner = customer;
            }
            else
            {
                Console.WriteLine("This Equipment is not available for reservation during that timeslot.");
            }
        }

        public static void ShowAvailableSport()
        {

            for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].equipmentAvailability == Availability.Available && equipmentList[i].equipmentType == EquipmentType.Sport)
                {
                    Console.WriteLine(i + 1 + " " + equipmentList[i].name);
                }
            }
        }
        public static void ShowAvailableLarge()
        {

            for (int i = 0; i < equipmentList.Count; i++)
            {
                if (equipmentList[i].equipmentAvailability == Availability.Available && equipmentList[i].equipmentType == EquipmentType.Large)
                {
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
                //Equipment.ShowAvailable();
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
            // Fetch
            List<Reservation> tableSlice = this.calendar.GetSlice();
            // Show?
            foreach (Reservation reservation in tableSlice)
            {
                // Do something?
            }
        }

        public void MakeReservation(string owner)
        {
            List<Equipment> temp = new List<Equipment>();
            foreach (var equipment in equipmentList)
            {
                if (equipment.equipmentAvailability == Availability.Available)
                {
                    temp.Add(equipment);
                }
            }
            if (temp.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("1. Large Equipment\n" +
                    "2. Sports Equipment");
                int equip = Convert.ToInt32(input("What kind of equipment would you like to reserve?"));

                Console.Clear();
                if (equip == 1)
                {
                    foreach (var equipment in equipmentList)
                    {
                        if (equipment.equipmentAvailability == Availability.Available && equipment.equipmentType == EquipmentType.Large)
                        {
                            temp.Add(equipment);
                        }
                    }
                    if (temp.Count != 0) { ShowAvailableLarge(); }
                    else
                    {
                        Console.WriteLine("There are no Large Equipments available");
                        Console.WriteLine("Press enter to go back");
                        Console.ReadLine();
                        User.ReserveMenu("user");
                    }

                }
                else if (equip == 2)
                {
                    foreach (var equipment in equipmentList)
                    {
                        if (equipment.equipmentAvailability == Availability.Available && equipment.equipmentType == EquipmentType.Sport)
                        {
                            temp.Add(equipment);
                        }
                    }
                    if (temp.Count != 0) { ShowAvailableSport(); }
                    else
                    {
                        Console.WriteLine("There are no Sport Equipments available");
                        Console.WriteLine("Press enter to go back");
                        Console.ReadLine();
                        User.ReserveMenu("user");
                    };
                }
                int n = Convert.ToInt32(input("What equipment would you like to reserve?\n"));

                Console.Clear();
                int index = 1;
                for (int i = 0; i < TimeSlot.Count; i++)
                {
                    Console.WriteLine(index + " " + TimeSlot[i]);
                    index++;
                }
                int timeSlot = Convert.ToInt32(input("During which time would you like to reserve the equipment?\n"));

                Console.Clear();
                string confirm = input($"You would like to reserve {temp[n - 1].name} during {TimeSlot[timeSlot - 1]}.\n" +
                    $"Is this correct? Y / N").ToLower();
                if (confirm == "y")
                {
                    temp[n - 1].owner = owner;
                    temp[n - 1].equipmentAvailability = Availability.Reserved;
                    temp[n - 1].timeSlot = TimeSlot[timeSlot - 1];
                    // Save the equipment on the owner... Does the owners hava a list with reserved equipments?
                    // Save in the Reserved list in Calendar?
                    Console.WriteLine($"You have reserved {temp[n - 1].name} during {TimeSlot[timeSlot - 1]}");
                    input("Press enter...");
                }
                else if (confirm == "n")
                {
                    User.ReserveMenu("user");
                }
            }

        }

        public void CancelReservation()
        {
            // Takes the list of the "logged in" users "Reserved items" and shows it
            // or of the person hte staff chooses.
            // the choosen item.owner = null
            // item.equipmentAailability = Availability.Available
            // the "time slot" for the item should also be made available again.
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
    }
}
