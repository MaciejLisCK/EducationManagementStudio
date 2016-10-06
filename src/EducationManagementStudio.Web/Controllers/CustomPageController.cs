using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Data;
using Microsoft.EntityFrameworkCore;
using EducationManagementStudio.Models.CustomPageModels.ViewModels;
using EducationManagementStudio.Models.CustomPageModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
            var customPage = await _db.CustomPage
                .Include(cp => cp.CustomPagesToCustomPageContents)
                .ThenInclude(cptcpc => cptcpc.CustomPageContent) 
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
    }

}
