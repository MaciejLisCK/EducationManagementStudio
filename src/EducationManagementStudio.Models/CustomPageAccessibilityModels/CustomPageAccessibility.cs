using EducationManagementStudio.Models.AccountModels;
using EducationManagementStudio.Models.CustomPageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageAccessibilityModels
{
    public class CustomPageAccessibility
    {
        public int Id { get; set; }
        [Required]
        public CustomPage CustomPage { get; set; }

        public Student Student { get; set; }
        public StudentGroup StudentGroup { get; set; }
        public DateTime StartAccessDateTime { get; set; }
        public DateTime EndAccessDateTime { get; set; }
    }
}
