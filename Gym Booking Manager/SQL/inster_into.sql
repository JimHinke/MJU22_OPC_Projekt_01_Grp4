INSERT INTO PersonalTrainer (name, trainerCategory, availability,owner_id,timeSlot)
VALUES ('John Doe', 1,1,null,null);
INSERT INTO PersonalTrainer (name, trainerCategory, availability,owner_id,timeSlot)
VALUES ('Johan Person', 2,1,null,null);
INSERT INTO PersonalTrainer (name, trainerCategory, availability,owner_id,timeSlot)
VALUES ('Erik Franzon', 3,1,null,null);

INSERT INTO Equipments (Name, EquipmentType, EquipmentCategory, Availability, TimeSlot, OwnerID, TimeSlotsReserved)
VALUES ('Treadmill', 1, 1, 1, null, null, null);
INSERT INTO Equipments (Name, EquipmentType, EquipmentCategory, Availability, TimeSlot, OwnerID, TimeSlotsReserved)
VALUES ('TennisRacket', 2, 2, 1, null, null, null);
INSERT INTO Equipments (Name, EquipmentType, EquipmentCategory, Availability, TimeSlot, OwnerID, TimeSlotsReserved)
VALUES ('RowingMachine', 1, 3, 1, null, null, null);

INSERT INTO Spaces (Name, SpaceCategory, Availability, TimeSlot, OwnerID, TimeSlotsReserved)
VALUES ('Hall', 1, 1, null, null, null);
INSERT INTO Spaces (Name, SpaceCategory, Availability, TimeSlot, OwnerID, TimeSlotsReserved)
VALUES ('Lane', 2, 1, null, null, null);
INSERT INTO Spaces (Name, SpaceCategory, Availability, TimeSlot, OwnerID, TimeSlotsReserved)
VALUES ('Studio', 3, 1, null, null, null);