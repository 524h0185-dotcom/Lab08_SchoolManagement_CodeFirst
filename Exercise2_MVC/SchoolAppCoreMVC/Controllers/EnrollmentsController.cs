using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolAppCoreMVC.Models;
namespace SchoolAppCoreMVC.Controllers;
public class EnrollmentsController : Controller
{
    private readonly SchoolContext _context;
    public EnrollmentsController(SchoolContext context) => _context = context;
    public async Task<IActionResult> Index() => View(await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).AsNoTracking().ToListAsync());
    public IActionResult Create() { LoadOptions(); return View(); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Enrollment item) { if (!ModelState.IsValid) { LoadOptions(item.StudentID, item.CourseID); return View(item); } _context.Add(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Edit(int id) { var item = await _context.Enrollments.FindAsync(id); if (item == null) return NotFound(); LoadOptions(item.StudentID, item.CourseID); return View(item); }
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Enrollment item) { if (id != item.EnrollmentID) return NotFound(); if (!ModelState.IsValid) { LoadOptions(item.StudentID, item.CourseID); return View(item); } _context.Update(item); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
    public async Task<IActionResult> Details(int id) { var item = await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).AsNoTracking().FirstOrDefaultAsync(e => e.EnrollmentID == id); return item == null ? NotFound() : View(item); }
    public async Task<IActionResult> Delete(int id) { var item = await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).AsNoTracking().FirstOrDefaultAsync(e => e.EnrollmentID == id); return item == null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) { var item = await _context.Enrollments.FindAsync(id); if (item != null) { _context.Enrollments.Remove(item); await _context.SaveChangesAsync(); } return RedirectToAction(nameof(Index)); }
    private void LoadOptions(int? student = null, int? course = null)
    {
        var students = _context.Students.Select(s => new { s.StudentID, Name = s.StudentID + " - " + s.FirstName + " " + s.LastName }).ToList();
        var courses = _context.Courses.Select(c => new { c.CourseID, Name = c.CourseID + " - " + c.Title }).ToList();
        ViewBag.StudentID = new SelectList(students, "StudentID", "Name", student);
        ViewBag.CourseID = new SelectList(courses, "CourseID", "Name", course);
    }
}
