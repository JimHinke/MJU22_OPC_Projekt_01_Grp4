using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class PersonalTrainer : Resources
    {
        private TypeOfTrainerCategory typeOfTrainerCategory;
        public static List<PersonalTrainer> personalTrainers = new List<PersonalTrainer>();
		public IReservingEntity owner { get; set; }
		public PersonalTrainer(string name, Calendar calendar = null) : base(name, TimeSlot, null ,calendar)
        {

        }

        public enum TypeOfTrainerCategory
        {
            YogaInstructor,
            GymInstructor,
            TennisTeacher
        }
    }
}
