using System.ComponentModel.DataAnnotations;

namespace SchoolAppCoreRazor.Models;

public class Enrollment
{
    public int EnrollmentID { get; set; }

    [Display(Name = "Course")]
    public int CourseID { get; set; }

    [Display(Name = "Student")]
    public int StudentID { get; set; }

    [Range(0, 4)]
    public decimal Grade { get; set; }

    public Course? Course { get; set; }
    public Student? Student { get; set; }
}
