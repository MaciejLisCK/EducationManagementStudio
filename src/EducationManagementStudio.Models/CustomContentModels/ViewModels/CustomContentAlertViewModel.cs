using EducationManagementStudio.Models.CustomContentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels.ViewModels
{
    public class CustomContentAlertViewModel
    {
        public string Content { get; set; }
        public CustomContentAlertType AlertType { get; set; }
    }
}
