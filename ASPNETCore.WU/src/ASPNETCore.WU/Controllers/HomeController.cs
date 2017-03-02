using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore.WU.Models;
using ASPNETCore.WU.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETCore.WU.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseRepository _repository;
        // GET: /<controller>/
        public HomeController(ICourseRepository repository)
        {
            if (repository==null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            _repository = repository;
        }
        public IActionResult Index()
        {

            return View(_repository.GetCourses());
        }
    }
}
