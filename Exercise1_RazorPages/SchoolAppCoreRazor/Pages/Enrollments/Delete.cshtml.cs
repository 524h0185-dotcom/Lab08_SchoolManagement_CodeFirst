using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Enrollments;
public class DeleteModel : PageModel
{
    private readonly SchoolContext _context;
    public DeleteModel(SchoolContext context) => _context = context;
    [BindProperty] public Enrollment Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id) { Item = await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(e => e.EnrollmentID == id); return Item == null ? NotFound() : Page(); }
    public async Task<IActionResult> OnPostAsync() { var item = await _context.Enrollments.FindAsync(Item.EnrollmentID); if (item != null) { _context.Enrollments.Remove(item); await _context.SaveChangesAsync(); } return RedirectToPage("Index"); }
}