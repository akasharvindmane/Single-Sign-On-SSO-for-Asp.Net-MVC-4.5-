using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using sample2.Models;

namespace sample2.Controllers
{
    public class AdminController : Controller
    {
        // Sends an OpenIDConnect Sign-In Request. 
        [HttpGet]
        [Authorize(Roles = "Admin, Writer, Approver")]
        public ActionResult About()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Approver"))
            {
                ViewBag.Message = "Your application description page. Logged in as..";
            }
            return View();
        }
    }
}
