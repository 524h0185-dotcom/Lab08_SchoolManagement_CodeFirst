using System.ComponentModel.DataAnnotations;

namespace SchoolAppCoreRazor.Models;

public class Department
{
    public int DepartmentID { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Department Name")]
    public string DepartmentName { get; set; } = string.Empty;

    [Range(0, 999999999)]
    public decimal Budget { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
