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
    public class ServiceDomain : IServiceDomain
    {
        private readonly IServiceInfrastructure _serviceInfrastructure;

        public ServiceDomain(IServiceInfrastructure serviceInfrastructure)
        {
            _serviceInfrastructure = serviceInfrastructure;
        }
        public async Task<bool> CreateService(Service service)
        {
            return await _serviceInfrastructure.CreateService(service);
        }

        public async Task<Service?> GetService(int id)
        {
            return await _serviceInfrastructure.GetService(id);
        }

        public async Task<List<Service>> GetServices()
        {
            return await _serviceInfrastructure.GetServices();
        }
    }
}
