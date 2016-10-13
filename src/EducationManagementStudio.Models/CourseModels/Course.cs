using EducationManagementStudio.Models.AccountModels;
using EducationManagementStudio.Models.ClassModels;
using EducationManagementStudio.Models.CustomPageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CourseModels
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public Teacher Creator { get; set; }
        [Required, StringLength(256)]
        public string Name { get; set; }
        [MaxLength]
        public string Description { get; set; }

        public virtual ICollection<CourseToStudent> CoursesToStudents { get; set; }
        public virtual ICollection<CourseToGroup> CoursesToGroups { get; set; }
        public virtual ICollection<Class> Classes { get; set; }

        [NotMapped]
        public IEnumerable<Student> EnrolledStudents
        {
            get
            {
                return CoursesToStudents.Select(cts => cts.Student);
            }
        }
    }
}
