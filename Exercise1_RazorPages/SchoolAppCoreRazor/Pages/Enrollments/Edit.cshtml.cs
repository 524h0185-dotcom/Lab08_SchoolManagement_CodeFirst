using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Enrollments;
public class EditModel : PageModel
{
    private readonly SchoolContext _context;
    public EditModel(SchoolContext context) => _context = context;
    [BindProperty] public Enrollment Item { get; set; } = new();
    public List<SelectListItem> StudentOptions { get; set; } = new();
    public List<SelectListItem> CourseOptions { get; set; } = new();
    public async Task<IActionResult> OnGetAsync(int id) { Item = await _context.Enrollments.FindAsync(id); if (Item == null) return NotFound(); LoadOptions(); return Page(); }
    public async Task<IActionResult> OnPostAsync() { if (!ModelState.IsValid) { LoadOptions(); return Page(); } _context.Attach(Item).State = Microsoft.EntityFrameworkCore.EntityState.Modified; await _context.SaveChangesAsync(); return RedirectToPage("Index"); }
    private void LoadOptions()
    {
        StudentOptions = _context.Students.Select(s => new SelectListItem { Value = s.StudentID.ToString(), Text = s.StudentID + " - " + s.FirstName + " " + s.LastName }).ToList();
        CourseOptions = _context.Courses.Select(c => new SelectListItem { Value = c.CourseID.ToString(), Text = c.CourseID + " - " + c.Title }).ToList();
    }
}