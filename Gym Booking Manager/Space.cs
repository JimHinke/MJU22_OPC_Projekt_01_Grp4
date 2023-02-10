using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;


#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    // IComparable<T> interface requires implementing the CompareTo(T other) method.
    // This interface/method is used by for instance SortedSet<T>.Add(T) (and other sorted collections).
    // There is also the non-generic IComparable interface for a CompareTo(Object obj) implementation.
    //
    // The current database class implementation uses SortedSet, and thus classes and objects that we want to store
    // in it should inherit the IComparable<T> interface.
    //
    // As alluded to from previous paragraphs, implementing IComparable<T> is not exhaustive to cover all "comparisons".
    // Refer to official C# documentation to determine what interface to implement to allow use with
    // the class/method/operator that you want.
    internal class Space : Resources, IReservable, ICSVable, IComparable<Space>
    {
        //private static readonly List<Tuple<Category, int>> hourlyCosts = InitializeHourlyCosts(); // Costs may not be relevant for the prototype. Let's see what the time allows.
        private SpaceCategory spaceCategory;
        private Availability spaceAvailability;
		private static List<Space> _spaceList = new List<Space>();
        public static List<Space> spaceList { get { return _spaceList; } set { _spaceList = value; } }
        public static int index = 0;

        
		public Space(string name, SpaceCategory spaceCategory = 0, Availability availability = 0, Calendar calendar = null) :base(name,calendar)
        {
            this.spaceCategory = spaceCategory;
            this.spaceAvailability = availability;
        }

        // Every class T to be used for DbSet<T> needs a constructor with this parameter signature. Make sure the object is properly initialized.
        public Space(Dictionary<String, String> constructionArgs)
        {
            this.name = constructionArgs[nameof(name)];
            if (!SpaceCategory.TryParse(constructionArgs[nameof(spaceCategory)], out this.spaceCategory))
            {
                throw new ArgumentException("Couldn't parse a valid Space.Category value.", nameof(spaceCategory));
            }

            this.calendar = new Calendar();
        }

        public int CompareTo(Space? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.spaceCategory != other.spaceCategory) return this.spaceCategory.CompareTo(other.spaceCategory);
            // When category is the same, sort on name.
            return this.name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return $"Namn: {name}, Category: {spaceCategory}, Availability: {spaceAvailability}"; // TODO: Don't use CSVify. Make it more readable.
        }

        // Every class C to be used for DbSet<C> should have the ICSVable interface and the following implementation.
        public string CSVify()
        {
            return $"{nameof(spaceCategory)}:{spaceCategory.ToString()},{nameof(name)}:{name}";
        }
        public enum SpaceCategory
        {
            Hall = 1,
            Lane,
            Studio
        }
        public enum Availability
        {
            Available,
            Unavailable,
            Reserved
        }
        public Availability SetAvailability(Availability availability)
        {
            return this.spaceAvailability = availability;
        }
        public static void ShowAvailable()
        {
            spaceList = spaceList.OrderBy(x => x.spaceAvailability != Availability.Available).ToList();
            index = 0;
            for (int i = 0; i < spaceList.Count; i++)
			{
				if (spaceList[i].spaceAvailability == Availability.Available)
				{
					Console.WriteLine(i + 1 + " " + spaceList[i].name);
				}
			}
		}
        public static void ShowUnavailable()
        {
			for (int i = 0; i < spaceList.Count; i++)
			{
				if (spaceList[i].spaceAvailability == Availability.Unavailable)
				{
					Console.WriteLine(i + 1 + " " + spaceList[i].name);
				}
			}
		}

        // Perhaps a Unrestrict Space would be good?
        public static void RestrictSpace()
        {
			List<Space> temp = new List<Space>();
			foreach (var space in spaceList)
			{
				if (space.spaceAvailability == Availability.Available)
				{
					temp.Add(space);
				}
			}
			Console.Clear();
            if (temp.Count > 0)
            {
                Console.WriteLine("Choose space");
                Space.ShowAvailable();
                int n = int.Parse(Console.ReadLine());

                Console.Clear();
                spaceList[n - 1].spaceAvailability = Availability.Unavailable;
                Console.WriteLine($"{spaceList[n - 1].name} - set to {spaceList[n - 1].spaceAvailability}");
                Console.WriteLine("Press enter...");
                Console.ReadLine();
                Staff.RestrictItem();
            }
            else
            {
                Console.WriteLine("No available spaces!");
                Console.WriteLine("Press enter to go back");
                Console.ReadLine();
                Staff.RestrictItem();
            }
            
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

        //public void MakeReservation(IReservingEntity owner)
        //{
          
        //}

        public void CancelReservation()
        {

        }

        public void MakeReservation(IReservingEntity owner)
        {
            throw new NotImplementedException();
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

    }
}
