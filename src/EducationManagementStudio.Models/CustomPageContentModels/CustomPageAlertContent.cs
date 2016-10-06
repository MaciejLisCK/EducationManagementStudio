using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageContentModels
{
    public class CustomPageAlertContent : CustomPageContent
    {
        [Required]
        public string Content { get; set; }
        public CustomPageAlertContentType? AlertType { get; set; }
    }
}
