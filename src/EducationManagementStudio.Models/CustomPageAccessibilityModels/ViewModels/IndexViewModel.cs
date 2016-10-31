using EducationManagementStudio.Models.AccountModels;
using EducationManagementStudio.Models.CustomPageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageAccessibilityModels.ViewModels
{
    public class IndexViewModel
    {
        public CustomPageAccessibility CustomPageAccessibility { get; set; }
        public IList<CustomPage> CustomPages { get; set; }
        public IList<Student> Students { get; set; }
        public IList<StudentGroup> StudentGroups { get; set; }
        public IList<CustomPageAccessibility> CustomPageAccessibilities { get; set; }
    }
}
