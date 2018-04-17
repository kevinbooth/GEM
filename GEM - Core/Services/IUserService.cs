using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GEM.Models;

namespace GEM.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
    }
}