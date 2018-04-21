using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GEM.Data;
using GEM.Models;
using Microsoft.EntityFrameworkCore;

namespace GEM.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync() 
        {
            var users = await _context.Users
                .ToArrayAsync();

            return users;
        }

        public async Task<bool> AddUserAsync(User newUser)
        {
            var entity = new User
            {
                Id = Guid.NewGuid(),
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Username = newUser.Username,
                Password = newUser.Password
            };

            _context.Users.Add(entity);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
    }
}