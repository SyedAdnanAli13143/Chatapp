# Chatapp
Real Time Chat Application with user Authentication


Scaffold-DbContext "Server=yourservername;Database=Signalr;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -NoPluralize -OutputDir EFModels -Tables person, connections -f



Database query : 

create database Signalr

CREATE TABLE Person (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Username NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);
CREATE TABLE Connections (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    PersonId UNIQUEIDENTIFIER NOT NULL,
    SignalrId NVARCHAR(255) NOT NULL,
    TimeStamp DATETIME NOT NULL,
    FOREIGN KEY (PersonId) REFERENCES Person(Id)
);


