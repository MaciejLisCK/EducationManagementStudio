using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagementStudio.Models.CustomPageModels
{
    public class CustomPageContent
    {
        public int Id { get; set; }
        public CustomPage ParentPage { get; set; }
    }
}
