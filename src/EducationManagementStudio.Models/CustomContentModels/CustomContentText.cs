﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels
{
    public class CustomContentText : CustomContent
    {
        [Required]
        public string Content { get; set; }
    }
}
