using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserInfrastructure
    {
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserLogin(string email, string password);
        Task<List<Pet>> GetPets(int id);
    }
}
