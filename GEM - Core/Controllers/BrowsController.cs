using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GEM.Models;

namespace GEM.Controllers
{
    public class BrowseController : Controller
    {
        // Code needed for full implementation of BrowseController page:
        //  + All events shown on screen in boxes with descriptions, 
        //    either by infinite scrolling webpage or a shortened list;
        //    think Google search results when you think of a snippet
        //  + Each event is clickable, going to an 'About' page which 
        //    lists the details of the selected event
        //
        //  Views needed for MVP functionality: Index, Details

        public IActionResult Index()
        {
            ViewData["Message"] = "Page to show a master list of all events, sorted. TBI";

            return View();
        }

        public IActionResult Details() 
        {
            ViewData["Message"] = "Page to show details about an individual event; Contains\n"
                                + "event name, description, creator, date, etc. TBI";
            int Event = 0;

            // Final data to be passed to view will be data object of type Event, containing
            // all required information necessary for an event. TBI

            return View(Event);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}