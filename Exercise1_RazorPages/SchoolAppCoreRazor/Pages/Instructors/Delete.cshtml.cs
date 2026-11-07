using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Instructors;
public class DeleteModel : PageModel
{
    private readonly SchoolContext _context;
    public DeleteModel(SchoolContext context) => _context = context;
    [BindProperty] public Instructor Item { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int id)
    {
        Item = await _context.Instructors.FindAsync(id);
        return Item == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        var item = await _context.Instructors.FindAsync(Item.InstructorID);
        if (item != null) { _context.Instructors.Remove(item); await _context.SaveChangesAsync(); }
        return RedirectToPage("Index");
    }
}