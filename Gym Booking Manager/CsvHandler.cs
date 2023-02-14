using Gym_Booking_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;
using System.Xml.Linq;

namespace Gym_Booking_Manager
{
    internal class CsvHandler
    {
        public static void ReadFile(string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                string name = "";
                SpaceCategory spaceCategory = 0;
                Availability availability = 0;
                string owner = "";
                string timeSlot = "";
                Calendar calendar = null;
                foreach (string value in values)
                {
                    string[] parts = value.Split(':');
                    if (parts[0] == "spaceCategory")
                    {
                        if (parts[1] == "Hall")
                        {
                            spaceCategory = SpaceCategory.Hall;
                        }
                        else if (parts[1] == "Studio")
                        {
                            spaceCategory = SpaceCategory.Studio;
                        }
                        else if (parts[1] == "Lane")
                        {
                            spaceCategory = SpaceCategory.Lane;
                        }
                    }
                    else if (parts[0] == "name")
                    {
                        name = parts[1];
                    }
                    else if (parts[0] == "spaceAvailability")
                    {
                        if (parts[1] == "Reserved")
                        {
                            availability = Availability.Reserved;
                        }
                        else if (parts[1] == "Available")
                        {
                            availability = Availability.Available;
                        }
                        else if (parts[1] == "Unavailable")
                        {
                            availability = Availability.Available;
                        }
                    }
                }                
                spaceList.Add(new Space(name, spaceCategory, availability, owner, timeSlot, calendar));
            }
        }

        
        //public static void readfile(string filepath)
        //{
        //    string file = filepath;
        //    if (!file.exists(file))
        //    {
        //        console.writeline("file does not exist :{0} ", file);
        //        return;
        //    }

        //    string[] textfromfile = file.readalllines(file);
        //    foreach (string line in textfromfile)
        //    {
        //        console.writeline(line);
        //    }            
        //}

        

        public void WriteFile<T>(List<T> objects)
        {

            //if (objects.GetType == Equipment)

            string filePath = @"\MJU22_OPC_Projekt_01_Grp4\Gym Booking Manager\CSV\Spaces.txt";

            if (File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (var obj in objects)
                    {
                        var objType = obj.GetType();
                        var csvifyMethod = objType.GetMethod("CSVify");
                        if (csvifyMethod != null)
                        {
                            writer.WriteLine((string)csvifyMethod.Invoke(obj, null));
                        }
                        else
                        {
                            // Handle the case where the object does not have a CSVify method
                        }
                    }
                }
            }
        }
    }
}
