using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Controllers
{
    /// <summary>
    /// In an MVC app, don't explicitly decorate the error handler 
    /// action method with HTTP method attributes, such as HttpGet. 
    /// Using explicit verbs could prevent some requests from reaching 
    /// the method.
    /// </summary>

    public class ErrorController : Controller
    {
        [Route("/Error")]
        public IActionResult MyErrorPageAction()
        {


            return View();
        }
    }
}
