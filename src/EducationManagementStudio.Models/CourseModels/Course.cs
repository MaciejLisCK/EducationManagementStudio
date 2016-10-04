using EducationManagementStudio.Models.Account;
using EducationManagementStudio.Models.AccountModels;
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
        public virtual ICollection<CourseToStudent> CoursesToStudents { get; set; }
        [Required, StringLength(256)]
        public string Name { get; set; }
        [Required]
        public CustomPage StartPage { get; set; }

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
