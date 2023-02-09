using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class GroupSchedule
    {
        public static List<string> TimeSlot = new List<string>()
        {
            "12:00-13:00",
            "13:00-14:00",
            "14:00-15:00"
        };
        public List<GroupActivity> Activity { get; set; }

        public static void addActivity()
        {
            Console.Clear();
            int index = 1;
            string limit = input("Whats the participant limit?\n>");

            Console.Clear();
            for (int i = 0; i < TimeSlot.Count; i++) 
            {
                Console.WriteLine(index + " " + TimeSlot[i]);
                index++;
            }
            index = 1;
            int timeSlotChoice = Convert.ToInt32(input("What time slot would you like to use?\n>"));

            Console.Clear();
            for (int i = 0; i < PersonalTrainer.personalTrainers.Count; i++)
            {
                Console.WriteLine(index + " " + PersonalTrainer.personalTrainers[i]);
                index++;
            }
            index = 1;
            int InstructorChoice = Convert.ToInt32(input("Whos the instructor for this session?\n>"));

            Console.Clear();
            for (int i = 0; i < Space.spaceList.Count; i++)
            {
                Console.WriteLine(index + " " + Space.spaceList[i].name);
                index++;
            }
            index = 1;
            int LocationChoice = Convert.ToInt32(input("Where is the location for this session?\n>"));

            Console.WriteLine("What equipment do you need for this session?");
            //TBD

            //TESTER
            GroupActivity test = new GroupActivity(null, 23, Convert.ToInt32(limit), TimeSlot[timeSlotChoice - 1], null, null);
            test.personalTrainer.Add(PersonalTrainer.personalTrainers[InstructorChoice - 1]);
            test.space.Add(Space.spaceList[LocationChoice - 1]);
            Console.WriteLine(test);
            //TESTER
        }
        static public string input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

