using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GEM.Models;

namespace GEM.Services
{
    public class EventService : IEventService
    {
        public Task<IEnumerable<Event>> GetEventsAsync() 
        {
            IEnumerable<Event> placeholder = new[]
            {
                new Event 
                {
                    Owner = new Guid(),
                    IsPrivate = false,
                    Title = "Title",
                    Description = "Description",
                    DateAndTime = DateTime.Now.AddDays(14),
                    Location = "Nowhere, USA"
                }
            };
            return Task.FromResult(placeholder);
        }
    }
}