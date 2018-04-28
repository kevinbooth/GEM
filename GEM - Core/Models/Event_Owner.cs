using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Models
{
    public class Event_Owner
    {
        [Required]
        [Key]
        public Guid Event { get; set; }
        [Required]
        [Key]
        public string Owner { get; set; }
    }
}
