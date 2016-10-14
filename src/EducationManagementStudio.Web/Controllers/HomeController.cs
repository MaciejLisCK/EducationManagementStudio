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
            var currentStudent = await _studentManager.GetUserAsync(HttpContext.User);
            var currentTeacher = await _teacherManager.GetUserAsync(HttpContext.User);

            bool isStudentLogged = currentStudent != null;
            bool isTeacherLogged = currentTeacher != null;
            if (isStudentLogged)
                return RedirectToAction<CourseController>(nameof(CourseController.ListForStudent));
            else if (isTeacherLogged)
                return RedirectToAction<CourseController>(nameof(CourseController.ListForTeacher));
            else
                return RedirectToAction<CourseController>(nameof(AccountController.Login));
        }
    }
}
