using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GEM.Models;

namespace GEM.Services
{
    public class UserService : IUserService
    {
        public Task<IEnumerable<User>> GetUsersAsync() 
        {
            IEnumerable<User> placeholder = new[] 
            { 
                new User
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Username = "jdoe2018",
                    Password = "Password"
                } 
            };
            
            return Task.FromResult(placeholder);
        }
    }
}