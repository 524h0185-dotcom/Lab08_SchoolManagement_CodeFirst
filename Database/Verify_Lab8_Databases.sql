IF DB_ID('SchoolDB_Razor_Lab8') IS NOT NULL
BEGIN
    PRINT 'SchoolDB_Razor_Lab8 exists';
    USE SchoolDB_Razor_Lab8;
    SELECT 'Departments' AS TableName, COUNT(*) AS RowCount FROM Departments
    UNION ALL SELECT 'Instructors', COUNT(*) FROM Instructors
    UNION ALL SELECT 'Courses', COUNT(*) FROM Courses
    UNION ALL SELECT 'Students', COUNT(*) FROM Students
    UNION ALL SELECT 'Enrollments', COUNT(*) FROM Enrollments;
END
ELSE
    PRINT 'SchoolDB_Razor_Lab8 does not exist';
GO

IF DB_ID('SchoolDB_MVC_Lab8') IS NOT NULL
BEGIN
    PRINT 'SchoolDB_MVC_Lab8 exists';
    USE SchoolDB_MVC_Lab8;
    SELECT 'Departments' AS TableName, COUNT(*) AS RowCount FROM Departments
    UNION ALL SELECT 'Instructors', COUNT(*) FROM Instructors
    UNION ALL SELECT 'Courses', COUNT(*) FROM Courses
    UNION ALL SELECT 'Students', COUNT(*) FROM Students
    UNION ALL SELECT 'Enrollments', COUNT(*) FROM Enrollments;
END
ELSE
    PRINT 'SchoolDB_MVC_Lab8 does not exist';
GO
