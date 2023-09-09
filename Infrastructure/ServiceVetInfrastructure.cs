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
    public class ServiceVetInfrastructure : IServiceVetInfrastructure
    {
        private readonly AppDbContext _context;

        public ServiceVetInfrastructure(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateServiceVet(ServiceVet serviceVet)
        {
            try
            {
                _context.ServicesVet.Add(serviceVet);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteServiceVet(int id)
        {
            try
            {
                var serviceVet = await _context.ServicesVet.FindAsync(id);
                if (serviceVet == null) return false;
                _context.ServicesVet.Remove(serviceVet);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ServiceVet>> GetAllByVetId(int vetId)
        {
            return await _context.ServicesVet.Where(e => e.VetId == vetId).ToListAsync();
        }

        public async Task<ServiceVet?> GetServiceVetById(int serId, int vetId)
        {
            return await _context.ServicesVet.FirstOrDefaultAsync(e => e.VetId == vetId && e.Id == serId);
        }

        public async Task<bool> UpdateServiceVet(ServiceVet serviceVet)
        {
            try
            {
                var found = await _context.ServicesVet.FirstOrDefaultAsync(e => e.ServiceId == serviceVet.ServiceId && e.VetId == serviceVet.VetId);
                if (found == null) return false;
                found.Price = serviceVet.Price;
                _context.ServicesVet.Update(found);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
