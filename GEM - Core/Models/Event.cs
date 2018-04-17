using System;
using System.Collections.Generic;

namespace GEM.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public User Owner { get; set; }  
        public bool IsPrivate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateAndTime { get; set; }
        public string Location { get; set; }
        public List<User> Attendees { get; set; }
        // public int Attendees { get; set; } //-------If doing attendee count, not actual list of attendees
    }
}