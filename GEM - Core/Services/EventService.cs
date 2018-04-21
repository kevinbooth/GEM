using System;
using System.Collections.Generic;
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
        public async Task<bool> AddEventAsync(Event newEvent)
        {
            var entity = new Event
            {
                Id = Guid.NewGuid(),
                Owner = newEvent.Owner,
                IsPrivate = newEvent.IsPrivate,
                Title = newEvent.Title,
                Description = newEvent.Description,
                DateAndTime = newEvent.DateAndTime,
                Location = newEvent.Location
            };

            _context.Events.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}