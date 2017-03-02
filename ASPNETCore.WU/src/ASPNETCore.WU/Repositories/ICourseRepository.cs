using ASPNETCore.WU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.WU.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<CourseModel> GetCourses();
    }
}
