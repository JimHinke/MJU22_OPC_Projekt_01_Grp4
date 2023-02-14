using Gym_Booking_Manager;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Gym_Booking_Manager.Equipment;
using CsvHelper;
using System.Globalization;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Program
    {


        static void Main(string[] args)
        {


            LoadFiles();
            Equipment.equipmentList.Add(new Equipment("Test1", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.Treadmill));
            Equipment.equipmentList.Add(new Equipment("Test2", Equipment.EquipmentType.Sport, Equipment.EquipmentCategory.TennisRacket, null, Equipment.Availability.Reserved));
            Equipment.equipmentList.Add(new Equipment("Test3", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.RowingMachine));

            Customer CurrentCustomer = new Customer("Current Customer", "0987321", "CurrentCustomer@test.se");

            Customer testCustomer1 = new Customer("TestCustomer 1", "1234", "test1@gmail.com");
            Customer testCustomer2 = new Customer("TestCustomer 2", "1234", "test2@gmail.com");
            Customer testCustomer3 = new Customer("TestCustomer 3", "1234", "test3@gmail.com");


            Space.spaceList.Add(new Space("Hall", Space.SpaceCategory.Hall, Space.Availability.Available));
            Space.spaceList.Add(new Space("Lane", Space.SpaceCategory.Lane, Space.Availability.Available));
            Space.spaceList.Add(new Space("Studio", Space.SpaceCategory.Studio, Space.Availability.Available));


            PersonalTrainer testAvPersonalTrainer = new PersonalTrainer("Jimmie Hinke");
            PersonalTrainer.personalTrainers.Add(testAvPersonalTrainer);


            GroupSchedule.EQC.Add(Equipment.equipmentList[0]);
            User.userList.Add(CurrentCustomer);

            GroupActivity temp = new GroupActivity(
                            PersonalTrainer.personalTrainers[0], //Personal Trainer
                            GroupSchedule.TypeOfActivity[0], //Type Of Activity
                            23, //Unique ID set to an random number. Is this needed?
                            32, //Particpant Limit
                            Resources.TimeSlot[0], //Time Slot
                            null, //List of Participants. This is not added here but rather under another menu-choice
                            Space.spaceList[0], //What space is used for this session
                            GroupSchedule.EQC //What Equipment is used for this session
                            );

            GroupSchedule.groupScheduleList.Add(temp);

            while (true)
            {
                MainMenu();
            }

        }

        // Static methods for the program

        public static void LoadFiles()
        {
            //CsvHandler.ReadFile("C:\\Users\\Gusta\\source\\repos\\MJU22_OPC_Projekt_01_Grp4\\Gym Booking Manager\\CSV\\Spaces.txt");
            //CsvHandler.ReadFile("C:\\Users\\Gusta\\source\\repos\\MJU22_OPC_Projekt_01_Grp4\\Gym Booking Manager\\CSV\\Equipment.txt");
            //CsvHandler.ReadFile("C:\\Users\\Gusta\\source\\repos\\MJU22_OPC_Projekt_01_Grp4\\Gym Booking Manager\\CSV\\PersonalTrainer.txt");
            //CsvHandler.ReadFile("C:\\Users\\Gusta\\source\\repos\\MJU22_OPC_Projekt_01_Grp4\\Gym Booking Manager\\CSV\\GroupActivities.txt"); //???
        }

        public static void MainMenu()
        {
            Console.WriteLine("-------------Main Menu:-------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create account");
            Console.WriteLine("3. View group schedule");
            Console.WriteLine("4. Quit");
            Console.WriteLine("--------------------------------------\n");


            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    Customer.LoginMenu();
                    break;
                case 2:
                    Customer.DayPassMenu();
                    break;
                case 3:
                    User.manageSchedule();
                    break;
                case 4:
                    Console.WriteLine("\nExiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;

            }
        }
    }
}
