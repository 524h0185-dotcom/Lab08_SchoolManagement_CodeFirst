using System.ComponentModel.DataAnnotations;

namespace SchoolAppCoreRazor.Models;

public class Student
{
    public int StudentID { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Enrollment Date")]
    public DateTime EnrollmentDate { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
