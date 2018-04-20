using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GEM.Models;

namespace GEM.Services
{
    public interface IEvent_UserService
    {
        Task<IEnumerable<Event_User>> GetEvent_UsersAsync();
    }
}
