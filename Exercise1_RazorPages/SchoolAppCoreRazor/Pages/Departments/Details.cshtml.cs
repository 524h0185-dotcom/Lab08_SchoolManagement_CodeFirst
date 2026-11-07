using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Departments;
public class DetailsModel : PageModel
{
    private readonly SchoolContext _context;
    public DetailsModel(SchoolContext context) => _context = context;
    [BindProperty] public Department Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Item = await _context.Departments.FindAsync(id);
        return Item == null ? NotFound() : Page();
    }
}