USE Lab6db;
GO

IF OBJECT_ID('rob_taby') IS NOT NULL
 DROP PROC rob_taby;
GO

CREATE PROCEDURE rob_taby
AS
BEGIN
	IF OBJECT_ID('grupa', 'U') IS NOT NULL 
	  DROP TABLE grupa;
    IF OBJECT_ID('student', 'U') IS NOT NULL 
	  DROP TABLE student;    
	IF OBJECT_ID('przedmiot', 'U') IS NOT NULL 
	  DROP TABLE przedmiot; 
	IF OBJECT_ID('wykladowca', 'U') IS NOT NULL 
	  DROP TABLE wykladowca; 
	CREATE TABLE student (id int PRIMARY KEY, fname varchar(30),lname varchar(30));
    CREATE TABLE wykladowca (id int PRIMARY KEY,fname varchar(30),lname varchar(30));
    CREATE TABLE przedmiot (id int PRIMARY KEY,name varchar(50));
    CREATE TABLE grupa (id_wykl int FOREIGN KEY REFERENCES wykladowca(id), id_stud int FOREIGN KEY REFERENCES student(id), id_przed int FOREIGN KEY REFERENCES przedmiot(id), PRIMARY KEY (id_wykl, id_stud, id_przed));
END

