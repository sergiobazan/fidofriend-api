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
    public class ServiceVetDomain : IServiceVetDomain
    {
        private readonly IServiceVetInfrastructure _infrastructure;

        public ServiceVetDomain(IServiceVetInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }
        public async Task<bool> CreateServiceVet(ServiceVet serviceVet)
        {
            return await _infrastructure.CreateServiceVet(serviceVet);
        }

        public async Task<bool> DeleteServiceVet(int id)
        {
            return await _infrastructure.DeleteServiceVet(id);
        }

        public async Task<List<ServiceVet>> GetAllByVetId(int vetId)
        {
            return await _infrastructure.GetAllByVetId(vetId);
        }

        public async Task<ServiceVet?> GetServiceVetById(int serId, int vetId)
        {
            return await _infrastructure.GetServiceVetById(serId, vetId);
        }

        public async Task<bool> UpdateServiceVet(ServiceVet serviceVet)
        {
            return await _infrastructure.UpdateServiceVet(serviceVet);
        }
    }
}
