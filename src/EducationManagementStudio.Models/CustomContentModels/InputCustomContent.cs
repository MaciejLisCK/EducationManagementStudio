using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels
{
    public class InputCustomContent : CustomContent
    {
        [Required]
        public string Label { get; set; }

        public float MaxPoints { get; set; }
    }
}
