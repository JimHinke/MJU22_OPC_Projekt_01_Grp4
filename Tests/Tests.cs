using Gym_Booking_Manager;
using static Gym_Booking_Manager.GroupActivity;
using static Gym_Booking_Manager.GroupSchedule;
using System;
using System.Globalization;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace Gym_Booking_Manager.UnitTests
{
    [TestClass]
    public class GroupActivityTests
    {
        [TestMethod]
        public void GroupActivity_ToString_ReturnsExpectedString()
        {
            var activity = new GroupActivity(
                new List<PersonalTrainer>()
                {
                    new PersonalTrainer("John")
                },
                "Pilates",
                1,
                10,
                "10:00 - 11:00",
                new List<Customer>()
                {
                    new Customer("Alice","123","alice@test", AccessLevels.PayingMember),
                    new Customer("Bob","999", "bob@test", AccessLevels.DayPassUser)
                },
                new Space("Room 1"),
                new List<Equipment>()
                {
                    new Equipment("Yoga mat"),
                    new Equipment("Resistance bands")
                });

            var result = activity.ToString();

            Assert.AreEqual("---------------------------------------------\n" +
                "Type Of Activity: Pilates\n" +
                "Activity ID: 1\n" +
                "Perticipant Limit: 10\n" +
                "Timeslot: 10:00 - 11:00\n" +
                "Participants:\n" +
                "-----------------\n" +
                "Alice\nBob\n-----------------\n" +
                "Space: Room 1\n" +
                "Equipment: Yoga mat, Resistance bands, \n" +
                "Personal Trainer: John, \n" +
                "---------------------------------------------\n", result);
        }

        [TestMethod]
        public void GroupActivity_CSVify_ReturnsExpectedString()
        {
            var activity = new GroupActivity(
                new List<PersonalTrainer>()
                {
                    new PersonalTrainer("John")
                },
                "Pilates",
                1,
                10,
                "10:00 - 11:00",
                new List<Customer>()
                {
                    new Customer("Alice","123","alice@test", AccessLevels.PayingMember),
                    new Customer("Bob","999", "bob@test", AccessLevels.DayPassUser)
                },
                new Space("Room 1"),
                new List<Equipment>()
                {
                    new Equipment("Yoga mat"),
                    new Equipment("Resistance bands")
                });

            var result = activity.CSVify();

            Assert.AreEqual("personalTrainer:John," +
                "typeOfActivity:Pilates," +
                "activtyId:1," +
                "participantLimit:10," +
                "timeSlot:10:00 - 11:00," +
                "participants:Alice;Bob," +
                "space:Room 1," +
                "equipment:Yoga mat;Resistance bands", result);




        }

        [TestMethod]
        public void GroupShecdule_editActivity()
        {
            var activity = new GroupActivity(new List<PersonalTrainer>()
           {
                    new PersonalTrainer("John")
           },
           "Pilates",
           1,
           10,
           "10:00 - 11:00",
           new List<Customer>()
           {
                    new Customer("Alice","123","alice@test", AccessLevels.PayingMember),
                    new Customer("Bob","999", "bob@test", AccessLevels.DayPassUser)
           },
           new Space("Room 1"),
           new List<Equipment>()
           {
                    new Equipment("Yoga mat"),
                    new Equipment("Resistance bands")
           });


            activity.space = new Space("Room 2");
            activity.participants.RemoveAt(1);


            var result = activity.CSVify();
            Assert.AreEqual("personalTrainer:John," +
                "typeOfActivity:Pilates," +
                "activtyId:1," +
                "participantLimit:10," +
                "timeSlot:10:00 - 11:00," +
                "participants:Alice," +
                "space:Room 2," +
                "equipment:Yoga mat;Resistance bands", result);

        }

        [TestMethod]


        public void editActivity()
        {
            List<GroupActivity> testSchedulelist = new List<GroupActivity>();
            var activity = new GroupActivity(
                    new List<PersonalTrainer>()
                             {
                              new PersonalTrainer("John")
                             },
                            "Pilates",
                            1,
                            10,
                            "10:00 - 11:00",
                            new List<Customer>()
                            {
                                        new Customer("Alice","123","alice@test", AccessLevels.PayingMember),
                                        new Customer("Bob","999", "bob@test", AccessLevels.DayPassUser)
                            },
                            new Space("Room 1"),
                            new List<Equipment>()
                            {
                                        new Equipment("Yoga mat"),
                                        new Equipment("Resistance bands")
                            });
            testSchedulelist.Add(activity);


            string editActivityChoice = "Pilates";
            string newName = "Astronaut Training";
            int newID = 902;
            int newParticipantLimit = 62;
            string removeParticipant = "Kurt Olsson";
            int changeSpace = 1;
            string removeEquipment = "Yoga mat";
            int addEquipment = 1;
            int command = 0;


            void editActivityTest(int command)
            {
                for (int i = 0; i < testSchedulelist.Count; i++)
                {
                    if (editActivityChoice.ToLower() == testSchedulelist[i].typeOfActivity.ToLower())
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
                        switch (command)
                        {
                            case 1:
                                if (testSchedulelist[i].typeOfActivity != newName)
                                {
                                    testSchedulelist[i].typeOfActivity = newName;
                                    Console.WriteLine($"The new name for this activity is: {newName}");
                                }
                                break;
                            case 2:
                                if (testSchedulelist[i].activtyId != newID)
                                {
                                    testSchedulelist[i].activtyId = newID;
                                    Console.WriteLine($"The new uniqID for this activity is: {newID}");
                                }

                                break;
                            case 3:
                                if (testSchedulelist[i].participantLimit != newParticipantLimit)
                                {
                                    testSchedulelist[i].participantLimit = newParticipantLimit;
                                    Console.WriteLine($"The new participation limit is: {newParticipantLimit}");
                                }

                                break;
                            case 4:
                                //--TBD Då denna påverkar Spaces,Equipment och PersonalTrainers så är denna satt som TBD
                                Console.WriteLine("Unavailable at this moment");
                                break;
                            case 5:
                                //--Ta port en perticipant från groupActivity
                                List<Customer> participants = testSchedulelist[i].participants;
                                foreach (User participant in participants)
                                {
                                    Console.WriteLine(participant.name);
                                }
                                for (int j = 0; j < participants.Count; j++)
                                {

                                    if (participants[j].name == removeParticipant)
                                    {
                                        participants.RemoveAt(j);
                                        Console.WriteLine($"Removed {removeParticipant} from this Activity");
                                        Console.WriteLine($"Sent a message to {participants[j].name}");
                                        break;
                                    }
                                }
                                break;
                            case 6:
                                //--Ändra Space i groupActivity till en annan space
                                Space.ShowAvailable();
                                if (testSchedulelist[i].space != Space.spaceList[changeSpace - 1])
                                {
                                    testSchedulelist[i].space = Space.spaceList[changeSpace - 1];
                                    Console.WriteLine($"Changed to location to {Space.spaceList[changeSpace - 1].name}");
                                }
                                break;
                            case 7:
                                //--Tar bort Equipment från groupActivity. Körs enbart en gång så man får gå in i denna menyn igen om man vill ta bort flera
                                List<Equipment> equipmentAcitivy = testSchedulelist[i].equipment;
                                foreach (Equipment equipment in equipmentAcitivy)
                                {
                                    Console.WriteLine(equipment.name);
                                }
                                for (int y = 0; y < equipmentAcitivy.Count; y++)
                                {
                                    if (equipmentAcitivy[y].name.ToLower() == removeEquipment.ToLower())
                                    {
                                        equipmentAcitivy.RemoveAt(y);
                                        Console.WriteLine($"Removed {removeEquipment} from this Activity");

                                        for (int x = 0; x < equipmentAcitivy.Count; x++)
                                        {
                                            if (equipmentAcitivy[x].reservedTimeSlot.Contains(testSchedulelist[i].timeSlot))
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
                                Equipment.ShowAvailable(testSchedulelist[i].timeSlot);
                                if (!testSchedulelist[i].equipment.Contains(Equipment.equipmentList[addEquipment - 1]))
                                {
                                    testSchedulelist[i].equipment.Add(Equipment.equipmentList[addEquipment - 1]);
                                    Equipment.ReservEquipment(Equipment.equipmentList[addEquipment - 1], testSchedulelist[i].timeSlot, testSchedulelist[i].typeOfActivity);
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input, type a number");
                                break;
                        }
                    }
                }
            }

            //KOMMENTERA BORT/FRAM DEN KOD SOM SKALL TESTAS. 



            //command = 1;
            //editActivityTest(command);

            //var result = activity.ToString();
            //Assert.AreEqual("---------------------------------------------\n" +
            //        "Type Of Activity: Astronaut Training\n" +
            //        "Activity ID: 1\n" +
            //        "Perticipant Limit: 10\n" +
            //        "Timeslot: 10:00 - 11:00\n" +
            //        "Participants:\n" +
            //        "-----------------\n" +
            //        "Alice\nBob\n-----------------\n" +
            //        "Space: Room 1\n" +
            //        "Equipment: Yoga mat, Resistance bands, \n" +
            //        "Personal Trainer: John, \n" +
            //        "---------------------------------------------\n", result);

            //command = 2;
            //editActivityTest(command);

            //var result = activity.ToString();
            //Assert.AreEqual("---------------------------------------------\n" +
            //        "Type Of Activity: Pilates\n" +
            //        "Activity ID: 902\n" +
            //        "Perticipant Limit: 10\n" +
            //        "Timeslot: 10:00 - 11:00\n" +
            //        "Participants:\n" +
            //        "-----------------\n" +
            //        "Alice\nBob\n-----------------\n" +
            //        "Space: Room 1\n" +
            //        "Equipment: Yoga mat, Resistance bands, \n" +
            //        "Personal Trainer: John, \n" +
            //        "---------------------------------------------\n", result);


            command = 7;
            editActivityTest(command);

            var result = activity.ToString();
            Assert.AreEqual("---------------------------------------------\n" +
                    "Type Of Activity: Pilates\n" +
                    "Activity ID: 1\n" +
                    "Perticipant Limit: 10\n" +
                    "Timeslot: 10:00 - 11:00\n" +
                    "Participants:\n" +
                    "-----------------\n" +
                    "Alice\nBob\n-----------------\n" +
                    "Space: Room 1\n" +
                    "Equipment: Resistance bands, \n" +
                    "Personal Trainer: John, \n" +
                    "---------------------------------------------\n", result);


        }
    }
}
