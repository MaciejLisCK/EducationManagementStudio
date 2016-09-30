using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using EducationManagementStudio.Data;
using Microsoft.EntityFrameworkCore;
using EducationManagementStudio.Models.Account.ViewModels;
using EducationManagementStudio.Models.AccountModels;

namespace EducationManagementStudio.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserManager<Student> _studentUserManager;
        private readonly UserManager<Teacher> _teacherUserManager;
        private readonly ApplicationDbContext _db;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            UserManager<Student> studentUserManager,
            UserManager<Teacher> teacherUserManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _studentUserManager = studentUserManager;
            _teacherUserManager = teacherUserManager;
            _signInManager = signInManager;
            _db = db;
        }

        [AllowAnonymous]
        public IActionResult RegisterStudent()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = await PrepareRegisterStudentModel(model);

                var createResult = await _studentUserManager.CreateAsync(student, model.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(student, isPersistent: false);

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    foreach (var error in createResult.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task<Student> PrepareRegisterStudentModel(RegisterStudentViewModel model)
        {
            var student = new Student
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                IndexNumber = model.IndexNumber,
            };

            var studentGroup = await _db.StudentGroup.SingleOrDefaultAsync(g => g.Name == model.GroupName);
            if (studentGroup == default(StudentGroup))
                student.Group = new StudentGroup() { Name = model.GroupName };
            return student;
        }
    }
}
