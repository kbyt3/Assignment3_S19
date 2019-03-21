using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3_S19.Controllers
{
    public class GuidesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Equity()
        {
            return View();
        }

        public ActionResult SPIndex()
        {
            return View();
        }

        public ActionResult FixedIncome()
        {
            return View();
        }

        public ActionResult MutualFunds()
        {
            return View();
        }

        public ActionResult OtherServices()
        {
            return View();
        }
    }
}