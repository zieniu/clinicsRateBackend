using ClinicsRate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IDictCityService
    {
        IEnumerable<DictCity> GetAllDictCity();
        Task<int> AddDictCityAsync(DictCity dictCity);
        Task<int> UpdateDictCityAsync(DictCity dictCity);
        Task DeleteDictCity(int dictCityId);
    }
}
