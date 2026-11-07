using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;
namespace SchoolAppCoreMVC.Controllers;
public class CoursesController : Controller
{
    private readonly SchoolContext _context;
    public CoursesController(SchoolContext context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.Courses.Include(c => c.Department).AsNoTracking().ToListAsync());
    public IActionResult Create() { LoadDepartments(); return View(); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course item) { if (!ModelState.IsValid) { LoadDepartments(item.DepartmentID); return View(item); } _context.Add(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var item = await _context.Courses.FindAsync(id); if (item == null) return NotFound(); LoadDepartments(item.DepartmentID); return View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Course item) { if (id != item.CourseID) return NotFound(); if (!ModelState.IsValid) { LoadDepartments(item.DepartmentID); return View(item); } _context.Update(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Details(int id) { var item = await _context.Courses.Include(c => c.Department).AsNoTracking().FirstOrDefaultAsync(c => c.CourseID == id); return item == null ? NotFound() : View(item); }
    public async Task<IActionResult> Delete(int id) { var item = await _context.Courses.Include(c => c.Department).AsNoTracking().FirstOrDefaultAsync(c => c.CourseID == id); return item == null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item = await _context.Courses.FindAsync(id); if (item != null) { _context.Courses.Remove(item); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
    private void LoadDepartments(int? selected = null)
    {
        var items = _context.Departments.Select(d => new { d.DepartmentID, DisplayText = d.DepartmentID + " - " + d.DepartmentName }).ToList();
        ViewBag.DepartmentID = new SelectList(items, "DepartmentID", "DisplayText", selected);
    }
}
