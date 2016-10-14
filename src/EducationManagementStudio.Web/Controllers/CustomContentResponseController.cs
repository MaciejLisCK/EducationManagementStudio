using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EducationManagementStudio.Data;
using Microsoft.AspNetCore.Identity;
using EducationManagementStudio.Models.AccountModels;
using Microsoft.EntityFrameworkCore;
using EducationManagementStudio.Models.CustomContentResponseModel;
using EducationManagementStudio.Models.CustomContentModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationManagementStudio.Controllers
{
    [Route("api/[controller]")]
    public class CustomContentResponseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Student> _studentManager;

        public CustomContentResponseController(
            ApplicationDbContext db,
            UserManager<Student> studentManager
            )
        {
            _db = db;
            _studentManager = studentManager;
        }

        [HttpPost]
        public async Task Post([FromBody]CustomContentResponseRequest model)
        {
            var student = await _studentManager.GetUserAsync(HttpContext.User);

            var previousResponse = _db.CustomContentResponse
                .Include(ccr => ccr.Student)
                .Include(ccr => ccr.CustomContent)
                .SingleOrDefault(ccr => ccr.Student == student && ccr.CustomContent.Id == model.ComponentId);

            bool hasPreviousResponse = previousResponse != null;
            if(!hasPreviousResponse)
            {
                var customContentResponse = new CustomContentResponse();
                customContentResponse.AddedDate = model.DateSent;
                customContentResponse.CustomContent = _db.CustomContent.Single(c=>c.Id == model.ComponentId);
                customContentResponse.Student = student;
                customContentResponse.Value = model.Value;

                _db.CustomContentResponse.Add(customContentResponse);
                _db.SaveChanges();
                return;
            }

            bool isNewer = previousResponse.AddedDate <= model.DateSent;
            if(isNewer)
            {
                previousResponse.Value = model.Value;
                previousResponse.AddedDate = model.DateSent;
                _db.SaveChanges();
                return;
            }
        }

        public class ApiRequestBase
        {
            public DateTime DateSent { get; set; }
        }

        public class CustomContentResponseRequest :ApiRequestBase
        {
            public string Value { get; set; }
            public int ComponentId { get; set; }
        }
    }
}
