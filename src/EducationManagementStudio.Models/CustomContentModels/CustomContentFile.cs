using EducationManagementStudio.Models.AccountModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels
{
    public class CustomContentFile : InputCustomContent
    {
        public string Accept { get; set; }
        [Required]
        public string ButtonName { get; set; }
    }
}
