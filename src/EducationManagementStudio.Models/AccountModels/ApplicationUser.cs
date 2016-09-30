using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationManagementStudio.Models.AccountModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(256)]
        public string FirstName { get; set; }
        [Required, StringLength(256)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string MiddleName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                bool hasMiddleName = String.IsNullOrWhiteSpace(MiddleName);

                var fullName = FirstName;
                if (hasMiddleName)
                    fullName += " " + MiddleName;
                fullName += LastName;

                return fullName;
            }

        }
    }
}
