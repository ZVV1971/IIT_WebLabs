using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace ZVV_Web_Lab_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //[HttpGet]
        public ActionResult Index()
        {
            ViewBag.IndexHelloWorldMessage = "Hello World";
            ViewBag.SL = new SelectList(Enum.GetNames(typeof(KnownColor)).ToList());
            return View();
        }
    }
}