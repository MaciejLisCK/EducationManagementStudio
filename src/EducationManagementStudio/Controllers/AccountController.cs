using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EducationManagementStudio.Models.User;

namespace EducationManagementStudio.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserManager<Student> _studentUserManager;
        private readonly UserManager<Teacher> _teacherUserManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            UserManager<Student> studentUserManager,
            UserManager<Teacher> teacherUserManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _studentUserManager = studentUserManager;
            _teacherUserManager = teacherUserManager;

            _signInManager = signInManager;
        }

        public IActionResult RegisterStudent()
        {
            var student = new Student() { UserName = "stest", Email = "stest@wp.pl", FirstName = "stestFN", LastName = "stestLN", IndexNumber="1234" };
            var createStudentResponse = _studentUserManager.CreateAsync(student, "123!@#qweQWE");

            ViewBag.Result = createStudentResponse.Result.Succeeded;

            return View();
        }
    }
}
