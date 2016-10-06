using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Models.CustomPageContentModels.ViewModels;
using EducationManagementStudio.Data;
using EducationManagementStudio.Models.CustomPageContentModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationManagementStudio.Controllers
{
    public class CustomPageContentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomPageContentController(
            ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult AddPanel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPanel(CustomPagePanelContentViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var panelContent = new CustomPagePanelContent();
            panelContent.Heading = model.Heading;
            panelContent.Content = model.Content;

            _db.CustomPagePanelContent.Add(panelContent);

            await _db.SaveChangesAsync();

            return View();
        }


        public IActionResult AddAlert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAlert(CustomPageAlertContentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var alertContent = new CustomPageAlertContent();
            alertContent.Content = model.Content;
            alertContent.AlertType = model.AlertType;

            _db.CustomPageAlertContent.Add(alertContent);

            await _db.SaveChangesAsync();

            return View();
        }

    }
}
