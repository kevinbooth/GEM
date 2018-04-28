using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Models
{
    public class NewEvent
    {
        [Required]
        public string Owner { get; set; }
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
