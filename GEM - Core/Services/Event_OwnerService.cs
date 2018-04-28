using GEM.Data;
using GEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Services
{
    public class Event_OwnerService : IEvent_OwnerService
    {
        private readonly ApplicationDbContext _context;
        public Event_OwnerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Event_Owner>> GetEvent_OwnersAsync()
        {
            var event_owners = await _context.Event_Owners
                .ToArrayAsync();

            return event_owners;
        }
        public async Task<bool> AddOwnerToEvent(Event eventToOwn, ApplicationUser owner)
        {
            var entity = new Event_Owner
            {
                Event = eventToOwn.Id,
                Owner = owner.Email
            };

            _context.Event_Owners.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
