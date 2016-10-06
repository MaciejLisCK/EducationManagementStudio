using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Data;
using EducationManagementStudio.Models.CourseModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using EducationManagementStudio.Models.CourseModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using EducationManagementStudio.Models.AccountModels;
using Microsoft.EntityFrameworkCore;

namespace EducationManagementStudio.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Teacher> _teacherUserManager;

        public CourseController(
            ApplicationDbContext db,
            UserManager<Teacher> teacherUserManager)
        {
            _teacherUserManager = teacherUserManager;
            _db = db;
        }

        public async Task<IActionResult> List()
        {
            var courses = await _db.Courses
                .Include(c => c.Creator)
                .ToListAsync();

            return View(courses);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _teacherUserManager.GetUserAsync(HttpContext.User);

                var course = new Course();
                course.Name = model.Name;
                course.Description = model.Description;
                course.Creator = currentUser;

                _db.Courses.Add(course);

                await _db.SaveChangesAsync();
            }

            return View(model);
        }
    }
}
