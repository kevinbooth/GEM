using GEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Services
{
    public interface IEvent_User
    {
        Task<IEnumerable<Event_User>> GetEvent_UsersAsync();
    }
}
