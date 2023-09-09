using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClinicalRecordDomain
    {
        Task<bool> CreateClinicalRecord(ClinicalRecord record);
        Task<List<ClinicalRecord>> GetClinicalRecordByPetId(int petId);
    }
}
