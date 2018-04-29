using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GEM.Data;
using GEM.Models;
using Microsoft.EntityFrameworkCore;

namespace GEM.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Event>> GetEventsAsync() 
        {
            var events = await _context.Events
                .ToArrayAsync();

            return events;
        }
        public async Task<bool> AddEventAsync(NewEvent newEvent)
        {
            var event_entity = new Event
            {
                Id = Guid.NewGuid(),
                IsPrivate = newEvent.IsPrivate,
                Title = newEvent.Title,
                Description = newEvent.Description,
                DateAndTime = newEvent.DateAndTime,
                Location = newEvent.Location
            };

            var event_owner_entity = new Event_Owner
            {
                Event = event_entity.Id,
                Owner = newEvent.Owner
            };

            _context.Events.Add(event_entity);

            var saveEvents_Result = await _context.SaveChangesAsync();

            _context.Event_Owners.Add(event_owner_entity);

            var saveEventOwners_Result = await _context.SaveChangesAsync();

            int saveEventUsers_Result = 1;
            if (newEvent.Attendees != null && newEvent.Attendees.Count() != 0)
            {
                
                foreach (string userEmail in newEvent.Attendees)
                {
                    
                    _context.Event_Users.Add(
                        new Event_User
                        {
                            Event = event_entity.Id,
                            User = userEmail
                        });
                    saveEventUsers_Result = await _context.SaveChangesAsync();
                }
            }

            return saveEvents_Result == 1 && saveEventOwners_Result == 1 && saveEventUsers_Result == 1;
        }
    }
}