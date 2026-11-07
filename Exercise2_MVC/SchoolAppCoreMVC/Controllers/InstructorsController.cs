using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;
namespace SchoolAppCoreMVC.Controllers;
public class InstructorsController : Controller
{
    private readonly SchoolContext _context;
    public InstructorsController(SchoolContext context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.Instructors.AsNoTracking().ToListAsync());
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Instructor item) { if (!ModelState.IsValid) return View(item); _context.Instructors.Add(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var item = await _context.Instructors.FindAsync(id); return item == null ? NotFound() : View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Instructor item) { if (id != item.InstructorID) return NotFound(); if (!ModelState.IsValid) return View(item); _context.Update(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Details(int id) { var item = await _context.Instructors.AsNoTracking().FirstOrDefaultAsync(x => x.InstructorID == id); return item == null ? NotFound() : View(item); }
    public async Task<IActionResult> Delete(int id) { var item = await _context.Instructors.AsNoTracking().FirstOrDefaultAsync(x => x.InstructorID == id); return item == null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item = await _context.Instructors.FindAsync(id); if (item != null) { _context.Instructors.Remove(item); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
}