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
    public class ServiceInfrastructure : IServiceInfrastructure
    {
        private readonly AppDbContext _context;

        public ServiceInfrastructure(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateService(Service service)
        {
            try
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Service?> GetService(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<List<Service>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<bool> UpdateService(int id, Service service)
        {
            var serviceFound = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (serviceFound == null) return false;

            serviceFound.Name = service.Name;
            serviceFound.Price = service.Price;
            serviceFound.ImgUrl = service.ImgUrl;
            serviceFound.Description = service.Description;
            _context.Services.Update(serviceFound);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
