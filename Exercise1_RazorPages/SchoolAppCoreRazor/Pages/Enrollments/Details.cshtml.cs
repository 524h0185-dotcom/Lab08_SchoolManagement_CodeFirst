using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Enrollments;
public class DetailsModel : PageModel
{
    private readonly SchoolContext _context;
    public DetailsModel(SchoolContext context) => _context = context;
    [BindProperty] public Enrollment Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id) { Item = await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).FirstOrDefaultAsync(e => e.EnrollmentID == id); return Item == null ? NotFound() : Page(); }

}