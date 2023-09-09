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
    public class PetInfrastructure : IPetInfrastructure
    {
        private readonly AppDbContext _context;

        public PetInfrastructure(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePet(Pet pet)
        {
            try
            {
                _context.Pets.Add(pet);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePet(int id)
        {
            try
            {
                var pet = await _context.Pets.FindAsync(id);
                if (pet == null) return false;
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Pet?> GetPetById(int id)
        {
            return await _context.Pets.Include(e => e.ClinicalRecords).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> UpdatePet(Pet pet)
        {
            var petFound = await _context.Pets.FirstOrDefaultAsync(x => x.Id == pet.Id);
            if (petFound == null) return false;

            petFound.Name = pet.Name;
            petFound.Description = pet.Description;
            petFound.Age = pet.Age;
            petFound.ImgUrl = pet.ImgUrl;
            
            _context.Pets.Update(petFound);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
