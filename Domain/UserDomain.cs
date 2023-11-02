using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserInfrastructure _userInfrastructure;

        public UserDomain(IUserInfrastructure userInfrastructure)
        {
            _userInfrastructure = userInfrastructure;
        }
        public async Task<bool> CreateUser(User user)
        {
            return await _userInfrastructure.CreateUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userInfrastructure.DeleteUser(id);
        }

        public async Task<List<Pet>> GetPetsByUserId(int id)
        {
            return await _userInfrastructure.GetPets(id);
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userInfrastructure.GetUserById(id);
        }

        public async Task<User?> GetUserLogin(string email, string password)
        {
            return await _userInfrastructure.GetUserLogin(email, password);
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            return await _userInfrastructure.UpdateUser(id, user);
        }
    }
}
