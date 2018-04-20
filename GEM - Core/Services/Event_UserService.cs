using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GEM.Models;

namespace GEM.Services
{
    public class Event_UserService : IEvent_UserService
    {
        public Task<IEnumerable<Event_User>> GetEvent_UsersAsync()
        {
            IEnumerable<Event_User> placeholder = new[]
            {
                new Event_User
                {
                    Event = new Guid(),
                    User = new Guid()
                }
            };

            return Task.FromResult(placeholder);
        }
    }
}
