using EducationManagementStudio.Models.CustomPageModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageContentModels
{
    public class CustomPageContent
    {
        public int Id { get; set; }
        public virtual ICollection<CustomPageToCustomPageContent> CustomPagesToCustomPageContents { get; set; }

        [NotMapped]
        public IEnumerable<CustomPage> ParentPages
        {
            get
            {
                return CustomPagesToCustomPageContents.Select(cptcpc => cptcpc.CustomPage);
            }
        }
    }
}
