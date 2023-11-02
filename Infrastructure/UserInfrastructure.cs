using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserInfrastructure : IUserInfrastructure
    {
        private readonly AppDbContext _context;

        public UserInfrastructure(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null) return false;
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Pet>> GetPets(int id)
        {
            return await _context.Pets.Where(e => e.OwnerId == id).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserLogin(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userFound == null) return false;

            userFound.FirstName = user.FirstName;
            userFound.LastName = user.LastName;
            userFound.Email = user.Email;
            userFound.Address = user.Address;
            userFound.ImgUrl = user.ImgUrl;
            userFound.Description = user.Description;
            _context.Users.Update(userFound);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
