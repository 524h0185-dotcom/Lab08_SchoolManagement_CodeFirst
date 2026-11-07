using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;
namespace SchoolAppCoreMVC.Controllers;
public class StudentsController : Controller
{
    private readonly SchoolContext _context;
    public StudentsController(SchoolContext context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.Students.AsNoTracking().ToListAsync());
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student item) { if (!ModelState.IsValid) return View(item); _context.Students.Add(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var item = await _context.Students.FindAsync(id); return item == null ? NotFound() : View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student item) { if (id != item.StudentID) return NotFound(); if (!ModelState.IsValid) return View(item); _context.Update(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Details(int id) { var item = await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.StudentID == id); return item == null ? NotFound() : View(item); }
    public async Task<IActionResult> Delete(int id) { var item = await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.StudentID == id); return item == null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item = await _context.Students.FindAsync(id); if (item != null) { _context.Students.Remove(item); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
}