using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.AccountModels.ViewModels
{
    public class RegisterTeacherViewModel : RegisterApplicationUserViewModel
    {
        [Required]
        [Display(Name = "Register Pass Code")]
        public string RegisterPassCode { get; set; }
    }
}
