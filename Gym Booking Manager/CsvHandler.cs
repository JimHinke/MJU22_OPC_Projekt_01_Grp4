using Gym_Booking_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;
using System.Xml.Linq;
using Gym_Booking_Manager.Interfaces;

namespace Gym_Booking_Manager
{
    public class CsvHandler
    {
        //public static void ReadFile(string fileName)
        //{
        //    string fileName2 = @$"CSV\{fileName}";
        //    string newPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        //    string filePath = Path.Combine(newPath, fileName2);

        //    string[] lines = File.ReadAllLines(filePath);
        //    foreach (string line in lines)
        //    {
        //        string[] values = line.Split(',');
        //        string name = "";
        //        SpaceCategory spaceCategory = 0;
        //        Availability availability = 0;
        //        IReservingEntity owner = null;
        //        string timeSlot = "";
        //        Calendar calendar = null;
        //        foreach (string value in values)
        //        {
        //            string[] parts = value.Split(':');
        //            if (parts[0] == "spaceCategory")
        //            {
        //                if (parts[1] == "Hall")
        //                {
        //                    spaceCategory = SpaceCategory.Hall;
        //                }
        //                else if (parts[1] == "Studio")
        //                {
        //                    spaceCategory = SpaceCategory.Studio;
        //                }
        //                else if (parts[1] == "Lane")
        //                {
        //                    spaceCategory = SpaceCategory.Lane;
        //                }
        //            }
        //            else if (parts[0] == "name")
        //            {
        //                name = parts[1];
        //            }
        //            else if (parts[0] == "spaceAvailability")
        //            {
        //                if (parts[1] == "Reserved")
        //                {
        //                    availability = Availability.Reserved;
        //                }
        //                else if (parts[1] == "Available")
        //                {
        //                    availability = Availability.Available;
        //                }
        //                else if (parts[1] == "Unavailable")
        //                {
        //                    availability = Availability.Available;
        //                }
        //            }
        //        }
        //        spaceList.Add(new Space(name, spaceCategory, availability, owner, timeSlot, calendar));
        //    }
        //}


        //public void WriteFile<T>(List<T> objects, string fileName) where T : ICSVable
        //{
        //    string fileName2 = @$"CSV\{fileName}";
        //    string newPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
        //    string filePath = Path.Combine(newPath, fileName2);
        //    Console.WriteLine(filePath);
        //    Console.ReadLine();

        //    if (File.Exists(filePath))
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath, false))
        //        {
        //            foreach (var obj in objects)
        //            {
        //                writer.WriteLine(obj.CSVify());
        //            }
        //        }
        //    }
        //    else
        //    {
        //        using (StreamWriter writer = new StreamWriter(filePath, true))
        //        {
        //            foreach (var obj in objects)
        //            {
        //                writer.WriteLine(obj.CSVify());
        //            }
        //        }
        //    }
        //}

        public void WriteFile<T>(List<T> objects, string fileName) where T : ICSVable
        {
            string folderName = "CSV";
            string newPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
            Directory.CreateDirectory(newPath);

            string filePath = Path.Combine(newPath, fileName);
            Console.WriteLine(filePath);
            Console.ReadLine();

            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    foreach (var obj in objects)
                    {
                        writer.WriteLine(obj.CSVify());
                    }
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (var obj in objects)
                    {
                        writer.WriteLine(obj.CSVify());
                    }
                }
            }
        }

    }
}
