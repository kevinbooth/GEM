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
        private readonly IUserService _userService;

        public CreateController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            ViewData["Message"] = "Page that has a form to create a new event.";
            return View();
        }

        //~/Create/Event
        public async Task<IActionResult> Event(Event newEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var successful = await _eventService.AddEventAsync(newEvent);
            if (!successful)
                return BadRequest(new { error = "Could not create Event." });

            return Ok();
        }
        //~/Create/User
        public async Task<IActionResult> User(User newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var successful = await _userService.AddUserAsync(newUser);
            if (!successful)
                return BadRequest(new { error = "Could not create User." });

            return Ok();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}