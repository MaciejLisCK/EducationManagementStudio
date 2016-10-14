using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Data;
using EducationManagementStudio.Models.CustomContentModels;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> AddPanel(CustomContentPanel panelContent)
        {
            if(!ModelState.IsValid)
                return View(panelContent);

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
        public async Task<IActionResult> AddAlert(CustomContentAlert alertContent)
        {
            if (!ModelState.IsValid)
                return View(alertContent);

            _db.CustomPageAlertContent.Add(alertContent);

            await _db.SaveChangesAsync();

            return View();
        }

        public IActionResult AddText()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddText(CustomContentText textContent)
        {
            if (!ModelState.IsValid)
                return View(textContent);

            _db.CustomPageTextContent.Add(textContent);

            await _db.SaveChangesAsync();

            return View();
        }

        public IActionResult AddTextArea()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTextArea(CustomContentTextArea textAreaContent)
        {
            if (!ModelState.IsValid)
                return View(textAreaContent);

            _db.CustomPageTextAreaContent.Add(textAreaContent);

            await _db.SaveChangesAsync();

            return View();
        }

    }
}
