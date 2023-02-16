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

            //PersonalTrainer testAvPersonalTrainer = new PersonalTrainer("Jimmie Hinke", PersonalTrainer.TrainerCategory.GymInstructor);
            //PersonalTrainer.personalTrainers.Add(testAvPersonalTrainer);
            //List<PersonalTrainer> testPersonalTrainerList = new List<PersonalTrainer>();

            //Space.spaceList.Add(new Space("Hall", Space.SpaceCategory.Hall, Space.Availability.Available));
            //List<Equipment> testEquipmentList = new List<Equipment>();
            //testEquipmentList.Add(Equipment.equipmentList[0]);

            //GroupActivity temp = new GroupActivity(
            //                testPersonalTrainerList, //Personal Trainer
            //                GroupSchedule.TypeOfActivity[0], //Type Of Activity
            //                23, //Unique ID set to an random number. Is this needed?
            //                1, //Particpant Limit
            //                GroupSchedule.TimeSlot[0], //Time Slot
            //                null, //List of Participants. This is not added here but rather under another menu-choice
            //                Space.spaceList[0], //What space is used for this session
            //                testEquipmentList //What Equipment is used for this session
            //                );
            ////List<PersonalTrainer> personalTrainerList = new List<PersonalTrainer>();
            //GroupSchedule.groupScheduleList.Add(temp);









            //Admin testAdmin = new Admin("Test Admin", "098873", "testAdmin@gmail.com", AccessLevels.Admin);
            //Customer testAdmin2 = new Customer("Test Admin", "098873", "testAdmin@gmail.com", AccessLevels.DayPassUser);
            ////Staff testAdmin3 = new Staff("Test Admin", "098873", "testAdmin@gmail.com");
            ////Service testAdmin4 = new Service("Test Admin", "098873", "testAdmin@gmail.com");
            //Console.WriteLine(testAdmin);
            //Console.WriteLine(testAdmin2);
            ////Console.WriteLine(testAdmin3);
            ////Console.WriteLine(testAdmin4);


            //User testCustomer = new Customer("Test Customer", "0987321", "testCustomer@test.se", AccessLevels.PayingMember) { uniqueID = 10 };
            //Console.WriteLine(testCustomer);

            //GroupSchedule.showActivities();

            //GroupSchedule.deleteActivity();
            //Console.WriteLine(Space.spaceList[0]);

            //GroupSchedule.groupScheduleList.Add(temp);
            //Equipment.ShowAvailable("12:00");

            while (true)
            {
                Menutracker.MainMenu();
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
    }
}
