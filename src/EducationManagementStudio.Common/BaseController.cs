using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EducationManagementStudio.Common
{
    public class BaseController : Controller
    {
        public RedirectToActionResult RedirectToAction<TController>(string actionName)
            where TController : Controller
        {
            var controllerFullName = typeof(TController).Name;
            var controllerName = controllerFullName.Substring(0, controllerFullName.LastIndexOf("Controller"));

            return RedirectToAction(actionName, controllerName);
        }
    }
}
