using EducationManagementStudio.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.AccountModels
{
    public class Student : ApplicationUser
    {
        [Required, StringLength(20)]
        public string IndexNumber { get; set; }
        [Required]
        public StudentGroup Group { get; set; }
        public virtual ICollection<Course> EnrolledCourses { get; set; }
    }
}
