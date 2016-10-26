using EducationManagementStudio.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels
{
    public class CustomContentFile : CustomContent
    {
        public string Accept { get; set; }
        public string Description { get; set; }
    }
}
