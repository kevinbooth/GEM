using GEM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GEM.Services
{
    public interface IApplicationUserService
    {
        Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync();
    }
}
