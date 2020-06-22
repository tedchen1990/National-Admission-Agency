using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using National_Admission_Agency.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace National_Admission_Agency.Controllers
{
    //[RequireHttps]
    public class ProfilesController : Controller
    {
        private NAA.Services.Service.Profile_Service _Profile_Service;

        public ProfilesController()
        {
            _Profile_Service = new NAA.Services.Service.Profile_Service();

        }

        /*get Profile list*/
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult getProfiles(string message)
        {
            ViewBag.message = message;
            return View(_Profile_Service.getProfiles());
        }

        [Authorize(Roles = "Applicant") ]
        public ActionResult searchUserProfile()
        {
            var check = _Profile_Service.checkUserProfile(User.Identity.GetUserId());
            if (check != null)
            {
                
                return RedirectToAction("getProfile_Details", new { id = check.ApplicantId, Controller = "Profiles" });
            }
            else
            {
                return View("CreateProfile");
            }

        }

        [Authorize(Roles = "Applicant")]
        /*get Profile detail*/
        public ActionResult getProfile_Details(int id)
        {
            return View(_Profile_Service.getProfile_Details(id));
        }

        [Authorize(Roles = "Admin,Staff")]
        /* Admin/Staff get Profile detail*/
        public ActionResult AandS_getProfile_Details(int id)
        {
            return View(_Profile_Service.getProfile_Details(id));
        }
    }
}
