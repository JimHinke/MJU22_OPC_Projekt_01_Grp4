using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    abstract class Resources
    {
        public string name { get; set; }
        public Calendar calendar { get; set; }
        public IReservingEntity owner { get; set; }

        
        public static List<Equipment> availableEquipment = new List<Equipment>();
        private static List<Equipment> _equipmentList = new List<Equipment>();
        public static List<Equipment> equipmentList { get { return _equipmentList; } set { _equipmentList = value; } }
        public static List<PersonalTrainer> personalTrainers = new List<PersonalTrainer>();

        public static List<string> TimeSlot = new List<string>()
        {
            "12:00-13:00",
            "13:00-14:00",
            "14:00-15:00"
        };
        public Resources(string name = "", List<string> timeSlot = null, IReservingEntity owner = null ,Calendar calendar = null)
        {
            this.name = name;
            TimeSlot = timeSlot;
            this.owner = owner;
            this.calendar = calendar;
        }

        



    }
}
