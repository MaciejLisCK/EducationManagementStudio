using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels
{
    public class CustomContentPanel : CustomContent
    {
        public string Heading { get; set; }
        [Required]
        public string Content { get; set; }
        public CustomContentPanelType PanelType { get; set; }
    }
}
