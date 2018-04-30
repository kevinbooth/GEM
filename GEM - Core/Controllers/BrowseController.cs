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
            var eventUsers = await _eventUserService.GetEvent_UsersAsync();
            var eventOwners = await _eventOwnerService.GetEvent_OwnersAsync();
            var events = await _eventService.GetEventsAsync();
            var applicationUsers = await _applicationUserService.GetApplicationUsersAsync();

            var eventOwner = eventOwners.Where(x => x.Event == id).First();

            ViewData["Event"] = events.Where(x => x.Id == id).First();
            ViewData["EventUsers"] = eventUsers.Where(x => x.Event == id);
            ViewData["Owner"] = applicationUsers.Where(x => x.Email == eventOwner.Owner).First();

            return View();
        }

        public async Task<IActionResult> Thanks(Guid id, string userId)
        {
            
            var events = await _eventService.GetEventsAsync();
            var eventRequested = events.Where(x => x.Id == id).First();

            var users = await _applicationUserService.GetApplicationUsersAsync();
            var user = users.Where(x => x.Id == userId).First();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string alreadyAttending = "true";

            var eventUsers = await _eventUserService.GetEvent_UsersAsync();
            if (eventUsers.Where(x => x.Event == id && x.User == user.Email).Count() == 0)
            {
                alreadyAttending = "false";
                var successful = await _eventUserService.AddUserToEvent(eventRequested, user.Email);

                if (!successful)
                    return BadRequest(new { error = "Could not add user to event." });
            }

            ViewData["Attending"] = alreadyAttending;
            ViewData["Event"] = eventRequested;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}