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
using System.ComponentModel;
using System.Reflection.PortableExecutable;

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
            CsvHandler.ReadFile("GroupActivity.txt");

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
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("----------------------GROUP ACTIVITIES LOADED------------------------");
            for (int i = 0; i < GroupSchedule.groupScheduleList.Count; i++)
            {
                Console.WriteLine(GroupSchedule.groupScheduleList[i]);
            }
            Console.WriteLine("---------------------------------------------------------------------\n");
            Console.ReadLine();
            Console.Clear();
        }
    }
}