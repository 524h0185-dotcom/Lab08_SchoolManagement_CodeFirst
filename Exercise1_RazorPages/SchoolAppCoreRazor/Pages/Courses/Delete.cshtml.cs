using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Courses;
public class DeleteModel : PageModel
{
    private readonly SchoolContext _context;
    public DeleteModel(SchoolContext context) => _context = context;
    [BindProperty] public Course Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id) { Item = await _context.Courses.Include(c => c.Department).FirstOrDefaultAsync(c => c.CourseID == id); return Item == null ? NotFound() : Page(); }
    public async Task<IActionResult> OnPostAsync() { var item = await _context.Courses.FindAsync(Item.CourseID); if (item != null) { _context.Courses.Remove(item); await _context.SaveChangesAsync(); } return RedirectToPage("Index"); }
}