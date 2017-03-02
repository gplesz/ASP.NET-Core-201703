using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.WU.Models;

namespace ASPNETCore.WU.Repositories
{
    public class CourseMockRepository : ICourseRepository
    {
        public IEnumerable<CourseModel> GetCourses()
        {
            return new List<CourseModel>
            {
                new CourseModel { id = 1, Name = "Certified Information Systems Security Pro - CISSP" },
                new CourseModel { id = 2, Name = "Borkollégium mesterkurzus: Tokaj Y Generáció" },
                new CourseModel { id = 3, Name = "Titkosítási ABC" },
                new CourseModel { id = 4, Name = "Windows Stack High Availability" },
                new CourseModel { id = 5, Name = "ASP.NET Core szerveroldali fejlesztés	Ma kezdődik" }
            };
        }
    }
}
