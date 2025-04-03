

CREATE DATABASE StudentInfoDB1;

Use StudentInfoDB;

CREATE TABLE CourseTB (
	courseId int,
    courseName varchar(250),
    Primary Key(courseId)
);

Create Table YearTB(
     yearId  int,
     yearLvl int,
     Primary Key(yearId)
);

INSERT INTO CourseTB (courseId, courseName)
VALUES (1, "IT"), (2, "BSBA"), (3, "ABEL"), (4, "BPA");

INSERT INTO YearTB (yearId, yearLvl)
VALUES (1, 1), (2, 2), (3, 3), (4, 4);

CREATE TABLE StudentRecordTB(
	studentId int,
    firstName varchar(250),
    lastName varchar(250),
    middleName varchar(250),
    houseNo int,
    brgyName varchar(250),
    municipality varchar(250),
    province varchar(250),
    region varchar(250),
    country varchar(250),
    birthdate varchar(250),
    age int,
    studContactNo varchar(250),
    emailAddress varchar(250),
    guardianFirstName varchar(250),
    guardianLastName varchar(250),
    hobbies varchar(250),
    nickname varchar(250),
    courseId int, 
    yearId int,
    Primary Key (studentId),
    foreign key (courseId) References CourseTB(courseId),
	foreign key (yearId) References YearTB(yearId)
);

INSERT INTO StudentRecordTB (studentId, firstName, lastName, middleName, houseNo, brgyName, municipality, province, region, country, birthdate, age, studContactNo, emailAddress, guardianFirstName, guardianLastName, hobbies, nickname, courseId, yearId)
VALUES
(1, 'John', 'Doe', 'M', 101, 'Brgy 1', 'City', 'Province', 'Region', 'Country', '2003-05-12', 22, '09123456789', 'john.doe@email.com', 'Jane', 'Doe', 'Reading', 'Johnny', 1, 2),
(2, 'Jane', 'Smith', 'P', 102, 'Brgy 2', 'Town', 'Province', 'Region', 'Country', '2002-07-23', 23, '09123456780', 'jane.smith@email.com', 'John', 'Smith', 'Writing', 'Janey', 2, 3),
(3, 'Alice', 'Johnson', 'L', 103, 'Brgy 3', 'City', 'Province', 'Region', 'Country', '2001-03-11', 24, '09123456781', 'alice.johnson@email.com', 'Alex', 'Johnson', 'Traveling', 'Ally', 3, 4),
(4, 'Bob', 'Williams', 'R', 104, 'Brgy 4', 'Town', 'Province', 'Region', 'Country', '2000-10-17', 25, '09123456782', 'bob.williams@email.com', 'Bella', 'Williams', 'Gaming', 'Bobby', 4, 1),
(5, 'Charlie', 'Brown', 'K', 105, 'Brgy 5', 'City', 'Province', 'Region', 'Country', '1999-01-29', 26, '09123456783', 'charlie.brown@email.com', 'Cathy', 'Brown', 'Music', 'Charlie', 1, 4);

