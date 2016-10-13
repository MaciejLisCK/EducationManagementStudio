using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Models.CustomContentModels.ViewModels;
using EducationManagementStudio.Data;
using EducationManagementStudio.Models.CustomContentModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationManagementStudio.Controllers
{
    public class CustomContentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CustomContentController(
            ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult AddPanel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPanel(CustomContentPanelViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var panelContent = new CustomContentPanel();
            panelContent.Heading = model.Heading;
            panelContent.Content = model.Content;

            _db.CustomPagePanelContent.Add(panelContent);

            await _db.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> EditPanel(int id)
        {
            var panelContent = await _db.CustomPagePanelContent.SingleAsync(cppc => cppc.Id == id);

            return View(panelContent);
        }

        [HttpPost]
        public async Task<IActionResult> EditPanel(int id, CustomContentPanel panelContent)
        {
            if (!ModelState.IsValid)
                return View(panelContent);

            _db.Update(panelContent);
            await _db.SaveChangesAsync();

            return View();
        }


        public IActionResult AddAlert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAlert(CustomContentAlertViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var alertContent = new CustomContentAlert();
            alertContent.Content = model.Content;
            alertContent.AlertType = model.AlertType;

            _db.CustomPageAlertContent.Add(alertContent);

            await _db.SaveChangesAsync();

            return View();
        }

    }
}
