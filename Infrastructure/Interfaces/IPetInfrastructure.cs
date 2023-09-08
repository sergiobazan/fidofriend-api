using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IPetInfrastructure
    {
        Task<bool> CreatePet(Pet Pet);
        Task<bool> UpdatePet(Pet Pet);
        Task<bool> DeletePet(int id);
        Task<Pet?> GetPetById(int id);
    }
}
