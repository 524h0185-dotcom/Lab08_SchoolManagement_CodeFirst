using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Courses;
public class DetailsModel : PageModel
{
    private readonly SchoolContext _context;
    public DetailsModel(SchoolContext context) => _context = context;
    [BindProperty] public Course Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id) { Item = await _context.Courses.Include(c => c.Department).FirstOrDefaultAsync(c => c.CourseID == id); return Item == null ? NotFound() : Page(); }

}