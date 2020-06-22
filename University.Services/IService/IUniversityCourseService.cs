using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Services.IService
{
    interface IUniversityCourseService
    {
        /* Sheffiled */
        IList<UniversityofSheffieldReference.ShefCourse> GetShefCourses();
        //IList<UniversityofSheffieldReference.ShortSheffCourse> GetShortSheffCourses();

        /*Hallam*/
        IList<HallamUniversityReference.SHUCourse> GetHallamCourses();
        //IList<HallamUniversityReference.ShortSHUCourse> GetShortHallamCourses();
    }
}
