using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;
using static System.Collections.Specialized.BitVector32;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class GroupSchedule
    {
        public static List<GroupActivity> groupScheduleList = new List<GroupActivity>();
        public static List<string> TimeSlot = new List<string>()
        {
            "12:00-13:00",
            "13:00-14:00",
            "14:00-15:00"
        };

        public static List<string> TypeOfActivity = new List<string>()
        {
            "Spinning Class",
            "Group Gym Training",
            "Yoga Class"
        };
        public List<GroupActivity> Activity { get; set; }

        public static void addActivity()
        {
            //Type Of Activity
            Console.Clear();
            int index = 1;
            for (int i = 0; i < TypeOfActivity.Count; i++)
            {
                Console.WriteLine(index + " " + TypeOfActivity[i]);
                index++;
            }
            index = 1;
            int typeOfActivityChoice = Convert.ToInt32(input("Chose Activity:\n>"));

            //Participant Limit
            Console.Clear();
            string limit = input("Whats the participant limit?\n>");

            //Time Slot
            Console.Clear();
            for (int i = 0; i < TimeSlot.Count; i++)
            {
                Console.WriteLine(index + " " + TimeSlot[i]);
                index++;
            }
            index = 1;
            int timeSlotChoice = Convert.ToInt32(input("What time slot would you like to use?\n>"));

            //Personal Trainer
            Console.Clear();
            for (int i = 0; i < PersonalTrainer.personalTrainers.Count; i++)
            {
                Console.WriteLine(index + " " + PersonalTrainer.personalTrainers[i]);
                index++;
            }
            index = 1;
            int InstructorChoice = Convert.ToInt32(input("Whos the instructor for this session?\n>"));

            //What space is used
            Console.Clear();
            for (int i = 0; i < Space.spaceList.Count; i++)
            {
                Console.WriteLine(index + " " + Space.spaceList[i].name);
                index++;
            }
            index = 1;
            int LocationChoice = Convert.ToInt32(input("Where is the location for this session?\n>"));

            //What equipment is used
            Console.WriteLine("What equipment do you need for this session?");
            Equipment.ShowAvailable();
            int equipmentChoice = Convert.ToInt32(input("What equipment do you need for this session ?\n>"));



            GroupActivity temp = new GroupActivity(
                null, //Personal Trainer
                TypeOfActivity[typeOfActivityChoice - 1], //Type Of Activity
                23, //Uniqe ID set to an random number. Is this needed?
                Convert.ToInt32(limit), //Particpant Limit
                TimeSlot[timeSlotChoice - 1], //Time Slot
                null, //List of Participants. This is not added here but rather under another menu-choice
                null, //What space is used for this session
                null //What Equipment is used for this session
                );
            temp.personalTrainer.Add(PersonalTrainer.personalTrainers[InstructorChoice - 1]);
            temp.equipment.Add(Equipment.equipmentList[equipmentChoice - 1]);
            temp.space.Add(Space.spaceList[LocationChoice - 1]);

            Console.Clear();
            Console.WriteLine(temp);
            string entryChoice = input("Do you want to make this Activity? Y/N\n>").ToLower();
            if (entryChoice == "y")
            {
                groupScheduleList.Add(temp);
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Activity is added to the Schedule");
                Console.WriteLine("---------------------------------");
            }
        }
        public static void showActivities()
        {
            foreach (var activity in groupScheduleList)
            {
                Console.WriteLine(activity);
            }
        }

        static public string input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

