using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Models.CustomPageAccessibilityModels;
using EducationManagementStudio.Data;
using Microsoft.EntityFrameworkCore;
using EducationManagementStudio.Models.CourseModels.ViewModels;
using EducationManagementStudio.Models.CustomPageAccessibilityModels.ViewModels;

namespace EducationManagementStudio.Controllers
{
    public class CustomPageAccessibilityController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomPageAccessibilityController(
            ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();

            model.CustomPageAccessibilities = await _db.CustomPageAccessibilities
                .Include(cpa => cpa.CustomPage)
                .Include(cpa => cpa.Student)
                .Include(cpa => cpa.StudentGroup)
                .ToListAsync();

            model.CustomPageAccessibility = model.CustomPageAccessibility ?? new CustomPageAccessibility() { StartAccessDateTime = DateTime.Now, EndAccessDateTime = DateTime.Now.AddMinutes(45 * 4 + 5 + 5 + 15) };

            model.CustomPages = await _db.CustomPage.ToListAsync();
            model.Students = await _db.Student.ToListAsync();
            model.StudentGroups = await _db.StudentGroup.ToListAsync();

            /*
            var allCustomPageAccessibilities = await _db.CustomPageAccessibilities
                .Include(cpa => cpa.CustomPage)
                .Include(cpa => cpa.Student)
                .Include(cpa => cpa.StudentGroup)
                .Include(cpa => cpa.StudentGroup)
                .ToListAsync();
            */
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CustomPageAccessibility model)
        {


            return View(model);
        }
    }
}
