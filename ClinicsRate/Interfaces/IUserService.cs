using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicsRate.Models;

namespace ClinicsRate.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user, string password);
        Task UpdateAsync(User user, string password = null);
        Task DeleteAsync(int id);
    }
}
