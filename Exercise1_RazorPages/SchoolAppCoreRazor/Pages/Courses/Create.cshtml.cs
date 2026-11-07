using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Courses;
public class CreateModel : PageModel
{
    private readonly SchoolContext _context;
    public CreateModel(SchoolContext context) => _context = context;
    [BindProperty] public Course Item { get; set; } = new();
    public List<SelectListItem> DepartmentOptions { get; set; } = new();
    public void OnGet() => LoadDepartments();
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) { LoadDepartments(); return Page(); }
        _context.Courses.Add(Item);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
    private void LoadDepartments() => DepartmentOptions = _context.Departments.Select(d => new SelectListItem { Value = d.DepartmentID.ToString(), Text = d.DepartmentID + " - " + d.DepartmentName }).ToList();
}