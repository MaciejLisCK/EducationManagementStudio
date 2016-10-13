using EducationManagementStudio.Models.CourseModels;
using EducationManagementStudio.Models.CustomPageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.ClassModels
{
    public class Class
    {
        public int Id { get; set; }

        public Course Course { get; set; }
        public int Order { get; set; }

        [StringLength(1000)]
        public string Topic { get; set; }  
        public CustomPage Test { get; set; }
        public CustomPage Exercise { get; set; }
        public CustomPage Report { get; set; }
        public CustomPage NextClasses { get; set; }
    }
}
