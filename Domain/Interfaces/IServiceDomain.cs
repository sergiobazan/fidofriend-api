using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceDomain
    {
        Task<bool> CreateService(Service service);
        Task<List<Service>> GetServices();
        Task<Service?> GetService(int id);
    }
}
