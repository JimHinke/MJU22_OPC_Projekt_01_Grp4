using Gym_Booking_Manager;
using static Gym_Booking_Manager.Space;
using System;
using System.Globalization;
using System.Xml.Linq;

// There are many tools for improving how you write your tests,
// but it's good enough to keep things simple to get things started.

// You can google-search to find C# and MSTest documentation
// from https://learn.microsoft.com to find out more.

namespace Tests
{
    [TestClass]
    public class SpaceTest
    {
        [TestMethod]
        public void CreateSpace()
        {
            Space testSpace = new Space("Test Space",SpaceCategory.Lane, Availability.Available, null, "12:00");
            Assert.IsNotNull(testSpace);
        }

        [TestMethod]
        public void CreateSpaceFromDictionaryBadCategoryException()
        {
            bool threw = false;
            var constructionArgs = new Dictionary<String, String>()
                {
                    { "category", "Sudio" },
                    { "name", "Dance Studio" }
                };

            try
            {
                Space studioSpace = new Space(
                    name: constructionArgs["name"],
                    spaceCategory: (SpaceCategory)Enum.Parse(typeof(SpaceCategory), constructionArgs["category"]),
                    availability: 0,
                    owner: null,
                    timeSlot: "",
                    calendar: null);
            }
            catch (Exception e)
            {
                threw = true;
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
                Assert.AreEqual("Invalid space category: Sudio", e.Message);
            }

            Assert.IsTrue(threw);
        }

        [TestMethod]
        public void SpaceToString()
        {
            Space testSpace = new Space("Test Space", SpaceCategory.Lane, Availability.Available, null, "12:00");
            Assert.AreEqual(testSpace.ToString(), "Namn: Test Space, Category: Lane, Availability: Available"); // Fix this
        }

        [TestMethod]
        public void SpaceCSVify()
        {
            Space testSpace = new Space("Test Space", SpaceCategory.Lane, Availability.Available, null, "12:00");
            Assert.AreEqual(testSpace.CSVify(), "spaceCategory:Lane,name:Test Space,spaceAvailability:Available");
        }

        [TestMethod]
        public void SpaceCompareToSpace()
        {
            SortedSet<Space> sortedSpaces = new SortedSet<Space>();
            Space testStudio = new Space("Test Studio", SpaceCategory.Studio);
            Space testHall = new Space("Test Hall", SpaceCategory.Hall);

            sortedSpaces.Add(testStudio);
            sortedSpaces.Add(testHall);

            var spaceEnumerator = sortedSpaces.GetEnumerator();

            spaceEnumerator.MoveNext();
            Assert.AreEqual("Test Hall", spaceEnumerator.Current.name);
            spaceEnumerator.MoveNext();
            Assert.AreEqual("Test Studio", spaceEnumerator.Current.name);
        }


    }
}