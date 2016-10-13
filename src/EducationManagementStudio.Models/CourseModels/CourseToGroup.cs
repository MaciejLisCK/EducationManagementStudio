using EducationManagementStudio.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CourseModels
{
    public class CourseToGroup
    {
        public int Id { get; set; }
        [Required]
        public Course Course { get; set; }
        [Required]
        public StudentGroup Group { get; set; }
    }
}
