using Gym_Booking_Manager.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Gym_Booking_Manager.Equipment;
using static Gym_Booking_Manager.PersonalTrainer;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class DBStorage
    {
        public static void loadPT_DB()
        {
            var cs = "Host=localhost;Username=postgres;Password=Jim861223;Database=gym_db";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM personaltrainer";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int trainerCategory = reader.GetInt32(2);
                int availability = reader.GetInt32(3);
                int owner_id = reader.GetInt32(4);
                string timeSlot = reader.GetString(5);

                TrainerCategory trainerCat = (TrainerCategory)Enum.Parse(typeof(TrainerCategory), trainerCategory.ToString());
                PersonalTrainer.Availability avi = (PersonalTrainer.Availability)Enum.Parse(typeof(PersonalTrainer.Availability), availability.ToString());

                PersonalTrainer.personalTrainers.Add(new PersonalTrainer(name, trainerCat, avi));
            }
        }
        public static void loadEQ_DB()
        {
            var cs = "Host=localhost;Username=postgres;Password=Jim861223;Database=gym_db";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM equipments";
            using var cmd2 = new NpgsqlCommand(@sql, con);
            using NpgsqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(reader.GetOrdinal("Name"));
                EquipmentType equipmentType = (EquipmentType)reader.GetInt32(reader.GetOrdinal("EquipmentType"));
                EquipmentCategory equipmentCategory = (EquipmentCategory)reader.GetInt32(reader.GetOrdinal("EquipmentCategory"));
                Equipment.Availability equipmentAvailability = (Equipment.Availability)reader.GetInt32(reader.GetOrdinal("Availability"));
                string timeSlot = reader.GetString(reader.GetOrdinal("TimeSlot"));


                Equipment.equipmentList.Add(new Equipment(name, equipmentType, equipmentCategory, equipmentAvailability, timeSlot));
            }
        }
        public static void loadSpace_DB()
        {
            var cs = "Host=localhost;Username=postgres;Password=Jim861223;Database=gym_db";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM spaces";
            using var cmd = new NpgsqlCommand(sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(reader.GetOrdinal("Name"));
                SpaceCategory spaceCategory = (SpaceCategory)reader.GetInt32(reader.GetOrdinal("SpaceCategory"));
                Space.Availability spaceAvailability = (Space.Availability)reader.GetInt32(reader.GetOrdinal("Availability"));
                string timeSlot = reader.GetString(reader.GetOrdinal("TimeSlot"));

                Space.spaceList.Add(new Space(name, spaceCategory, spaceAvailability));
            }
        }
        public static void loadActivity_DB()
        {
            var cs = "Host=localhost;Username=postgres;Password=Jim861223;Database=gym_db";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            string groupActivity_sql = "SELECT * FROM GroupActivities ";
            using var cmd = new NpgsqlCommand(groupActivity_sql, con);
            using NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int main_group_activity_id = reader.GetInt32(0);
                string typeofactivity = reader.GetString(1);
                int participantlimit = reader.GetInt32(2);
                string timeslot = reader.GetString(3);


                var personalTrainers = new List<PersonalTrainer>();
                var equipment = new List<Equipment>();
                int spaceIndex = 0;

                GroupActivity temp = new GroupActivity(
                            personalTrainers, //Personal Trainer
                            typeofactivity, //Type Of Activity
                            main_group_activity_id, //Unique ID set to an random number. Is this needed?
                            participantlimit, //Particpant Limit
                            timeslot, //Time Slot
                            null, //List of Participants. This is not added here but rather under another menu-choice
                            Space.spaceList[spaceIndex], //What space is used for this session
                            equipment //What Equipment is used for this session
                            );
                GroupSchedule.groupScheduleList.Add(temp);
            }
            reader.Close();



            string space_activity_sql = "SELECT * FROM GroupActivities " +
            "INNER JOIN Space_GroupActivity ON Space_GroupActivity.GroupActivityID = GroupActivities.ID " +
            "INNER JOIN spaces ON spaces.space_id = Space_GroupActivity.Space_ID";
            using var space_cmd = new NpgsqlCommand(space_activity_sql, con);
            using NpgsqlDataReader space_activity_reader = space_cmd.ExecuteReader();
            while (space_activity_reader.Read())
            {
                int GA_id = space_activity_reader.GetInt32(0);
                string name = space_activity_reader.GetString(8);

                for (int i = 0; i < GroupSchedule.groupScheduleList.Count; i++)
                {
                    if (GroupSchedule.groupScheduleList[i].activtyId == GA_id)
                    {
                        foreach (Space space in Space.spaceList)
                        {
                            if (space.name == name)
                            {
                                GroupSchedule.groupScheduleList[i].space = space;
                            }
                        }
                    }
                }
            }
            space_activity_reader.Close();

            string equipment_activity_sql = "SELECT * FROM GroupActivities " +
                "INNER JOIN Equipments_GroupActivity ON Equipments_GroupActivity.GroupActivityID = GroupActivities.ID " +
                "INNER JOIN Equipments ON Equipments.ID = Equipments_GroupActivity.EquipmentID";
            using var equipment_cmd = new NpgsqlCommand(equipment_activity_sql, con);
            using NpgsqlDataReader equipment_activity_reader = equipment_cmd.ExecuteReader();
            while (equipment_activity_reader.Read())
            {
                int GA_id = equipment_activity_reader.GetInt32(0);
                string name = equipment_activity_reader.GetString(8);

                for (int i = 0; i < GroupSchedule.groupScheduleList.Count; i++)
                {
                    if (GroupSchedule.groupScheduleList[i].activtyId == GA_id)
                    {
                        foreach (Equipment equipment in Equipment.equipmentList)
                        {
                            if (equipment.name == name)
                            {
                                GroupSchedule.groupScheduleList[i].equipment.Add(equipment);
                            }
                        }
                    }
                }
            }
            equipment_activity_reader.Close();

            string PT_activity_sql = "SELECT * FROM GroupActivities " +
                "INNER JOIN PersonalTrainer_GroupActivity ON PersonalTrainer_GroupActivity.GroupActivityID = GroupActivities.ID " +
                "INNER JOIN PersonalTrainer ON PersonalTrainer.id = PersonalTrainer_GroupActivity.PersonalTrainerID";
            using var PT_cmd = new NpgsqlCommand(PT_activity_sql, con);
            using NpgsqlDataReader pt_activity_reader = PT_cmd.ExecuteReader();
            while (pt_activity_reader.Read())
            {
                int GA_id = equipment_activity_reader.GetInt32(0);
                string name = equipment_activity_reader.GetString(8);

                for (int i = 0; i < GroupSchedule.groupScheduleList.Count; i++)
                {
                    if (GroupSchedule.groupScheduleList[i].activtyId == GA_id)
                    {
                        foreach (PersonalTrainer personalTrainer in PersonalTrainer.personalTrainers)
                        {
                            if (personalTrainer.name == name)
                            {
                                GroupSchedule.groupScheduleList[i].personalTrainer.Add(personalTrainer);
                            }
                        }
                    }
                }

            }
            pt_activity_reader.Close();
        }
        public static void saveNewGroupActivity(List<PersonalTrainer> PT, List<Equipment> EQ, GroupActivity temp)
        {
            var cs = "Host=localhost;Username=postgres;Password=Jim861223;Database=gym_db";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            var sql = "INSERT INTO GroupActivities (TypeOfActivity,ParticipantLimit,TimeSlot) VALUES(@TypeOfActivity, @ParticipantLimit, @TimeSlot) RETURNING ID";
            using var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("TypeOfActivity", temp.typeOfActivity);
            cmd.Parameters.AddWithValue("ParticipantLimit", temp.participantLimit);
            cmd.Parameters.AddWithValue("TimeSlot", temp.timeSlot);
            cmd.Prepare();
            //cmd.ExecuteNonQuery();
            int groupActivityId = Convert.ToInt32(cmd.ExecuteScalar());

            foreach (Equipment equipment in EQ)
            {
                var equipmentSql = "INSERT INTO Equipments_GroupActivity (EquipmentID, GroupActivityID) " +
                   "VALUES ((SELECT ID FROM Equipments WHERE Name = @EquipmentName), @GroupActivityID)";
                using var equipmentCmd = new NpgsqlCommand(equipmentSql, con);
                equipmentCmd.Parameters.AddWithValue("EquipmentName", equipment.name);
                equipmentCmd.Parameters.AddWithValue("GroupActivityID", groupActivityId);
                equipmentCmd.ExecuteNonQuery();

            }

            foreach (PersonalTrainer personalTrainer in PT)
            {
                var trainerSql = "INSERT INTO PersonalTrainer_GroupActivity (PersonalTrainerID, GroupActivityID) " +
                    "VALUES ((SELECT ID FROM PersonalTrainer WHERE Name = @PersonalTrainerName), @GroupActivityID)";
                using var trainerCmd = new NpgsqlCommand(trainerSql, con);
                trainerCmd.Parameters.AddWithValue("PersonalTrainerName", personalTrainer.name);
                trainerCmd.Parameters.AddWithValue("GroupActivityID", groupActivityId);
                trainerCmd.ExecuteNonQuery();
            }

            var spaceSql = "INSERT INTO space_groupactivity(Space_ID, GroupActivityID) VALUES((SELECT space_id FROM spaces WHERE Name = @SpaceName), @GroupActivityID)";
            using var spaceCmd = new NpgsqlCommand(spaceSql, con);
            spaceCmd.Parameters.AddWithValue("SpaceName", temp.space.name);
            spaceCmd.Parameters.AddWithValue("GroupActivityID", groupActivityId);
            spaceCmd.ExecuteNonQuery();
        }
    }
}

