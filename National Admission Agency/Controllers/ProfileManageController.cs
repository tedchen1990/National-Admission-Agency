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
    public class ProfileManageController : Controller
    {

        private NAA.Services.Service.Profile_Service _Profile_Service;
        public ProfileManageController()
        {
            _Profile_Service = new NAA.Services.Service.Profile_Service();
        }

        /*edit Profile*/
        [Authorize(Roles = "Applicant")]
        public ActionResult editProfiles(int id)
        {
            return View(_Profile_Service.getProfile_Details(id));
        }

        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult editProfiles(NAA.Data.Profile profile)
        {
                _Profile_Service.editProfiles(profile);
                return RedirectToAction("getProfile_Details", new { id = profile.ApplicantId, Controller = "Profiles" });

        }

        /*create Profile*/
        [Authorize(Roles = "Applicant")]
        public ActionResult addProfiles()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public ActionResult addProfiles(NAA.Data.Profile profile)
        {
            //System.Text.RegularExpressions.Regex regExp =
            //new System.Text.RegularExpressions.Regex("^[\\p{L} .'-]+$");
            //// validation - ApplicantName
            //if (String.IsNullOrEmpty(profile.ApplicantName))
            //{
            //    ModelState.AddModelError("ApplicantName", "Need an ApplicantName !");
            //}
            //else if (!regExp.IsMatch(profile.ApplicantName))
            //{
            //    ModelState.AddModelError("ApplicantName", "Doesn't look like a name !");
            //}
            //else if (profile.ApplicantName.Length < 2)
            //{
            //    ModelState.AddModelError("ApplicantName", "At least 2 characetrs please!");
            //}
            //else if (profile.ApplicantName.Length > 50)
            //{
            //    ModelState.AddModelError("ApplicantName", "This is too long !");
            //}

            //// validation - ApplicantAddress
            //if (String.IsNullOrEmpty(profile.ApplicantAddress))
            //{
            //    ModelState.AddModelError("ApplicantAddress", "Need an ApplicantAddress !");
            //}

            //// validation - Phone
            //if (String.IsNullOrEmpty(profile.Phone))
            //{
            //    ModelState.AddModelError("Phone", "Need an Phone !");
            //}

            //// validation - Email
            //if (String.IsNullOrEmpty(profile.Email))
            //{
            //    ModelState.AddModelError("Email", "Need an Email !");
            //}

            //if (ModelState.IsValid)
            //{
            //    _Profile_Service.addProfiles(profile);
            //    return RedirectToAction("getProfile_Details", new { id = profile.ApplicantId, Controller = "Profiles" });
            //}
            //else
            //{
            //    return View();
            //}
            profile.UserId = User.Identity.GetUserId();
            _Profile_Service.addProfiles(profile);
            return RedirectToAction("getProfile_Details", new { id = profile.ApplicantId, Controller = "Profiles" });
        }

        /*delete Profile*/
        [Authorize(Roles = "Admin")]
        public ActionResult deleteProfiles(int id)
        {
            return View(_Profile_Service.getProfile_Details(id));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult deleteProfiles(int id,NAA.Data.Profile profile)
        {
            try
            {
                profile = _Profile_Service.getProfile_Details(id);
                _Profile_Service.deleteProfiles(profile);
                return RedirectToAction("getProfiles", new { message = "Delete Success !", Controller = "Profiles" });
            }
            catch
            {
                return View();
            }   
        }
    }
}
