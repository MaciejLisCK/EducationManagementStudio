using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EducationManagementStudio.Models.CourseModels;
using EducationManagementStudio.Models.CustomPageAccessibilityModels;

namespace EducationManagementStudio.Models.AccountModels
{
    public class StudentGroup
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<CourseToGroup> CoursesToGroups { get; set; }
        public virtual ICollection<CustomPageAccessibility> CustomPageAccessibilities { get; set; }
    }
}
