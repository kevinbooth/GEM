using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GEM.Models;
using GEM.Services;

// This is the home controller, allowing for the base level routes.
namespace GEM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventService _eventService;
        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        //Creates the homepage
        public async Task<IActionResult> Index()
        {
            //gets all the events and orders it by date
            var listOfEvents = await _eventService.GetEventsAsync();
            listOfEvents = listOfEvents.OrderBy(x => x.DateAndTime);

            var model = new EventViewModel()
            {
                Events = listOfEvents
            };

            return View(model);
        }

        //Auto-generated controller, allowing for login
        public IActionResult Login()
        {
            ViewData["Message"] = "Page for loggin into existing account for GEM.\n"
                                + "Might end up becoming own controller. TBI";
            return View();
        }

        //Controller for error
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
