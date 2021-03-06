﻿using EducationManagementStudio.Models.CourseModels;
using EducationManagementStudio.Models.CustomContentResponseModel;
using EducationManagementStudio.Models.CustomPageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentModels
{
    public class CustomContent
    {
        public int Id { get; set; }
        public virtual ICollection<CustomPageToCustomContent> CustomPagesToCustomContents { get; set; }
        public Course CourseCustomDescription { get; set; }

        public virtual ICollection<CustomContentResponse> CustomContentResponses { get; set; }
    }
}
