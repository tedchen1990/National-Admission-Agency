using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Services.Serivce
{
    public class UniversityCourseService : University.Services.IService.IUniversityCourseService
    {
        private UniversityofSheffieldReference.SheffieldWebService Sheffield_proxy;
        private HallamUniversityReference.SHUWebService Hallam_proxy;

        public UniversityCourseService()
        {
            Sheffield_proxy = new UniversityofSheffieldReference.SheffieldWebService();
            Hallam_proxy = new HallamUniversityReference.SHUWebService();
        }

        /*Sheffiled Course*/
        public IList<UniversityofSheffieldReference.ShefCourse> GetShefCourses()
        {
            return Sheffield_proxy.SheffCourses();
        }

        //public IList<UniversityofSheffieldReference.ShortSheffCourse> GetShortSheffCourses()
        //{
        //    return Sheffield_proxy.SheffCoursesInShort();
        //}

        /*Hallam Course */
        public IList<HallamUniversityReference.SHUCourse> GetHallamCourses()
        {
            return Hallam_proxy.SHUCourses();
        }

        //public IList<HallamUniversityReference.ShortSHUCourse> GetShortHallamCourses()
        //{
        //    return Hallam_proxy.SHUCoursesInShort();
        //}
    }
}
