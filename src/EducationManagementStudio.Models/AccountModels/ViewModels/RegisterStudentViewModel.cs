using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.AccountModels.ViewModels
{
    public class RegisterStudentViewModel : RegisterApplicationUserViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Index Number")]
        public string IndexNumber { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name = "Year Representative?")]
        public bool IsYearRepresentative { get; set; }
    }
}
