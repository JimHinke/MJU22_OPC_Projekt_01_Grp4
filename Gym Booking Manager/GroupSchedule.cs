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

        //--Metod för att skapa en ny groupActivity
        public static void addActivity()
        {
            //--TYPE OF ACTIVITY
            Console.Clear();
            int index = 1;
            for (int i = 0; i < TypeOfActivity.Count; i++)
            {
                Console.WriteLine(index + " " + TypeOfActivity[i]);
                index++;
            }
            index = 1;
            int typeOfActivityChoice = Convert.ToInt32(input("Chose Activity:\n>"));

            //--PARTICIPANT LIMIT
            Console.Clear();
            string limit = input("Whats the participant limit?\n>");

            //--TIMESLOT
            Console.Clear();
            for (int i = 0; i < TimeSlot.Count; i++)
            {
                Console.WriteLine(index + " " + TimeSlot[i]);
                index++;
            }
            int timeSlotChoice = Convert.ToInt32(input("What time slot would you like to use?\n>"));

            //--PERSONAL TRAINER

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

            //--SPACE
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
                            new Random().Next(0, 1000), //Unique ID set to an random number. Is this needed?
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
            else if (entryChoice == "n") //--CLEARAR ALLA VAL VID "N"
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

        //--Metod för att lägga till en user/customer i en groupActivity
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
        //--Metod för att visa alla groupActivites i groupScheduleList
        public static void showActivities()
        {
            //Console.Clear();
            foreach (var activity in groupScheduleList)
            {
                Console.WriteLine(activity);
            }
        }
        //--Metod för att editera befintliga groupActivites
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
                    Console.WriteLine("4: <Time Slot> - Change the timeslot for this Activity (NOT AVAILABLE AT THIS MOMENT");
                    Console.WriteLine("5: <Remove Participants> - Remove a participant for this Activity");
                    Console.WriteLine("6: <Change Space> - Change the alocated space for this Activity");
                    Console.WriteLine("7: <Remove Equipment> - Remove equipments from this Activity");
                    Console.WriteLine("8: <Add Equipment> - Add equipment to this Activity");
                    Console.WriteLine("9: <Go Back> - Go back");

                    int command = int.Parse(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            //--Ändradet av "namnet" (typeOfActivity) 
                            string newName = input("Whats the new name for this Activity?\n>");
                            groupScheduleList[i].typeOfActivity = newName;
                            Console.WriteLine($"The new name for this activity is: {newName}");
                            break;
                        case 2:
                            //--Ändrandet av uniqID
                            int newID = Convert.ToInt32(input("Whats the new uniqID for this Activity?\n>"));
                            groupScheduleList[i].activtyId = newID;
                            Console.WriteLine($"The new uniqID for this activity is: {newID}");
                            break;
                        case 3:
                            //--Ändra participant limit
                            int newParticipantLimit = Convert.ToInt32(input("Whats the new participant limit?\n>"));
                            groupScheduleList[i].participantLimit = newParticipantLimit;
                            Console.WriteLine($"The new participation limit is: {newParticipantLimit}");
                            break;
                        case 4:
                            //--TBD Då denna påverkar Spaces,Equipment och PersonalTrainers så är denna satt som TBD
                            Console.WriteLine("Unavailable at this moment");
                            break;
                        case 5:
                            //--Ta port en perticipant från groupActivity
                            List<User> participants = groupScheduleList[i].participants;
                            foreach (User participant in participants)
                            {
                                Console.WriteLine(participant.name);
                            }
                            string removeParticipant = input("What participant do you want to remove? (Full name)\n>");
                            for (int j = 0; j < participants.Count; j++)
                            {
                                if (participants[j].name == removeParticipant)
                                {
                                    participants.RemoveAt(j);
                                    Console.WriteLine($"Removed {removeParticipant} from this Activity");
                                    break;
                                }
                            }
                            break;
                        case 6:
                            //--Ändra Space i groupActivity till en annan space
                            Space.ShowAvailable();
                            int changeSpace = Convert.ToInt32(input($"What space would you like to add instead of '{groupScheduleList[i].space.name}'?\n>"));
                            groupScheduleList[i].space = Space.spaceList[changeSpace-1];
                            Console.WriteLine($"Changed to location to {Space.spaceList[changeSpace-1].name}");
                            break;
                        case 7:
                            //--Tar bort Equipment från groupActivity. Körs enbart en gång så man får gå in i denna menyn igen om man vill ta bort flera
                            List<Equipment> equipmentAcitivy = groupScheduleList[i].equipment;
                            foreach (Equipment equipment in equipmentAcitivy)
                            {
                                Console.WriteLine(equipment.name);
                            }
                            string removeEquipment = input("What equipment do you want to remove? (Full name)\n>");
                            for (int y = 0; y< equipmentAcitivy.Count; y++)
                            {
                                if (equipmentAcitivy[y].name.ToLower() == removeEquipment.ToLower())
                                {
                                    equipmentAcitivy.RemoveAt(y);
                                    Console.WriteLine($"Removed {removeEquipment} from this Activity");
                                    //equipmentAcitivy[y].reservedTimeSlot.Remove(groupScheduleList[i].timeSlot);
                                    for (int x = 0; x < equipmentAcitivy.Count; x++)
                                    {
                                        if (equipmentAcitivy[x].reservedTimeSlot.Contains(groupScheduleList[i].timeSlot))
                                        {
                                            equipmentAcitivy[x].reservedTimeSlot.RemoveAt(x);
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        case 8:
                            //--Lägg till ETT equipment i groupActivity. Samma princip som att ta bort equipment
                            Equipment.ShowAvailable(groupScheduleList[i].timeSlot);
                            int addEquipment = Convert.ToInt32(input("What equipment do you want to add?"));
                            groupScheduleList[i].equipment.Add(Equipment.equipmentList[addEquipment - 1]);
                            Equipment.ReservEquipment(Equipment.equipmentList[addEquipment - 1], groupScheduleList[i].timeSlot, groupScheduleList[i].typeOfActivity);
                            break;
                        default:
                            Console.WriteLine("Invalid input, type a number");
                            break;
                    }
                }
            }
        }
        //--Metod för att ta bort groupActivity
        public static void deleteActivity()
        {
            showActivities();
            string editActivityChoice = input("Whats activity do you want to delete?\n>");
            for (int i = 0; i < groupScheduleList.Count; i++)
            {
                if (groupScheduleList[i].typeOfActivity.ToLower() == editActivityChoice.ToLower())
                {
                    groupScheduleList.RemoveAt(i);
                    Console.WriteLine($"Removed: '{editActivityChoice}' from the Group Schedule");
                }
            }
        }

        //--Refaktorerad input prompt
        static public string input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

