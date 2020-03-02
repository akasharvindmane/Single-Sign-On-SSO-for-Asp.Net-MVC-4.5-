using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using sample2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Claims;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace sample2.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                using (var context = new UserTable())
                {
                    //var userDetails = context.users.Where(x => x.email == User.Identity.Name).FirstOrDefault();
                    //if (userDetails != null)
                    //{
                    //    var name = userDetails.username;
                    //    var role = userDetails.role;
                    //    var email = userDetails.email;

                    //    System.Security.Claims.Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);

                    //    ViewBag.DisplayName = displayName != null ? displayName.Value : string.Empty;
                    //    ViewBag.data = userDetails;
                    //    ViewBag.Message = "You are logged in!!";
                    //}
                    //else
                    //{
                    //        HttpContext.GetOwinContext().Authentication.SignOut(
                    //OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
                    //        ViewBag.Message = "You cannot logged in!!";
                    //}

                    System.Security.Claims.Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);

                    ViewBag.DisplayName = displayName != null ? displayName.Value : string.Empty;
                    //ViewBag.data = userDetails;
                    ViewBag.Message = "You are logged in!!";
                }
            }
            else
            {
                ViewBag.Message = "You are NOT logged in. Please Log in to Continue";
            }
            return View();

        }

        [HttpGet]
        [Authorize(Roles = "Admin, Writer, Approver")]
        public ActionResult Contact()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Approver"))
            {
                ViewBag.Message = "You are logged in!!... showing database data..!!!";
                using (var context = new UserTable())
                {
                    var userDetails = context.users.Where(x => x.email == User.Identity.Name).FirstOrDefault();
                    if (userDetails != null)
                    {
                        user rec = new user
                        {
                            username = userDetails.username,
                            email = userDetails.email,
                            role = userDetails.role
                        };
                        ViewBag.Message = rec;
                    }
                }
            }
            else
            {
                ViewBag.Message = "You do NOT have access to view this data..!!!";
            }
            return View();
        }
    }
}