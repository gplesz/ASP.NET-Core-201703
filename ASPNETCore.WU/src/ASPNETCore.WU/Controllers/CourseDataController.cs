using ASPNETCore.WU.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.WU.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/courses")]
    public class CourseDataController
    {
        private readonly ICourseRepository _repository;

        public CourseDataController(ICourseRepository repository)
        {
            if (repository == null) { throw new ArgumentNullException(nameof(repository)); }
            _repository = repository;
        }

        //[HttpGet("api/courses")]
        [HttpGet]
        public IActionResult GetCourses()
        {
            return new JsonResult(_repository.GetCourses());
        }

        //public IActionResult GetCourses()
        //{
        //    return new JsonResult(new List<object>
        //    {
        //        new { id = 1, Name = "Certified Information Systems Security Pro - CISSP" },
        //        new { id = 2, Name = "Borkollégium mesterkurzus: Tokaj Y Generáció" },
        //        new { id = 3, Name = "Titkosítási ABC" },
        //        new { id = 4, Name = "Windows Stack High Availability" },
        //        new { id = 5, Name = "ASP.NET Core szerveroldali fejlesztés	Ma kezdődik" },
        //    });
        //}
    }
}
