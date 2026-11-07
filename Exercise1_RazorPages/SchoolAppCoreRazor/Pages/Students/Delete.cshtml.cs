using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Students;
public class DeleteModel : PageModel
{
    private readonly SchoolContext _context;
    public DeleteModel(SchoolContext context) => _context = context;
    [BindProperty] public Student Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Item = await _context.Students.FindAsync(id);
        return Item == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var item = await _context.Students.FindAsync(Item.StudentID);
        if (item != null) { _context.Students.Remove(item); await _context.SaveChangesAsync(); }
        return RedirectToPage("Index");
    }
}