using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GEM.Models;

namespace GEM.Controllers
{
    public class HomeController : Controller
    {
        // Code required for full implementation of HomeController page:
        //  + Short list of events that show recently created events 
        //    or events that will happen soon (~1 week or something)
        //  + Connection to a login page; Authentication required
        //
        // Views needed for MVP functionality: Index, Login(?)

        public IActionResult Index()
        {
            ViewData["Message"] = "Page for landing page of web app. TBI";
            return View();
        }

        public IActionResult Login()
        {
            ViewData["Message"] = "Page for loggin into existing account for GEM.\n"
                                + "Might end up becoming own controller. TBI";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
