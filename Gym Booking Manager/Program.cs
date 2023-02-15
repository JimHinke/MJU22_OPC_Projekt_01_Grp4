using Gym_Booking_Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;
using static Gym_Booking_Manager.Equipment;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            CsvHandler.CreateCSV();
            LoadFiles();            

            // FUL TESTAR!	
            //Equipment.equipmentList.Add(new Equipment("Test1", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.Treadmill));
            //Equipment.equipmentList.Add(new Equipment("Test2", Equipment.EquipmentType.Sport, Equipment.EquipmentCategory.TennisRacket));
            //Equipment.equipmentList.Add(new Equipment("Test3", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.RowingMachine));


            //Customer CurrentCustomer = new Customer("Current Customer", "0987321", "CurrentCustomer@test.se") { uniqueID = 10 };
            //Customer testCustomer1 = new Customer("TestCustomer 1", "1234", "test1@gmail.com") { uniqueID = 20 };
            //Customer testCustomer2 = new Customer("TestCustomer 2", "1234", "test2@gmail.com") { uniqueID = 30 };
            //Customer testCustomer3 = new Customer("TestCustomer 3", "1234", "test3@gmail.com") { uniqueID = 40 };
            //Customer.customerList.Add(CurrentCustomer);
            //         Customer.customerList.Add(testCustomer1);
            //         Customer.customerList.Add(testCustomer2);
            //         Customer.customerList.Add(testCustomer3);


            //PersonalTrainer testAvPersonalTrainer = new PersonalTrainer("Personlig Tränare");
            //PersonalTrainer.personalTrainers.Add(testAvPersonalTrainer);


            //Console.WriteLine(Space.spaceList[0]);
            //Space.spaceList[0].SetAvailability(Space.Availability.Reserved);
            //Console.WriteLine(Space.spaceList[0]);

            //Console.WriteLine($"Migration started at {DateTime.Now}");

            //List<Equipment> equipmentList = new List<Equipment>();
            //equipmentList.Add(Equipment.equipmentList[0]);
            //User.userList.Add(CurrentCustomer);

            //GroupActivity temp = new GroupActivity(
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
            //GroupSchedule.groupScheduleList.Add(temp);
            //Equipment.ShowAvailable("12:00");

            while (true)
            {
                MainMenu();
            }
        }


        // Static methods for the program

        public static void LoadFiles()
        {
            CsvHandler.ReadFile("Spaces.txt");           
            CsvHandler.ReadFile("Equipment.txt");
            CsvHandler.ReadFile("PersonalTrainer.txt");
            //CsvHandler.ReadFile("C:\\Users\\Gusta\\source\\repos\\MJU22_OPC_Projekt_01_Grp4\\Gym Booking Manager\\CSV\\GroupActivities.txt"); //???

            Console.WriteLine("---------------------SPACES LOADED---------------------");
            for (int i = 0; i < Space.spaceList.Count; i++)
            {
                Console.WriteLine(Space.spaceList[i]);
            }
            Console.WriteLine("-------------------------------------------------------\n");

            Console.WriteLine("----------------------EQUIPMENT LOADED-----------------------");
            for (int i = 0; i < Equipment.equipmentList.Count; i++)
            {
                Console.WriteLine(Equipment.equipmentList[i]);
            }
            Console.WriteLine("-------------------------------------------------------------\n");

            Console.WriteLine("----------------------PERSONALTRAINER LOADED------------------------");
            for (int i = 0; i < PersonalTrainer.personalTrainers.Count; i++)
            {
                Console.WriteLine(PersonalTrainer.personalTrainers[i]);
            }
            Console.WriteLine("--------------------------------------------------------------------\n");
        }
        public static void MainMenu()
        {
            Console.WriteLine("-------------Main Menu:-------------");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create account");
            Console.WriteLine("3. View group schedule");
            Console.WriteLine("4. Quit");
            Console.WriteLine("------------------------------------\n");
            try
            {
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
                    csvHandler.WriteFile(PersonalTrainer.personalTrainers, "PersonalTrainer.txt");                   
                    //csvHandler.WriteFile(Space.spaceList, "GroupActivity.txt");

                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input, type a number");
                    break;

            }
        }
    }
}
