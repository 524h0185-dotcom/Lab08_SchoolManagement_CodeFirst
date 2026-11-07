using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Students;
public class DetailsModel : PageModel
{
    private readonly SchoolContext _context;
    public DetailsModel(SchoolContext context) => _context = context;
    [BindProperty] public Student Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Item = await _context.Students.FindAsync(id);
        return Item == null ? NotFound() : Page();
    }
}