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
    public class PetDomain : IPetDomain
    {
        private readonly IPetInfrastructure _petInfrastructure;

        public PetDomain(IPetInfrastructure petInfrastructure)
        {
            _petInfrastructure = petInfrastructure;
        }
        public async Task<bool> CreatePet(Pet pet)
        {
            return await _petInfrastructure.CreatePet(pet);
        }

        public async Task<bool> DeletePet(int id)
        {
            return await _petInfrastructure.DeletePet(id);
        }

        public async Task<Pet?> GetPetById(int id)
        {
            return await _petInfrastructure.GetPetById(id);
        }

        public async Task<bool> UpdatePet(Pet pet)
        {
            return await _petInfrastructure.UpdatePet(pet);
        }
    }
}
