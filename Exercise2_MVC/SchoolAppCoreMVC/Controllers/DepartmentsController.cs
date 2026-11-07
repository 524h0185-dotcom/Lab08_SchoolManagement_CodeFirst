using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;
namespace SchoolAppCoreMVC.Controllers;
public class DepartmentsController : Controller
{
    private readonly SchoolContext _context;
    public DepartmentsController(SchoolContext context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.Departments.AsNoTracking().ToListAsync());
    public IActionResult Create() => View();
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department item) { if (!ModelState.IsValid) return View(item); _context.Departments.Add(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var item = await _context.Departments.FindAsync(id); return item == null ? NotFound() : View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Department item) { if (id != item.DepartmentID) return NotFound(); if (!ModelState.IsValid) return View(item); _context.Update(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Details(int id) { var item = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.DepartmentID == id); return item == null ? NotFound() : View(item); }
    public async Task<IActionResult> Delete(int id) { var item = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.DepartmentID == id); return item == null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item = await _context.Departments.FindAsync(id); if (item != null) { _context.Departments.Remove(item); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
}