using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        /*Index*/
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department)
                .AsNoTracking()
                .ToArray();

            return View(courses);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            ViewData["Vaatetüüp"] = "Create";
            //PopulateDepartmentsDropDownList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                //PopulateDepartmentsDropDownList(course.DepartmentId);
            }
            ViewData["Vaatetüüp"] = "Create";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }
            ViewData["Vaatetüüp"] = "Delete";
            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courses == null)
            {
                return NotFound();
            }
            return View("Details",courses);
         }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["Vaatetüüp"] = "Delete";
            if (_context.Courses == null)
            {
                return NotFound();
            }
            
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Vaatetüüp"] = "Details";
            var course = await _context.Courses.FindAsync(id);
            return View(nameof(Details), course);
        }
        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Vaatetüüp"] = "Edit";
            var course = await _context.Courses.FindAsync(id);
            return View("Create", course);

        }

        [HttpPost, ActionName("EditConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,Title,Credits,DepartmentId")] Course course)
        {
            if (ModelState.IsValid)
            {
                var existingCourse = await _context.Courses.FindAsync(course.ID);
                if (existingCourse == null)
                    return NotFound();

                existingCourse.Title = course.Title;
                existingCourse.Credits = course.Credits;
                existingCourse.DepartmentId = course.DepartmentId;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Vaatetüüp"] = "Edit";
            PopulateDepartmentsDropDownList(course.DepartmentId);
            return View("Create", course);
        }


        private void PopulateDepartmentsDropDownList(object selectedDepartment= null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentId = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentId", "Name", selectedDepartment);
            
        }

    }
}
