using EducationManagementStudio.Models.CustomPageContentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageModels
{
    public class CustomPageToCustomPageContent
    {
        public int Id { get; set; }
        [Required]
        public CustomPage CustomPage { get; set; }
        [Required]
        public CustomPageContent CustomPageContent { get; set; }
        public int Order { get; set; }
    }
}
