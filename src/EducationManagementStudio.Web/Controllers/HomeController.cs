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

namespace EducationManagementStudio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Student> _studentManager;

        public HomeController(
            ApplicationDbContext db,
            UserManager<Student> studentManager)
        {
            _db = db;
            _studentManager = studentManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
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
