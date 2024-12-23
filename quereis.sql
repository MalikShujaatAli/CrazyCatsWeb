

CREATE TABLE Animals (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Species NVARCHAR(50) NOT NULL, -- e.g., Cat, Dog, Monkey, Lion
    Breed NVARCHAR(50),
    Age INT,
    Description NVARCHAR(MAX),
    IsAdopted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL, -- Store hashed passwords
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Role NVARCHAR(20) NOT NULL DEFAULT 'User ' -- e.g., Admin, User
);

CREATE TABLE AdoptionApplications (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ApplicantName NVARCHAR(100) NOT NULL,
    ApplicantEmail NVARCHAR(100) NOT NULL,
    AnimalId INT NOT NULL,
    Message NVARCHAR(MAX),
    IsApproved BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (AnimalId) REFERENCES Animals(Id) ON DELETE CASCADE
);

CREATE TABLE Images (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Url NVARCHAR(256) NOT NULL, -- URL of the image
    AnimalId INT NOT NULL,
    FOREIGN KEY (AnimalId) REFERENCES Animals(Id) ON DELETE CASCADE
);

Scaffold-DbContext 'Server=DESKTOP-I6UBJ5U\SQLEXPRESS;Database=CrazyCats;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force

select * from Animals