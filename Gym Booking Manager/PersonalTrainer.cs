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
        public PersonalTrainer(string name, Calendar calendar = null) : base(name, calendar)
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
