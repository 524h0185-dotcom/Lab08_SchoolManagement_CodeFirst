using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolAppCoreRazor.Models;
namespace SchoolAppCoreRazor.Pages.Instructors;
public class CreateModel : PageModel
{
    private readonly SchoolContext _context;
    public CreateModel(SchoolContext context) => _context = context;
    [BindProperty] public Instructor Item { get; set; } = new();
    public void OnGet() { }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();
        _context.Instructors.Add(Item);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}