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
    internal class GroupSchedule : Resources
    {
        public static List<GroupActivity> groupScheduleList = new List<GroupActivity>();

        public static List<string> TypeOfActivity = new List<string>()
        {
            "Spinning Class",
            "Group Gym Training",
            "Yoga Class"
        };
        public static List<string> TimeSlot = new List<string>()
        {
            "12:00-13:00",
            "13:00-14:00",
            "14:00-15:00"
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
            int timeSlotChoice = Convert.ToInt32(input("What time slot would you like to use?\n>"));

            //Personal Trainer

            Console.Clear();
            List<PersonalTrainer> personalTrainerList = new List<PersonalTrainer>();
            while (true)
            {
                PersonalTrainer.ShowAvailable(TimeSlot[timeSlotChoice - 1]);
                int InstructorChoice = Convert.ToInt32(input("Who is the instructor for this session? To go to next section press '0'\n>"));
                if (InstructorChoice > 0 && InstructorChoice <= PersonalTrainer.index)
                {
                    PersonalTrainer.ReservTrainer(PersonalTrainer.personalTrainers[InstructorChoice - 1], TimeSlot[timeSlotChoice - 1], TypeOfActivity[typeOfActivityChoice - 1]);
                    personalTrainerList.Add(PersonalTrainer.personalTrainers[InstructorChoice - 1]);

                }
                else if (InstructorChoice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid personal trainer. Try again.");
                }
            }
            Console.Clear();

            Space.ShowAvailable();
            int LocationChoice = Convert.ToInt32(input("Where is the location for this session?\n>"));

            List<Equipment> activityEquipmentList = new List<Equipment>();
            int equipmentChoice = 0;
            while (true)
            {
                Equipment.ShowAvailable(TimeSlot[timeSlotChoice - 1]);
                equipmentChoice = Convert.ToInt32(input("What equipment do you need for this session ? To go to next section press '0'\n>"));


                if (equipmentChoice > 0 && equipmentChoice <= Equipment.index)
                {
                    Equipment.ReservEquipment(Equipment.equipmentList[equipmentChoice - 1], TimeSlot[timeSlotChoice - 1], TypeOfActivity[typeOfActivityChoice - 1]);
                    activityEquipmentList.Add(Equipment.equipmentList[equipmentChoice - 1]);
                }
                else if (equipmentChoice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid equipment. Try again.");
                }
            }


            GroupActivity temp = new GroupActivity(
                            personalTrainerList, //Personal Trainer
                            TypeOfActivity[typeOfActivityChoice - 1], //Type Of Activity
                            23, //Unique ID set to an random number. Is this needed?
                            Convert.ToInt32(limit), //Particpant Limit
                            TimeSlot[timeSlotChoice - 1], //Time Slot
                            null, //List of Participants. This is not added here but rather under another menu-choice
                            Space.spaceList[LocationChoice - 1], //What space is used for this session
                            activityEquipmentList //What Equipment is used for this session
                            );
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
            else if (entryChoice == "n")
            {
                foreach (var equipment in activityEquipmentList)
                {
                    equipment.reservedTimeSlot.Clear();
                }
                foreach (var PT in personalTrainerList)
                {
                    PT.reservedTimeSlot.Clear();
                }
            }
        }

        public static void addCustomerToActivity(User customer, GroupActivity groupActivity)
        {

            if (groupActivity.participants.Count < groupActivity.participantLimit)
            {
                groupActivity.participants.Add(customer);
                Console.WriteLine($"Added '{customer.name}' to the activity");
            }
            else
            {
                Console.WriteLine("\n### There is no spots available in this session!###\n");
            }

        }
        public static void showActivities()
        {
            foreach (var activity in groupScheduleList)
            {
                Console.WriteLine(activity);
            }
        }
        public static void editActivity()
        {
            showActivities();
            string editActivityChoice = input("Whats activity do you want to edit?\n>");
            for (int i = 0; i < groupScheduleList.Count; i++)
            {
                if (editActivityChoice.ToLower() == groupScheduleList[i].typeOfActivity.ToLower())
                {
                    Console.WriteLine("1: <Name> - Name of this Activity");
                    Console.WriteLine("2: <ActivityId> - The uniq ID for this Activity");
                    Console.WriteLine("3: <Particpanat Limit> - The number of participants for this Activity");
                    Console.WriteLine("4: <Time Slot> - The timeslot for this Activity (NOT AVAILABLE AT THIS MOMENT");
                    Console.WriteLine("5: <Remove Participants> - Remove a participant for this Activity");
                    Console.WriteLine("6: <Change Space> - Change the alocated space for this Activity");
                    Console.WriteLine("7: <Change Equipment> - Change the equipment alocated for this Activity");
                    Console.WriteLine("8: <Go Back> - Go back");

                    int command = int.Parse(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            string newName = input("Whats the new name for this Activity?\n>");
                            groupScheduleList[i].typeOfActivity = newName;
                            break;
                        case 2:
                            int newID = Convert.ToInt32(input("Whats the new uniqID for this Activity?\n>"));
                            groupScheduleList[i].activtyId = newID;
                            break;
                        case 3:
                            int newParticipantLimit = Convert.ToInt32(input("Whats the new participant limit?\n>"));
                            groupScheduleList[i].participantLimit = newParticipantLimit;
                            break;
                        case 4:
                            Console.WriteLine("Unavailable at this moment");
                            break;
                        case 5:
                            List<User> participants = groupScheduleList[i].participants;
                            foreach (User participant in participants)
                            {
                                Console.WriteLine(participant.name);
                            }
                            string removeParticipant = input("What participant do you want to remove? (Full name)\n>");
                            for (int j = 0; j < participants.Count; j++)
                            {
                                if (participants[i].name == removeParticipant)
                                {
                                    participants.RemoveAt(j);
                                    Console.WriteLine($"Removed {removeParticipant} from this Activity");
                                    break;
                                }
                            }
                            break;
                        case 6:
                            Space.ShowAvailable();
                            string changeSpace = input($"What space would you like to add instead of '{groupScheduleList[i].space.name}'?\n>");
                            
                                
                            break;
                        case 7:
                            break;
                        case 8:
                            User.manageSchedule();
                            break;
                        default:
                            Console.WriteLine("Invalid input, type a number");
                            break;
                    }
                }
            }
        }
        public static void deleteActivity()
        {
            //TODO
        }

        static public string input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

