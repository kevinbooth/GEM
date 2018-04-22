using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GEM.Models;
using GEM.Services;

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

        private readonly IEventService _eventService;
        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var listOfEvents = await _eventService.GetEventsAsync();
            listOfEvents = listOfEvents.OrderBy(x => x.DateAndTime);

            var model = new EventViewModel()
            {
                Events = listOfEvents
            };

            return View(model);
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
