using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolAppCoreRazor.Models;

#nullable disable

namespace SchoolAppCoreRazor.Migrations;

[DbContext(typeof(SchoolContext))]
partial class SchoolContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "8.0.25").HasAnnotation("Relational:MaxIdentifierLength", 128);
        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("SchoolAppCoreRazor.Models.Department", b =>
        {
            b.Property<int>("DepartmentID").ValueGeneratedOnAdd().HasColumnType("int");
            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));
            b.Property<decimal>("Budget").HasColumnType("decimal(18,2)");
            b.Property<string>("DepartmentName").IsRequired().HasMaxLength(100).HasColumnType("nvarchar(100)");
            b.Property<DateTime>("StartDate").HasColumnType("datetime2");
            b.HasKey("DepartmentID"); b.ToTable("Departments");
            b.HasData(new { DepartmentID = 1, Budget = 120000m, DepartmentName = "Computer Science", StartDate = new DateTime(2023,1,1) }, new { DepartmentID = 2, Budget = 95000m, DepartmentName = "Mathematics", StartDate = new DateTime(2023,1,1) });
        });
        modelBuilder.Entity("SchoolAppCoreRazor.Models.Instructor", b =>
        {
            b.Property<int>("InstructorID").ValueGeneratedOnAdd().HasColumnType("int"); SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorID"));
            b.Property<string>("FirstName").IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            b.Property<DateTime>("HireDate").HasColumnType("datetime2");
            b.Property<string>("LastName").IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            b.HasKey("InstructorID"); b.ToTable("Instructors");
            b.HasData(new { InstructorID = 1, FirstName = "John", HireDate = new DateTime(2020,8,15), LastName = "Doe" }, new { InstructorID = 2, FirstName = "Alice", HireDate = new DateTime(2021,2,10), LastName = "Brown" });
        });
        modelBuilder.Entity("SchoolAppCoreRazor.Models.Student", b =>
        {
            b.Property<int>("StudentID").ValueGeneratedOnAdd().HasColumnType("int"); SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));
            b.Property<DateTime>("EnrollmentDate").HasColumnType("datetime2");
            b.Property<string>("FirstName").IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            b.Property<string>("LastName").IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            b.HasKey("StudentID"); b.ToTable("Students");
            b.HasData(new { StudentID = 1, EnrollmentDate = new DateTime(2023,9,1), FirstName = "Jane", LastName = "Smith" }, new { StudentID = 2, EnrollmentDate = new DateTime(2024,9,1), FirstName = "David", LastName = "Nguyen" });
        });
        modelBuilder.Entity("SchoolAppCoreRazor.Models.Course", b =>
        {
            b.Property<int>("CourseID").ValueGeneratedOnAdd().HasColumnType("int"); SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));
            b.Property<int>("Credits").HasColumnType("int"); b.Property<int>("DepartmentID").HasColumnType("int");
            b.Property<string>("Title").IsRequired().HasMaxLength(100).HasColumnType("nvarchar(100)");
            b.HasKey("CourseID"); b.HasIndex("DepartmentID"); b.ToTable("Courses");
            b.HasData(new { CourseID = 1, Credits = 3, DepartmentID = 1, Title = "Introduction to Programming" }, new { CourseID = 2, Credits = 4, DepartmentID = 2, Title = "Calculus I" });
        });
        modelBuilder.Entity("SchoolAppCoreRazor.Models.Enrollment", b =>
        {
            b.Property<int>("EnrollmentID").ValueGeneratedOnAdd().HasColumnType("int"); SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"));
            b.Property<int>("CourseID").HasColumnType("int"); b.Property<decimal>("Grade").HasColumnType("decimal(18,2)"); b.Property<int>("StudentID").HasColumnType("int");
            b.HasKey("EnrollmentID"); b.HasIndex("CourseID"); b.HasIndex("StudentID"); b.ToTable("Enrollments");
            b.HasData(new { EnrollmentID = 1, CourseID = 1, Grade = 3.5m, StudentID = 1 }, new { EnrollmentID = 2, CourseID = 2, Grade = 3.8m, StudentID = 2 });
        });
        modelBuilder.Entity("SchoolAppCoreRazor.Models.Course", b => b.HasOne("SchoolAppCoreRazor.Models.Department", "Department").WithMany("Courses").HasForeignKey("DepartmentID").OnDelete(DeleteBehavior.Cascade).IsRequired());
        modelBuilder.Entity("SchoolAppCoreRazor.Models.Enrollment", b => { b.HasOne("SchoolAppCoreRazor.Models.Course", "Course").WithMany("Enrollments").HasForeignKey("CourseID").OnDelete(DeleteBehavior.Cascade).IsRequired(); b.HasOne("SchoolAppCoreRazor.Models.Student", "Student").WithMany("Enrollments").HasForeignKey("StudentID").OnDelete(DeleteBehavior.Cascade).IsRequired(); });
    }
}
