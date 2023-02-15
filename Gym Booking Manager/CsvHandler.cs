using Gym_Booking_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using System.Xml.Linq;
using Gym_Booking_Manager.Interfaces;
using static Gym_Booking_Manager.Space;


namespace Gym_Booking_Manager
{
    public class CsvHandler
    {
        static int initialized = 0;

        public static void ReadFile(string fileName)
        { 
            string filePath = Path.Combine("CSV", fileName);            

            if (initialized != 1)
            {
                if (fileName == "Spaces.txt")
                {
                    
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        string name = "";
                        Space.SpaceCategory spaceCategory = 0;
                        Space.Availability availability = 0;
                        //IReservingEntity owner = null;
                        //string timeSlot = "";
                        //Calendar calendar = null;
                        foreach (string value in values)
                        {
                            string[] parts = value.Split(':');
                            if (parts[0] == "spaceCategory")
                            {
                                Enum.TryParse(parts[1], out spaceCategory);
                            }
                            else if (parts[0] == "name")
                            {
                                name = parts[1];
                            }
                            else if (parts[0] == "spaceAvailability")
                            {
                                Enum.TryParse(parts[1], out availability);
                            }
                        }
                        Space.spaceList.Add(new Space(name, spaceCategory, availability));
                    }
                }
                else if (fileName == "Equipment.txt")
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        string name = "";
                        Equipment.EquipmentCategory equipmentCategory = 0;
                        Equipment.EquipmentType equipmentType = 0;
                        Equipment.Availability availability = 0;
                        foreach (string value in values)
                        {
                            string[] parts = value.Split(':');
                            if (parts[0] == "equipmentCategory")
                            {
                                Enum.TryParse(parts[1], out equipmentCategory);
                            }
                            else if (parts[0] == "name")
                            {
                                name = parts[1];
                            }
                            else if (parts[0] == "equipmentAvailability")
                            {
                                Enum.TryParse(parts[1], out availability);
                            }
                        }
                        Equipment.equipmentList.Add(new Equipment(name, equipmentType, equipmentCategory, availability));
                    }
                }

                else if (fileName == "PersonalTrainer.txt")
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] values = line.Split(',');
                        string name = "";
                        PersonalTrainer.TrainerCategory trainerCategory = 0;
                        PersonalTrainer.Availability availability = 0;
                        foreach (string value in values)
                        {
                            string[] parts = value.Split(':');
                            if (parts[0] == "personalTrainers")
                            {
                                Enum.TryParse(parts[1], out trainerCategory);
                            }
                            else if (parts[0] == "name")
                            {
                                name = parts[1];
                            }
                            else if (parts[0] == "trainerAvailability")
                            {
                                Enum.TryParse(parts[1], out availability);
                            }
                        }
                        PersonalTrainer.personalTrainers.Add(new PersonalTrainer(name, trainerCategory, availability));
                    }
                } 
            }
        }

        public void WriteFile<T>(List<T> objects, string fileName) where T : ICSVable
        {
            string filePath = Path.Combine("CSV", fileName);

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

        public static void CreateCSV()
        {            
            if (!Directory.Exists("CSV"))
            {                
                Directory.CreateDirectory("CSV");

                Space.spaceList.Add(new Space("Hall", Space.SpaceCategory.Hall, Space.Availability.Available));
                Space.spaceList.Add(new Space("Lane", Space.SpaceCategory.Lane, Space.Availability.Available));
                Space.spaceList.Add(new Space("Studio", Space.SpaceCategory.Studio, Space.Availability.Available));

                Equipment.equipmentList.Add(new Equipment("Test1", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.Treadmill));
                Equipment.equipmentList.Add(new Equipment("Test2", Equipment.EquipmentType.Sport, Equipment.EquipmentCategory.TennisRacket));
                Equipment.equipmentList.Add(new Equipment("Test3", Equipment.EquipmentType.Large, Equipment.EquipmentCategory.RowingMachine));
                
                PersonalTrainer.personalTrainers.Add(new PersonalTrainer("Yanus Yoga", PersonalTrainer.TrainerCategory.YogaInstructor));
                PersonalTrainer.personalTrainers.Add(new PersonalTrainer("Gurra Gymbro", PersonalTrainer.TrainerCategory.GymInstructor));
                PersonalTrainer.personalTrainers.Add(new PersonalTrainer("Tomas Tennis", PersonalTrainer.TrainerCategory.TennisTeacher));

                CsvHandler csvHandler = new CsvHandler();
                csvHandler.WriteFile(Space.spaceList, "Spaces.txt");
                csvHandler.WriteFile(Equipment.equipmentList, "Equipment.txt");
                csvHandler.WriteFile(PersonalTrainer.personalTrainers, "PersonalTrainer.txt");

                initialized = 1;
            }            
        }
    }
}
