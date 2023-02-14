using Gym_Booking_Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Equipment;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class PersonalTrainer : Resources
    {
        public string owner { get; set; }
        private TrainerCategory trainerCategory { get; set; }
        public Availability trainerAvailability { get; set; }
        public List<string> reservedTimeSlot { get; set; }
        public static int index = 0;

        public PersonalTrainer(string name, TrainerCategory trainerCategory, Availability availability = Availability.Available, string owner = "")
        {
            this.owner = owner;
            this.name = name;
            this.trainerCategory = trainerCategory;
            this.reservedTimeSlot = new List<string>();
        }
        public enum TrainerCategory
        {
            YogaInstructor,
            GymInstructor,
            TennisTeacher
        }

        public enum Availability
        {
            Available,
            Service,
            PlannedPurchase,
            Reserved
        }

        public Availability SetAvailability(Availability availability)
        {
            return this.trainerAvailability = availability;
        }


        public static void ShowAvailable(string timeslot)
        {
            personalTrainers = personalTrainers.OrderBy(x => x.trainerAvailability != Availability.Available).ToList();
            personalTrainers = personalTrainers.OrderBy(x => x.reservedTimeSlot.Contains(timeslot)).ToList();
            index = 0;
            for (int i = 0; i < personalTrainers.Count; i++)
            {
                if (personalTrainers[i].trainerAvailability == Availability.Available && !personalTrainers[i].reservedTimeSlot.Contains(timeslot))
                {
                    index++;
                    Console.WriteLine(i + 1 + " " + personalTrainers[i].name);
                }
            }
        }
        public static void ReservTrainer(PersonalTrainer trainer, string timeslot, string customer)
        {
            if (trainer.trainerAvailability == Availability.Available && !trainer.reservedTimeSlot.Contains(timeslot))
            {
                trainer.reservedTimeSlot.Add(timeslot);
                trainer.owner = customer;
            }
            else
            {
                Console.WriteLine("This personal trainer is not available for reservation during that timeslot.");
            }
        }
        public override string ToString()
        {
            return $"Namn: {name}, Category: {trainerCategory}, Avilability: {trainerAvailability}";
        }

    }
}
