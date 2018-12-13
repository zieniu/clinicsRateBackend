using ClinicsRate.Models;
using ClinicsRate.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IClinicService
    {
        Task<IEnumerable<ClinicDto>> GetClinicsAsync();        
        Task<ClinicDto> GetClinicAsync(int id);
        Task<int> UpdateClinicAsync(ClinicDto clinic);
        Task DeleteClinicAsync(int id);
        Task<int> AddClinicAsync(ClinicDto clinic);
    }
}
