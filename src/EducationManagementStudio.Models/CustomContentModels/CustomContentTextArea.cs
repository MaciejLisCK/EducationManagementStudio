using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels
{
    public class CustomContentTextArea : CustomContent
    {
        [Required]
        public int RowsCount { get; set; }
        public string Placeholder { get; set; }
    }
}
