using EducationManagementStudio.Models.CustomPageContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageContentModels.ViewModels
{
    public class CustomPageAlertContentViewModel
    {
        public string Content { get; set; }
        public CustomPageAlertContentType AlertType { get; set; }
    }
}
