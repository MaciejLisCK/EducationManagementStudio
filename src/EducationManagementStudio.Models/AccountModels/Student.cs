using EducationManagementStudio.Models.CourseModels;
using EducationManagementStudio.Models.CustomContentResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.AccountModels
{
    public class Student : ApplicationUser
    {
        [Required, StringLength(20)]
        public string IndexNumber { get; set; }
        [Required]
        public bool IsYearRepresentative { get; set; }
        [Required]
        public StudentGroup Group { get; set; }

        public virtual ICollection<CourseToStudent> CoursesToStudents { get; set; }
        public virtual ICollection<CustomContentResponse> CustomContentResponses { get; set; }
        
        [NotMapped]
        public IEnumerable<Course> EnrolledCourses
        {
            get
            {
                return CoursesToStudents.Select(cts => cts.Course);
            }
        }
    }
}
