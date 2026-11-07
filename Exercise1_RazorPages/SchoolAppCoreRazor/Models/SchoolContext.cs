using Microsoft.EntityFrameworkCore;

namespace SchoolAppCoreRazor.Models;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentID = 1, DepartmentName = "Computer Science", Budget = 120000m, StartDate = new DateTime(2023, 1, 1) },
            new Department { DepartmentID = 2, DepartmentName = "Mathematics", Budget = 95000m, StartDate = new DateTime(2023, 1, 1) }
        );

        modelBuilder.Entity<Instructor>().HasData(
            new Instructor { InstructorID = 1, FirstName = "John", LastName = "Doe", HireDate = new DateTime(2020, 8, 15) },
            new Instructor { InstructorID = 2, FirstName = "Alice", LastName = "Brown", HireDate = new DateTime(2021, 2, 10) }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { CourseID = 1, Title = "Introduction to Programming", Credits = 3, DepartmentID = 1 },
            new Course { CourseID = 2, Title = "Calculus I", Credits = 4, DepartmentID = 2 }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student { StudentID = 1, FirstName = "Jane", LastName = "Smith", EnrollmentDate = new DateTime(2023, 9, 1) },
            new Student { StudentID = 2, FirstName = "David", LastName = "Nguyen", EnrollmentDate = new DateTime(2024, 9, 1) }
        );

        modelBuilder.Entity<Enrollment>().HasData(
            new Enrollment { EnrollmentID = 1, CourseID = 1, StudentID = 1, Grade = 3.5m },
            new Enrollment { EnrollmentID = 2, CourseID = 2, StudentID = 2, Grade = 3.8m }
        );
    }
}
