using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Departments;
public class EditModel : PageModel
{
    private readonly SchoolContext _context;
    public EditModel(SchoolContext context) => _context = context;
    [BindProperty] public Department Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Item = await _context.Departments.FindAsync(id);
        return Item == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Attach(Item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}