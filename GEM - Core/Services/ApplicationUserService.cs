using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GEM.Data;
using GEM.Models;
using Microsoft.EntityFrameworkCore;

namespace GEM.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetApplicationUsersAsync()
        {
            var applicationUsers = await _context.ApplicationUsers
                .ToArrayAsync();

            return applicationUsers;
        }
    }
}
