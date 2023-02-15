using Gym_Booking_Manager;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static Gym_Booking_Manager.Equipment;
using CsvHelper;
using System.IO;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Program
    {


		static void Main(string[] args)
		{

            // FUL TESTAR!	
            LoadFiles();
            Equipment.equipmentList.Add(new Equipment("Test1", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.Treadmill));
            Equipment.equipmentList.Add(new Equipment("Test2", Equipment.EquipmentType.Sport, Equipment.EquipmentCategory.TennisRacket));
            Equipment.equipmentList.Add(new Equipment("Test3", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.RowingMachine));

            //Customer.customerList.Add(new Customer("Current Customer", "0987321", "CurrentCustomer@test.se") { uniqueID = 10, AccessLevel = AccessLevels.DayPassUser });
            //         Customer.customerList.Add(new Customer("TestCustomer 1", "1234", "test1@gmail.com") { uniqueID = 20 });
            //         Customer.customerList.Add(new Customer("TestCustomer 2", "1234", "test2@gmail.com") { uniqueID = 30 });
            //         Customer.customerList.Add(new Customer("TestCustomer 3", "1234", "test3@gmail.com") { uniqueID = 40 });

            //         User.userList.Add(new Customer("TestCustomer 1", "1234", "test1@gmail.com") { uniqueID = 20 });

            PersonalTrainer testAvPersonalTrainer = new PersonalTrainer("Jimmie Hinke", PersonalTrainer.TrainerCategory.GymInstructor);
            PersonalTrainer.personalTrainers.Add(testAvPersonalTrainer);
            List<PersonalTrainer> testPersonalTrainerList = new List<PersonalTrainer>();


            List<Equipment> testEquipmentList = new List<Equipment>();
            testEquipmentList.Add(Equipment.equipmentList[0]);

            GroupActivity temp = new GroupActivity(
                            testPersonalTrainerList, //Personal Trainer
                            GroupSchedule.TypeOfActivity[0], //Type Of Activity
                            23, //Unique ID set to an random number. Is this needed?
                            1, //Particpant Limit
                            GroupSchedule.TimeSlot[0], //Time Slot
                            null, //List of Participants. This is not added here but rather under another menu-choice
                            Space.spaceList[0], //What space is used for this session
                            testEquipmentList //What Equipment is used for this session
                            );

            GroupSchedule.groupScheduleList.Add(temp);

            //GroupSchedule.showActivities();

            //GroupSchedule.deleteActivity();
            Console.WriteLine(Space.spaceList[0]);

            while (true)
            {
                MainMenu();
            }

        }

        // Static methods for the program

        public static void LoadFiles()
        {
            CsvHandler.ReadFile("Spaces.txt");           
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

                    CsvHandler csvHandler = new CsvHandler();
                    csvHandler.WriteFile(Space.spaceList, "Spaces.txt");                    
                    csvHandler.WriteFile(Equipment.equipmentList, "Equipment.txt");                    
                    csvHandler.WriteFile(Space.spaceList, "PersonalTrainer.txt");                   
                    csvHandler.WriteFile(Space.spaceList, "GroupActivity.txt");

                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;

            }
        }
    }
}
