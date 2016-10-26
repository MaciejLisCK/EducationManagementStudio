using EducationManagementStudio.Models.CustomContentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageModels
{
    public class CustomPageToCustomContent
    {
        public int Id { get; set; }
        [Required]
        public CustomPage CustomPage { get; set; }
        [Required]
        public CustomContent CustomContent { get; set; }

        public int Order { get; set; }
    }
}
