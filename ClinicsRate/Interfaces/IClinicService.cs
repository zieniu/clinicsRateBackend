using ClinicsRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IClinicService
    {
        IEnumerable<Clinic> GetClinics();        
        Task<Clinic> GetClinicAsync(int id);
        Task<int> UpdateClinicAsync(Clinic clinic);
        Task DeleteClinicAsync(int id);
        Task<int> AddClinicAsync(Clinic clinic);
    }
}
