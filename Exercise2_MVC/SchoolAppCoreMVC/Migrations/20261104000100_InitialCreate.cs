using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolAppCoreMVC.Models;

#nullable disable

namespace SchoolAppCoreMVC.Migrations;

[DbContext(typeof(SchoolContext))]
[Migration("20261104000100_InitialCreate")]
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Departments",
            columns: table => new
            {
                DepartmentID = table.Column<int>(
                    type: "int",
                    nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                DepartmentName = table.Column<string>(
                    type: "nvarchar(100)",
                    maxLength: 100,
                    nullable: false),

                Budget = table.Column<decimal>(
                    type: "decimal(18,2)",
                    nullable: false),

                StartDate = table.Column<DateTime>(
                    type: "datetime2",
                    nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey(
                    "PK_Departments",
                    x => x.DepartmentID);
            });

        migrationBuilder.CreateTable(
            name: "Instructors",
            columns: table => new
            {
                InstructorID = table.Column<int>(
                    type: "int",
                    nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                LastName = table.Column<string>(
                    type: "nvarchar(50)",
                    maxLength: 50,
                    nullable: false),

                FirstName = table.Column<string>(
                    type: "nvarchar(50)",
                    maxLength: 50,
                    nullable: false),

                HireDate = table.Column<DateTime>(
                    type: "datetime2",
                    nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey(
                    "PK_Instructors",
                    x => x.InstructorID);
            });

        migrationBuilder.CreateTable(
            name: "Students",
            columns: table => new
            {
                StudentID = table.Column<int>(
                    type: "int",
                    nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                LastName = table.Column<string>(
                    type: "nvarchar(50)",
                    maxLength: 50,
                    nullable: false),

                FirstName = table.Column<string>(
                    type: "nvarchar(50)",
                    maxLength: 50,
                    nullable: false),

                EnrollmentDate = table.Column<DateTime>(
                    type: "datetime2",
                    nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey(
                    "PK_Students",
                    x => x.StudentID);
            });

        migrationBuilder.CreateTable(
            name: "Courses",
            columns: table => new
            {
                CourseID = table.Column<int>(
                    type: "int",
                    nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                Title = table.Column<string>(
                    type: "nvarchar(100)",
                    maxLength: 100,
                    nullable: false),

                Credits = table.Column<int>(
                    type: "int",
                    nullable: false),

                DepartmentID = table.Column<int>(
                    type: "int",
                    nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey(
                    "PK_Courses",
                    x => x.CourseID);

                table.ForeignKey(
                    name: "FK_Courses_Departments_DepartmentID",
                    column: x => x.DepartmentID,
                    principalTable: "Departments",
                    principalColumn: "DepartmentID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Enrollments",
            columns: table => new
            {
                EnrollmentID = table.Column<int>(
                    type: "int",
                    nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),

                CourseID = table.Column<int>(
                    type: "int",
                    nullable: false),

                StudentID = table.Column<int>(
                    type: "int",
                    nullable: false),

                Grade = table.Column<decimal>(
                    type: "decimal(18,2)",
                    nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey(
                    "PK_Enrollments",
                    x => x.EnrollmentID);

                table.ForeignKey(
                    name: "FK_Enrollments_Courses_CourseID",
                    column: x => x.CourseID,
                    principalTable: "Courses",
                    principalColumn: "CourseID",
                    onDelete: ReferentialAction.Cascade);

                table.ForeignKey(
                    name: "FK_Enrollments_Students_StudentID",
                    column: x => x.StudentID,
                    principalTable: "Students",
                    principalColumn: "StudentID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Departments",
            columns: new[]
            {
                "DepartmentID",
                "Budget",
                "DepartmentName",
                "StartDate"
            },
            columnTypes: new[]
            {
                "int",
                "decimal(18,2)",
                "nvarchar(100)",
                "datetime2"
            },
            values: new object[,]
            {
                {
                    1,
                    120000m,
                    "Computer Science",
                    new DateTime(2023, 1, 1)
                },
                {
                    2,
                    95000m,
                    "Mathematics",
                    new DateTime(2023, 1, 1)
                }
            });

        migrationBuilder.InsertData(
            table: "Instructors",
            columns: new[]
            {
                "InstructorID",
                "FirstName",
                "HireDate",
                "LastName"
            },
            columnTypes: new[]
            {
                "int",
                "nvarchar(50)",
                "datetime2",
                "nvarchar(50)"
            },
            values: new object[,]
            {
                {
                    1,
                    "John",
                    new DateTime(2020, 8, 15),
                    "Doe"
                },
                {
                    2,
                    "Alice",
                    new DateTime(2021, 2, 10),
                    "Brown"
                }
            });

        migrationBuilder.InsertData(
            table: "Students",
            columns: new[]
            {
                "StudentID",
                "EnrollmentDate",
                "FirstName",
                "LastName"
            },
            columnTypes: new[]
            {
                "int",
                "datetime2",
                "nvarchar(50)",
                "nvarchar(50)"
            },
            values: new object[,]
            {
                {
                    1,
                    new DateTime(2023, 9, 1),
                    "Jane",
                    "Smith"
                },
                {
                    2,
                    new DateTime(2024, 9, 1),
                    "David",
                    "Nguyen"
                }
            });

        migrationBuilder.InsertData(
            table: "Courses",
            columns: new[]
            {
                "CourseID",
                "Credits",
                "DepartmentID",
                "Title"
            },
            columnTypes: new[]
            {
                "int",
                "int",
                "int",
                "nvarchar(100)"
            },
            values: new object[,]
            {
                {
                    1,
                    3,
                    1,
                    "Introduction to Programming"
                },
                {
                    2,
                    4,
                    2,
                    "Calculus I"
                }
            });

        migrationBuilder.InsertData(
            table: "Enrollments",
            columns: new[]
            {
                "EnrollmentID",
                "CourseID",
                "Grade",
                "StudentID"
            },
            columnTypes: new[]
            {
                "int",
                "int",
                "decimal(18,2)",
                "int"
            },
            values: new object[,]
            {
                { 1, 1, 3.5m, 1 },
                { 2, 2, 3.8m, 2 }
            });

        migrationBuilder.CreateIndex(
            name: "IX_Courses_DepartmentID",
            table: "Courses",
            column: "DepartmentID");

        migrationBuilder.CreateIndex(
            name: "IX_Enrollments_CourseID",
            table: "Enrollments",
            column: "CourseID");

        migrationBuilder.CreateIndex(
            name: "IX_Enrollments_StudentID",
            table: "Enrollments",
            column: "StudentID");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Enrollments");
        migrationBuilder.DropTable(name: "Instructors");
        migrationBuilder.DropTable(name: "Courses");
        migrationBuilder.DropTable(name: "Students");
        migrationBuilder.DropTable(name: "Departments");
    }
}