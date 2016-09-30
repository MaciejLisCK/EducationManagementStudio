using EducationManagementStudio.Models.CourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.AccountModels
{
    public class Teacher : ApplicationUser
    {
        public virtual ICollection<Course> CreatedCourses { get; set; }

    }
}
