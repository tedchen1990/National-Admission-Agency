using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace National_Admission_Agency.Controllers
{
    //[RequireHttps]
    public class UniversityCouseController : Controller
    {
        private University.Services.Serivce.UniversityCourseService _universityCourseService;


        public UniversityCouseController()
        {
            _universityCourseService = new University.Services.Serivce.UniversityCourseService();
        }

        /* get Sheffiled Course list*/
        [Authorize(Roles = "Applicant")]
        public ActionResult getCourse_1(int applicantID, int uniID)
        {
            ViewBag.ApplicantID = applicantID;
            ViewBag.UniversityID = uniID;
            return View(_universityCourseService.GetShefCourses());
        }

        //public ActionResult getShortSheffCourses()
        //{
        //    return View(_universityCourseService.GetShortSheffCourses());
        //}

        /* get Hallam Course list*/
        [Authorize(Roles = "Applicant")]
        public ActionResult getCourse_2(int applicantID, int uniID)
        {
            ViewBag.ApplicantID = applicantID;
            ViewBag.UniversityID = uniID;
            return View(_universityCourseService.GetHallamCourses());
        }

        //public ActionResult getShortHallamsCourses()
        //{
        //    return View(_universityCourseService.GetShortHallamCourses());
        //}
    }
}