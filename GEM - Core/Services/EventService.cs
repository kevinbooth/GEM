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
                    Owner = new User 
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Username = "jdoe18",
                        Password = "Password"
                    },
                    IsPrivate = false,
                    Title = "Title",
                    Description = "Description",
                    DateAndTime = DateTime.Now.AddDays(14),
                    Location = "Nowhere, USA",
                    Attendees = null
                }
            };
            return Task.FromResult(placeholder);
        }
    }
}