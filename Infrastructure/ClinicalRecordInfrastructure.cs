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
    public class ClinicalRecordInfrastructure : IClinicalRecordInfrastructure
    {
        private readonly AppDbContext _context;

        public ClinicalRecordInfrastructure(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateClinicalRecord(ClinicalRecord record)
        {
            try
            {
                _context.ClinicalRecords.Add(record);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<ClinicalRecord>> GetClinicalRecordByPetId(int petId)
        {
            return await _context.ClinicalRecords.Where(e => e.PetId == petId).ToListAsync();
        }
    }
}
