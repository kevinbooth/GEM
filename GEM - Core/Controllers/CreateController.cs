using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GEM.Models;

namespace GEM.Controllers
{
    public class CreateController : Controller
    {
        // Code needed for full implementation of CreateController page:
        //  + Basic HTML or other form used to fill out basic data for
        //    an event. Required fields include title, creator, date,
        //    description, and location.
        //  + A successful event creation pushes the active webpage to 
        //    the basic browsing page for an event: Browse/[EventID]
        //
        // Views needed for MVP functionality: Index
        public IActionResult Index()
        {
            ViewData["Message"] = "Page that has a form to create a new event. TBI";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}