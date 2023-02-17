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
        public string timeslot { get; set; }
        public IReservingEntity owner { get; set; }
        public static List<Equipment> availableEquipment = new List<Equipment>();
        private static List<Equipment> _equipmentList = new List<Equipment>();
        public static List<Equipment> equipmentList { get { return _equipmentList; } set { _equipmentList = value; } }
        public static List<PersonalTrainer> _personalTrainers = new List<PersonalTrainer>();
        public static List<PersonalTrainer> personalTrainers { get { return _personalTrainers; } set { _personalTrainers = value; } }
        private static List<Space> _spaceList = new List<Space>();
		public static List<Space> spaceList { get { return _spaceList; } set { _spaceList = value; } }

        public static List<string> TimeSlot = new List<string>()
        {
            "12:00-13:00",
            "13:00-14:00",
            "14:00-15:00"
        };
        public Resources(string name = "", List<string> timeSlot = null, string timeslot = "" ,IReservingEntity owner = null)
        {
            this.name = name;
            TimeSlot = timeSlot;
            this.owner = owner;
            this.timeslot = timeslot;
        }

    }
}
