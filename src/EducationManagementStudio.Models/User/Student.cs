using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.User
{
    public class Student : ApplicationUser
    {
        [Required, StringLength(20)]
        public string IndexNumber { get; set; }
        public StudentGroup Group { get; set; }
    }
}
