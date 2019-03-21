using Assignment3_S19.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Assignment3_S19.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;

        public HomeController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public ActionResult Index()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                HttpContext.Response.Redirect("/Dashboard");
            }
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
