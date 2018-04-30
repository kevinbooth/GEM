using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GEM.Models;
using GEM.Services;

/* This is the controller that works with all routes that go through ~/Create */ 
namespace GEM.Controllers
{
    public class CreateController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IApplicationUserService _applicationUserService;

        //Enables access to db tables
        public CreateController(IEventService eventService, IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
            _eventService = eventService;
        }

        //Allows for route ~/Controller
        public async Task<IActionResult> Index()
        {
            //Gets all users and passes it to view
            var users = await _applicationUserService.GetApplicationUsersAsync();
            ViewData["Users"] = users;

            return View();
        }

        //Allows for route ~/Controller/Thanks
        public IActionResult Thanks()
        {
            return View();
        }

        //Allows for route ~/Controller/Event?<newEvent>
        [HttpPost]
        public async Task<IActionResult> Event(NewEvent newEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Goes to db service and adds the created event to db. See Services/EventService
            var successful = await _eventService.AddEventAsync(newEvent);
            if (!successful)
                return BadRequest(new { error = "Could not create Event." });


            return View("Thanks");
        }

        //Allows for route ~/Controller/Error
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}