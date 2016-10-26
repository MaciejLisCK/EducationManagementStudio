using EducationManagementStudio.Models.AccountModels;
using EducationManagementStudio.Models.CustomContentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomContentResponseModel
{
    public class CustomContentResponse
    {
        public int Id { get; set; }
        [Required]
        public CustomContent CustomContent { get; set; }
        [Required]
        public Student Student { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }

        public string TextAreaResponse { get; set; }
    }
}
