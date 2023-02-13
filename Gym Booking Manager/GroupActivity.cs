using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class GroupActivity
    {
        public int activtyId { get; set; }
        public int participantLimit { get; set; }
        public string timeSlot { get; set; }
        public List<User> participants { get; set; }
        public PersonalTrainer personalTrainer { get; set; }
        public Space space { get; set; }
        public List<Equipment> equipment { get; set; }
        public string typeOfActivity { get; set; }

        public GroupActivity(
                    PersonalTrainer personalTrainer,
                    string typeOfActivity = "",
                    int activtyId = 0,
                    int participantLimit = 0,
                    string timeSlot = "",
                    User participants = null,
                    Space space = null,
                    List<Equipment> equipment = null
                    )
        {
            this.typeOfActivity = typeOfActivity;
            this.activtyId = activtyId;
            this.participantLimit = participantLimit;
            this.timeSlot = timeSlot;
            this.participants = new List<User>();
            this.personalTrainer = personalTrainer;
            this.space = space;
            this.equipment = equipment;
        }
        public override string ToString()
        {

            string participantNames = "";
            if (participants.Count > 0)
            {
                foreach (var participant in participants)
                {
                    participantNames += participant.name + "\n";
                }
            }
            else
                participantNames = "No one is booked for this activity\n";

            string equipmentNames = "";
            if (equipment.Count > 0)
            {
                foreach (var EQ in equipment)
                {
                    equipmentNames += EQ.name + ", ";
                }
            }
            else
                equipmentNames = "No Equipment for this s";

            return $"---------------------------------------------\n" +
                $"Type Of Activity: {typeOfActivity}\n" +
                $"Activity ID: {activtyId}\n" +
                $"Perticipant Limit: {participantLimit}\n" +
                $"Timeslot: {timeSlot}\n" +
                $"Participants:\n" +
                $"-----------------\n" +
                $"{participantNames}" +
                $"-----------------\n" +
                $"Space: {space.name}\n" +
                $"Equipment: {equipmentNames}\n" +
                $"Personal Trainer: {personalTrainer.name}\n" +
                $"---------------------------------------------\n";
        }
    }
}
