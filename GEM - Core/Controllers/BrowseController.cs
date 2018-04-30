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
        /* This is the browser controller, which manages all routes that go to ~/Browse. */ 
        private readonly IEventService _eventService;
        private readonly IEvent_OwnerService _eventOwnerService;
        private readonly IEvent_UserService _eventUserService;
        private readonly IApplicationUserService _applicationUserService;
        public BrowseController(IEventService eventService, IEvent_OwnerService eventOwnerService, 
            IEvent_UserService eventUserService, IApplicationUserService applicationUserService)
        {
            _eventService = eventService;
            _eventOwnerService = eventOwnerService;
            _eventUserService = eventUserService;
            _applicationUserService = applicationUserService;
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
            //Getting data from db
            var eventUsers = await _eventUserService.GetEvent_UsersAsync();
            var eventOwners = await _eventOwnerService.GetEvent_OwnersAsync();
            var events = await _eventService.GetEventsAsync();
            var applicationUsers = await _applicationUserService.GetApplicationUsersAsync();

            //Selecting the owner of the event with id == id
            var eventOwner = eventOwners.Where(x => x.Event == id).First();

            //Sending data to view
            ViewData["Event"] = events.Where(x => x.Id == id).First();
            ViewData["EventUsers"] = eventUsers.Where(x => x.Event == id);
            ViewData["Owner"] = applicationUsers.Where(x => x.Email == eventOwner.Owner).First();

            return View();
        }

        //Route called when clicking to attend an event
        public async Task<IActionResult> Thanks(Guid id, string userId)
        {
            //Gets event
            var events = await _eventService.GetEventsAsync();
            var eventRequested = events.Where(x => x.Id == id).First();

            //Gets user to add to event
            var users = await _applicationUserService.GetApplicationUsersAsync();
            var user = users.Where(x => x.Id == userId).First();

            //Error checking
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Checks if user is already attending
            string alreadyAttending = "true";

            var eventUsers = await _eventUserService.GetEvent_UsersAsync();
            if (eventUsers.Where(x => x.Event == id && x.User == user.Email).Count() == 0)
            {
                alreadyAttending = "false";
                var successful = await _eventUserService.AddUserToEvent(eventRequested, user.Email);

                if (!successful)
                    return BadRequest(new { error = "Could not add user to event." });
            }

            //Sending data to view
            ViewData["Attending"] = alreadyAttending;
            ViewData["Event"] = eventRequested;
            return View();
        }

        //Error page
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}