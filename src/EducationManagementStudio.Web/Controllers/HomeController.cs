using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Data;
using System.Security.Claims;
using EducationManagementStudio.Models.AccountModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EducationManagementStudio.Common;

namespace EducationManagementStudio.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Student> _studentManager;
        private readonly UserManager<Teacher> _teacherManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            ApplicationDbContext db,
            UserManager<Teacher> teacherManager,
            UserManager<ApplicationUser> userManager,
            UserManager<Student> studentManager)
        {
            _db = db;
            _studentManager = studentManager;
            _teacherManager = teacherManager;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentTeacher = await _teacherManager.GetUserAsync(HttpContext.User);

            bool isTeacherLogged = currentTeacher != null;
            if (isTeacherLogged)
                return RedirectToAction<CourseController>(nameof(CourseController.ListForTeacher));
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction<CourseController>(nameof(AccountController.Login));


            var currentStudent = await _studentManager.GetUserAsync(HttpContext.User);

            var appliedCoursesByUser = _db.Student
                .Include(s => s.CoursesToStudents)
                .ThenInclude(cts => cts.Course)
                .Single(s => s.Id == currentStudent.Id)
                .CoursesToStudents
                .Select(cts => cts.Course)
                .ToList();

            var appliedCoursesByGroup = _db.Student
                .Include(s => s.Group)
                .ThenInclude(g => g.CoursesToGroups)
                .ThenInclude(ctg => ctg.Course)
                .Single(s => s.Id == currentStudent.Id)
                .Group
                .CoursesToGroups
                .Select(ctg => ctg.Course)
                .ToList();

            var appliedCourses = appliedCoursesByUser.Union(appliedCoursesByGroup).ToList();

            return View(appliedCourses);
        }
    }
}
