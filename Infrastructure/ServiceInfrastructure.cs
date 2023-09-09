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
    }
}
