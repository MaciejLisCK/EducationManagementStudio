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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationManagementStudio.Controllers
{
    [Route("api/[controller]")]
    public class CustomContentResponseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Student> _studentManager;
        private readonly IHostingEnvironment _environment;

        public CustomContentResponseController(
            ApplicationDbContext db,
            UserManager<Student> studentManager,
            IHostingEnvironment environment
            )
        {
            _db = db;
            _studentManager = studentManager;
            _environment = environment;
        }

        [HttpPost]
        public async Task Post([FromBody]CustomContentResponseRequest model)
        {
            var student = await _studentManager.GetUserAsync(HttpContext.User);

            var previousResponse = _db.CustomContentResponses
                .Include(ccr => ccr.Student)
                .Include(ccr => ccr.CustomContent)
                .SingleOrDefault(ccr => ccr.Student == student && ccr.CustomContent.Id == model.ComponentId);

            bool hasPreviousResponse = previousResponse != null;
            if(!hasPreviousResponse)
            {
                var customContentResponse = new CustomContentResponse();
                customContentResponse.UpdatedDate = model.DateSent;
                customContentResponse.CustomContent = _db.CustomContent.Single(c=>c.Id == model.ComponentId);
                customContentResponse.Student = student;
                customContentResponse.TextAreaResponse = model.Value;

                _db.CustomContentResponses.Add(customContentResponse);
                _db.SaveChanges();
                return;
            }

            bool isNewer = previousResponse.UpdatedDate <= model.DateSent;
            if(isNewer)
            {
                previousResponse.TextAreaResponse = model.Value;
                previousResponse.UpdatedDate = model.DateSent;
                _db.SaveChanges();
                return;
            }
        }

        [HttpPost("File/{customContentFileId}")]
        public async Task File(ICollection<IFormFile> files, int customContentFileId)
        {
            var student = await _studentManager.GetUserAsync(HttpContext.User);

            var uploadsPath = Path.Combine(_environment.WebRootPath, "uploads/custom-content");

            var uploadStudentPath = Path.Combine(uploadsPath, student.Id);
            if (!Directory.Exists(uploadStudentPath))
                Directory.CreateDirectory(uploadStudentPath);

            if(files.Count == 1)
            {
                RemoveFilesByNameWithoutExtenstion(customContentFileId.ToString(), uploadStudentPath);

                var file = files.First();
                var fileName = customContentFileId + Path.GetExtension(file.FileName);

                using (var fileStream 
                    = new FileStream(Path.Combine(uploadStudentPath, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }

        private static void RemoveFilesByNameWithoutExtenstion(string name, string path)
        {
            var directory = new DirectoryInfo(path);
            var existingFiles = directory.GetFiles()
                .Where(f => Path.GetFileNameWithoutExtension(f.FullName) == name);
            foreach (var existingFile in existingFiles)
                System.IO.File.Delete(existingFile.FullName);
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
