using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GEM.Models
{
    public class Event
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool IsPrivate { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTimeOffset DateAndTime { get; set; }
        [Required]
        public string Location { get; set; }
    }
}