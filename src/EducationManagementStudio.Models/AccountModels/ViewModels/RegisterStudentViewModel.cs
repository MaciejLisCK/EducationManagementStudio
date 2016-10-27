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
        [Display(Name = "Numer albumu")]
        public string IndexNumber { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Numer grupy")]
        public string GroupName { get; set; }

        [Required]
        [Display(Name = "Jestem starostą?")]
        public bool IsYearRepresentative { get; set; }
    }
}
