-- REFERENCE ONLY. Lab 8 creates these databases through EF Core Code First migrations.
-- Do not run this file before Update-Database.

CREATE TABLE Departments (
    DepartmentID INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL,
    Budget DECIMAL(18,2) NOT NULL,
    StartDate DATETIME2 NOT NULL
);

CREATE TABLE Instructors (
    InstructorID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    HireDate DATETIME2 NOT NULL
);

CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    LastName NVARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    EnrollmentDate DATETIME2 NOT NULL
);

CREATE TABLE Courses (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    DepartmentID INT NOT NULL,
    CONSTRAINT FK_Courses_Departments FOREIGN KEY (DepartmentID)
        REFERENCES Departments(DepartmentID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    CourseID INT NOT NULL,
    StudentID INT NOT NULL,
    Grade DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Enrollments_Courses FOREIGN KEY (CourseID)
        REFERENCES Courses(CourseID),
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentID)
        REFERENCES Students(StudentID)
);
