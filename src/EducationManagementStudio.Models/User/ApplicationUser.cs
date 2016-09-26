using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EducationManagementStudio.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(256)]
        public string FirstName { get; set; }
        [Required, StringLength(256)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string MiddleName { get; set; }
    }
}
