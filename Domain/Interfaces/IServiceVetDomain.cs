using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceVetDomain
    {
        Task<bool> CreateServiceVet(ServiceVet serviceVet);
        Task<bool> UpdateServiceVet(ServiceVet serviceVet);
        Task<bool> DeleteServiceVet(int id);
        Task<ServiceVet?> GetServiceVetById(int serId, int vetId);
        Task<List<ServiceVet>> GetAllByVetId(int vetId);
    }
}
