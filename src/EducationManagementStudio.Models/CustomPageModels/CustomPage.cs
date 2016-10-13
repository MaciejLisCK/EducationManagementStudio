using EducationManagementStudio.Models.CustomContentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageModels
{
    public class CustomPage
    {
        public int Id { get; set; }
        [Required, StringLength(256)]
        public string Title { get; set; }
        public virtual ICollection<CustomPageToCustomContent> CustomPagesToCustomContents { get; set; }

        [NotMapped]
        public IEnumerable<CustomContent> Contents
        {
            get
            {
                return CustomPagesToCustomContents.Select(cptcpc => cptcpc.CustomContent);                
            }
        }
    }
}
