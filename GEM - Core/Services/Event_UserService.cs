using GEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Services
{
    public class Event_UserService : IEvent_User
    {
        public Task<IEnumerable<Event_User>> GetEvent_UsersAsync()
        {
            IEnumerable<Event_User> placeholder = new[]
            {
                new Event_User
                {
                    User = new Guid(),
                    Event = new Guid()
                }
            };

            return Task.FromResult(placeholder);
        }
    }
}
