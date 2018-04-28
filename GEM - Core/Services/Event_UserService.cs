using GEM.Data;
using GEM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Services
{
    public class Event_UserService : IEvent_UserService
    {
        private readonly ApplicationDbContext _context;
        public Event_UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Event_User>> GetEvent_UsersAsync()
        {
            var event_users = await _context.Event_Users
                .ToArrayAsync();

            return event_users;
        }
        public async Task<bool> AddUserToEvent(Event eventToAttend, string userToAttend)
        {
            var entity = new Event_User
            {
                Event = eventToAttend.Id,
                User = userToAttend
            };

            _context.Event_Users.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}
