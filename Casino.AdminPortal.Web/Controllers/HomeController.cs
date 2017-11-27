using Casino.AdminPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casino.AdminPortal.Shared;
using Nagarro.EmployeePortal.Web.Shared;

namespace Casino.AdminPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       /*public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
    }
}