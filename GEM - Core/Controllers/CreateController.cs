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

        private readonly IEventService _eventService;

        public CreateController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Thanks()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Event(NewEvent newEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var successful = await _eventService.AddEventAsync(newEvent);
            if (!successful)
                return BadRequest(new { error = "Could not create Event." });

            return View("Thanks");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}