using GEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Services
{
    public interface IEvent_UserService
    {
        Task<IEnumerable<Event_User>> GetEvent_UsersAsync();
        Task<bool> AddUserToEvent(Event eventToAttend, User userToAttend);
    }
}
