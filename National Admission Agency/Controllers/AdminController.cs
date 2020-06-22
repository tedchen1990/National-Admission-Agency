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
    public class AdminController : Controller
    {
        private National_Admission_Agency.Models.ApplicationDbContext _context;

        public AdminController()
        {
            _context = new National_Admission_Agency.Models.ApplicationDbContext();
            
        }
        [Authorize(Roles = "Admin,Staff")]
        public ActionResult AdminAndStaff()
        {
            return View();
        }

        //Display Users
        [Authorize(Roles = "Admin")]
        public ActionResult GetUsers()
        {
            _context.Users.ToList();
            return View(_context.Users.ToList());
        }

        //Display Roles
        [Authorize(Roles = "Admin")]
        public ActionResult GetRoles()
        {
            return View(_context.Roles.ToList());
        } 


        [HttpGet] // Create New Role
        [Authorize(Roles = "Admin")]
        public ActionResult AddRole() { return View(); }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddRole(FormCollection collection)
        {
            try
            {
                Microsoft.AspNet.Identity.EntityFramework.IdentityRole role =
                new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = collection["RoleName"];
                _context.Roles.Add(role);
                _context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet] // Admin for Changing User Roles
        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles()
        {
            //preopulate roles for the view dropdwon
            var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select
                (rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text = rr.Name
                }).ToList();
            ViewBag.Roles = roleList;

            //preopulate users for the view dropdwon
            var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select
                (uu => new SelectListItem
                {
                    Value = uu.UserName.ToString(),
                    Text = uu.UserName
                }).ToList();
            ViewBag.Users = userList;

            return View();
        }
        [HttpPost][ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult ManageUserRoles(string UserName, string RoleName)
        {
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName,
                StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            foreach (string rm in um.GetRoles(user.Id))
            {
                um.RemoveFromRoles(user.Id, rm);
            }
            um.AddToRole(user.Id, RoleName);

            ////preopulate roles for the view dropdwon
            //var roleList = _context.Roles.OrderBy(r => r.Name).ToList().Select
            //    (rr => new SelectListItem
            //    {
            //        Value = rr.Name.ToString(),
            //        Text = rr.Name
            //    }).ToList();
            //ViewBag.Roles = roleList;

            ////preopulate users for the view dropdwon
            //var userList = _context.Users.OrderBy(u => u.UserName).ToList().Select
            //    (uu => new SelectListItem
            //    {
            //        Value = uu.UserName.ToString(),
            //        Text = uu.UserName
            //    }).ToList();
            //ViewBag.Users = userList;

            ViewBag.RolesForThisUser = um.GetRoles(user.Id);
            ViewBag.ThisUser = user.UserName;

            return View("GetRolesforUserConfirmed" );
        }

        [HttpGet] // Displaying Roles for a User
        [Authorize(Roles = "Admin")]
        public ActionResult GetRolesforUser() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult GetRolesforUser(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName,
                 StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                    (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
                if (um.GetRoles(user.Id) != null)
                {
                    ViewBag.RolesForThisUser = um.GetRoles(user.Id);
                }
                    ViewBag.ThisUser = user.UserName; 
            }
                return View("CheakRole");
        }


        
        public ActionResult DifferentPage(string UserName)
        {
            string Role = null;
            string Page = null;
            string controller = null;
            ApplicationUser user = _context.Users.Where(u => u.UserName.Equals(UserName,
                  StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>
                (new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(_context));
            foreach (string rm in um.GetRoles(user.Id))
            {
                Role = rm;
            }

            if (Role == "Applicant")
            {
                Page = "searchUserProfile";
                controller = "Profiles";
            }
            if(Role == "Admin" || Role == "Staff")
            {
                Page = "AdminAndStaff";
                controller = "Admin";
            }
            return RedirectToAction(Page, controller);

        }
    }
}
