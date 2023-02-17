DROP TABLE IF EXISTS PersonalTrainer_GroupActivity;
DROP TABLE IF EXISTS Users_GroupActivity;
DROP TABLE IF EXISTS Equipments_GroupActivity;
DROP TABLE IF EXISTS PersonalTrainer;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS GroupActivities;
DROP TABLE IF EXISTS Spaces;
DROP TABLE IF EXISTS Equipments;

CREATE TABLE PersonalTrainer (
    id BIGSERIAL NOT NULL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    trainerCategory INT,
    availability INT,
    owner_id INT,
    timeSlot VARCHAR(50)
);

CREATE TABLE Users (
    ID BIGSERIAL NOT NULL PRIMARY KEY,
    Name VARCHAR(50)NOT NULL,
    Phone VARCHAR(20)NOT NULL,
    Email VARCHAR(50)NOT NULL,
    AccessLevels INT
);

CREATE TABLE spaces (
    space_id BIGSERIAL NOT NULL PRIMARY KEY,
    Name VARCHAR(50)NOT NULL,
    SpaceCategory INT,
    Availability INT,
    TimeSlot VARCHAR(50),
    OwnerID INT,
    TimeSlotsReserved VARCHAR
);

CREATE TABLE Equipments (
    ID BIGSERIAL NOT NULL PRIMARY KEY,
    Name VARCHAR(50)NOT NULL,
    EquipmentType INT,
    EquipmentCategory INT,
    Availability INT,
    TimeSlot VARCHAR(50),
    OwnerID INT,
    TimeSlotsReserved VARCHAR
);

CREATE TABLE GroupActivities (
    ID BIGSERIAL NOT NULL PRIMARY KEY,
    TypeOfActivity VARCHAR(50)NOT NULL,
    ParticipantLimit INT,
    TimeSlot VARCHAR(50),
    space_id BIGINT REFERENCES spaces(space_id)
);

CREATE TABLE PersonalTrainer_GroupActivity (
PersonalTrainerID INT,
GroupActivityID INT,
PRIMARY KEY (PersonalTrainerID, GroupActivityID),
FOREIGN KEY (PersonalTrainerID) REFERENCES PersonalTrainer (id),
FOREIGN KEY (GroupActivityID) REFERENCES GroupActivities (ID)
);


CREATE TABLE Users_GroupActivity (
UserID INT,
GroupActivityID INT,
PRIMARY KEY (UserID, GroupActivityID),
FOREIGN KEY (UserID) REFERENCES Users (ID),
FOREIGN KEY (GroupActivityID) REFERENCES GroupActivities (ID)
);

CREATE TABLE Equipments_GroupActivity (
EquipmentID INT,
GroupActivityID INT,
PRIMARY KEY (EquipmentID, GroupActivityID),
FOREIGN KEY (EquipmentID) REFERENCES Equipments (ID),
FOREIGN KEY (GroupActivityID) REFERENCES GroupActivities (ID)
);

CREATE TABLE Space_GroupActivity (
Space_ID INT,
GroupActivityID INT,
PRIMARY KEY (Space_ID, GroupActivityID),
FOREIGN KEY (Space_ID) REFERENCES Spaces (space_id),
FOREIGN KEY (GroupActivityID) REFERENCES GroupActivities (ID)
);
