using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace National_Admission_Agency.Controllers
{
    //[RequireHttps]
    public class ApplicationController : Controller
    {
        private NAA.Services.Service.Application_Service _Application_Service;
        public ApplicationController()
        {
            _Application_Service = new NAA.Services.Service.Application_Service();
        }

        /*List all Application*/
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult getApplication(string message)
        {
            ViewBag.message = message;
            return View(_Application_Service.getApplication());
        }



        /*List Application of one student*/
        [Authorize(Roles = "Applicant")]
        public ActionResult getApplicationOfID(int id, string message)
        {
            ViewBag.message = message;
            return View(_Application_Service.StudentApplication(id));
        }

        /* Detail application */
        [Authorize]
        public ActionResult detailApplication(int id,string viewback, string message)
        {
            ViewBag.message = message;
            ViewBag.viewback = viewback;
            return View(_Application_Service.detailApplication(id));
        }

        /*User delete Application*/
        [Authorize (Roles = "Applicant")]
        public ActionResult deleteApplication(int id)
        {
            if (_Application_Service.detailApplication(id).UniversityOffer == "R")
            {
                int ApplicantId = _Application_Service.detailApplication(id).ApplicantId;
                return RedirectToAction("getApplicationOfID", new { id = ApplicantId, message = "Sorry, You can't delete the rejected application !" });
            }
            else
            {
                return View(_Application_Service.detailApplication(id));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult deleteApplication(int id, NAA.Data.Application application)
        {
            try
            {
                application = _Application_Service.detailApplication(id);
                _Application_Service.deleteApplication(application);
                return RedirectToAction("getApplicationOfID", new { id = application.ApplicantId, message = "Deleted successfully. " });
            }
            catch
            {
                return View();
            }
        }

        /*Admin delete Application*/
        [Authorize(Roles = "Admin")]
        public ActionResult AdmindeleteApplication(int id)
        {
            if (_Application_Service.detailApplication(id).UniversityOffer == "R")
            {
                //int ApplicantId = _Application_Service.detailApplication(id).ApplicantId;
                return RedirectToAction("getApplication", new { message = "Sorry, You can't delete the rejected application !" });
            }
            else
            {
                return View(_Application_Service.detailApplication(id));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AdmindeleteApplication(int id, NAA.Data.Application application)
        {
            try
            {
                application = _Application_Service.detailApplication(id);
                _Application_Service.deleteApplication(application);
                return RedirectToAction("getApplication", new { message = "Deleted successfully. " });
            }
            catch
            {
                return View();
            }
        }


        /*create Application*/
        [Authorize(Roles = "Applicant")]
        public ActionResult addApplication(string CourseName, int UniversityId, int ApplicantID)
        {
            ViewBag.ApplicantIDBack = ApplicantID;
            return View();
        }

        [HttpPost]
        public ActionResult addApplication(NAA.Data.Application application)
        {
            try
            {
                application.UniversityOffer = "P";
                _Application_Service.addApplication(application);
                return RedirectToAction("getApplicationOfID", new { id = application.ApplicantId, message = "Created successfully." });
            }
            catch
            {
                return View();
            }
        }

        /* edit Application*/
        [Authorize(Roles = "Applicant")]
        public ActionResult editApplication(int id)
        {
            string state = _Application_Service.detailApplication(id).UniversityOffer.Trim();
            if (state == "P" || state=="R")
            {
                int ApplicantId = _Application_Service.detailApplication(id).ApplicantId;
                return RedirectToAction("getApplicationOfID", new { id = ApplicantId, message = "Sorry, You can't frim for the Pending/Reject application !" });
            }
                return View(_Application_Service.detailApplication(id));
        }

        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult editApplication(NAA.Data.Application application)
        {
            try
            {
                _Application_Service.editApplication(application);
                int i = 0;
                int count = _Application_Service.StudentApplication(application.ApplicantId).Count();
                int trueFirm = 0;
                while (i < count)
                {
                    if (_Application_Service.StudentApplication(application.ApplicantId)[i].Firm == true)
                    {
                        trueFirm = trueFirm + 1;
                    }
                    i++;
                }
                if (trueFirm > 1)
                {
                    application.Firm = null;
                    _Application_Service.editApplication(application);
                    return RedirectToAction("getApplicationOfID", new { id = application.ApplicantId, message = "Sorry, Frim failed! Only one applicatin can be Firmed!" });
                }
                else
                {
                    return RedirectToAction("getApplicationOfID", new { id = application.ApplicantId, message = "Firm successfully." });
                }
               
            }
            catch
            {
                return View();
            }
        }


        /* Admin edit Application*/
        [Authorize(Roles = "Admin")]
        public ActionResult AdminEditApplication(int id)
        {
            return View(_Application_Service.detailApplication(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AdminEditApplication(NAA.Data.Application application)
        {
                _Application_Service.editApplication(application);
                return RedirectToAction("detailApplication", new { id = application.ApplicationId, message ="Update success.",viewback = "AdminAndStaff", Controller = "Application" });
             
        }


    }
}
