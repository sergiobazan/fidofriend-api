using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPetDomain
    {
        Task<bool> CreatePet(Pet pet);
        Task<bool> UpdatePet(Pet pet);
        Task<bool> DeletePet(int id);
        Task<Pet?> GetPetById(int id);
    }
}
