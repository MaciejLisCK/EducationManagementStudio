﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageContentModels
{
    public class CustomPagePanelContent : CustomPageContent
    {
        public string Heading { get; set; }
        [Required]
        public string Content { get; set; }
    }
}