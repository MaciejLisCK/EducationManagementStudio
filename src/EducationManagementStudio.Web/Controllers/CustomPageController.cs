using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Data;
using Microsoft.EntityFrameworkCore;
using EducationManagementStudio.Models.CustomPageModels.ViewModels;
using EducationManagementStudio.Models.CustomPageModels;
using EducationManagementStudio.Models.CustomContentModels;
using System.Security.Claims;

namespace EducationManagementStudio.Controllers
{
    public class CustomPageController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomPageController(
            ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> View(int id)
        {
            bool isCustomPageUsedAsTestOrExercise = await _db.Classes
                .Include(c => c.Test)
                .Include(c => c.Exercise)
                .AnyAsync(c => c.Test.Id == id || c.Exercise.Id == id);

            if (isCustomPageUsedAsTestOrExercise)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                bool hasAccess = await _db.CustomPageAccessibilities
                    .Include(cpa => cpa.CustomPage)
                    .Include(cpa => cpa.Student)
                    .Include(cpa => cpa.StudentGroup)
                    .ThenInclude(cpa => cpa.Students)
                    .AnyAsync(cpa =>
                        cpa.CustomPage.Id == id &&
                        (cpa.Student.Id == userId || cpa.StudentGroup.Students.Any(s => s.Id == userId)) &&
                        cpa.StartAccessDateTime < DateTime.Now && DateTime.Now < cpa.EndAccessDateTime
                        );

                if (!hasAccess)
                    return Content("No access");
            }

            var customPage = await _db.CustomPage
                .Include(cp => cp.CustomPagesToCustomContents)
                .ThenInclude(cptcpc => cptcpc.CustomContent)
                .ThenInclude(cc => cc.CustomContentResponses)
                .ThenInclude(ccr => ccr.Student)
                .SingleAsync(cp => cp.Id == id);

            return View(customPage);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomPageAddViewModel model)
        {
            if(ModelState.IsValid)
            {
                var customPage = new CustomPage();
                customPage.Title = model.Title;

                _db.CustomPage.Add(customPage);

                await _db.SaveChangesAsync();
            }

            return View(model);
        }

        public async Task<IActionResult> Review(int id)
        {
            var customPage = await _db.CustomPage
                .Include(cp => cp.CustomPagesToCustomContents)
                .ThenInclude(cptcc => cptcc.CustomContent)
                .ThenInclude(cc => cc.CustomContentResponses)
                .ThenInclude(ccr => ccr.Student)
                .SingleAsync(cp => cp.Id == id);

            return View(customPage);
        }
    }
}
