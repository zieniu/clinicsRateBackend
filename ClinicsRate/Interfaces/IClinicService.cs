using ClinicsRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IClinicService
    {
        Task<IEnumerable<Clinic>> GetClinicsAsync();        
        Task<Clinic> GetClinicAsync(int id);
        Task<int> UpdateClinicAsync(Clinic clinic);
        Task DeleteClinicAsync(int id);
        Task<int> AddClinicAsync(Clinic clinic);
    }
}
