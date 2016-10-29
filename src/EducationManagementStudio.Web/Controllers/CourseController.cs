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
using EducationManagementStudio.Models.CustomPageModels.ViewModels;

namespace EducationManagementStudio.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Teacher> _teacherUserManager;
        private readonly UserManager<Student> _studentManager;

        public CourseController(
            ApplicationDbContext db,
            UserManager<Teacher> teacherUserManager,
            UserManager<Student> studentManager)
        {
            _teacherUserManager = teacherUserManager;
            _studentManager = studentManager;
            _db = db;
        }

        public async Task<IActionResult> ListForTeacher()
        {
            var courses = await _db.Courses.ToListAsync();

            return View(courses);
        }

        public IActionResult View(int id)
        {
            var model = new ViewViewModel();
            model.Course = _db.Courses
                .Include(c => c.CustomContentDescription)
                .Include(c => c.Classes)
                    .ThenInclude(c => c.Test)
                .Include(c => c.Classes)
                    .ThenInclude(c => c.Exercise)
                    .ThenInclude(cp => cp.CustomPagesToCustomContents)
                    .ThenInclude(cptcc => cptcc.CustomContent)
                    .ThenInclude(cc => cc.CustomContentResponses)
                    .ThenInclude(ccr => ccr.Student)
                .Include(c => c.Classes)
                    .ThenInclude(c => c.Exercise)
                    .ThenInclude(cp => cp.CustomPageAccessibilities)
                    .ThenInclude(cpa => cpa.Student)
                .Include(c => c.Classes)
                    .ThenInclude(c => c.Exercise)
                    .ThenInclude(cp => cp.CustomPageAccessibilities)
                    .ThenInclude(cpa => cpa.StudentGroup)
                .Include(c => c.Classes)
                    .ThenInclude(c => c.Report)
                .Include(c => c.Classes)
                    .ThenInclude(c => c.NextClasses)
                .SingleOrDefault(c => c.Id == id);

            model.Student = _db.Student
                .Include(s => s.Group)
                .Single(s => s.UserName == User.Identity.Name);

            return View(model);
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
