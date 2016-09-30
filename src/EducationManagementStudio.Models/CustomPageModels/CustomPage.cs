using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageModels
{
    public class CustomPage
    {
        public int Id { get; set; }
        public virtual ICollection<CustomPageContent> Contents { get; set; }
        [Required, StringLength(256)]
        public string Title { get; set; }
    }
}
