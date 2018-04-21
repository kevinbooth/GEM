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

        private readonly IEventService _eventService;
        public BrowseController(IEventService eventService)
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

        //Is called by the URL ~/Browse/Details?id=<id>
        public async Task<IActionResult> Details(Guid id) 
        {
            ViewData["Message"] = "Page to show details about an individual event; Contains\n"
                                + "event name, description, creator, date, etc.";
            var events = await _eventService.GetEventsAsync();
            var eventRequested = events.Where(x => x.Id == id);

            return View(eventRequested);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}