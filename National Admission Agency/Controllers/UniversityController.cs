using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace National_Admission_Agency.Controllers
{
    //[RequireHttps]
    public class UniversityController : Controller
    {
        private NAA.Services.Service.University_Service _University_Service;
        public UniversityController()
        {
            _University_Service = new NAA.Services.Service.University_Service();
        }

        /*get Univesity list*/
        [Authorize(Roles = "Applicant")]
        public ActionResult getUniversity(int applicantID)
        {
            ViewBag.ApplicantID = applicantID;
            return View(_University_Service.getUniversity());
        }
    }
}
