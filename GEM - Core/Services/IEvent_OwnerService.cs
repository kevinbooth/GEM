using GEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Services
{
    public interface IEvent_OwnerService
    {
        Task<IEnumerable<Event_Owner>> GetEvent_OwnersAsync();
        Task<bool> AddOwnerToEvent(Event eventToBeOwned, ApplicationUser owner);
    }
}
