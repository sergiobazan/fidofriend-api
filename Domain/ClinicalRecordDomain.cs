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
    public class ClinicalRecordDomain : IClinicalRecordDomain
    {
        private readonly IClinicalRecordInfrastructure _recordInfrastructure;

        public ClinicalRecordDomain(IClinicalRecordInfrastructure recordInfrastructure)
        {
            _recordInfrastructure = recordInfrastructure;
        }
        public async Task<bool> CreateClinicalRecord(ClinicalRecord record)
        {
            return await _recordInfrastructure.CreateClinicalRecord(record);
        }

        public async Task<List<ClinicalRecord>> GetClinicalRecordByPetId(int petId)
        {
            return await _recordInfrastructure.GetClinicalRecordByPetId(petId);
        }
    }
}
