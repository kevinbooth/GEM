using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Models
{
    public class Event_User
    {
        [Key]
        public Guid Event { get; set; }
        [Key]
        public Guid User { get; set; }
    }
}
