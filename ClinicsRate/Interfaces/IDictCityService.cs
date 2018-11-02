using ClinicsRate.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IDictCityService
    {
        Task<IEnumerable<DictCity>> GetAllDictCityAsync();        
        Task<int> AddDictCityAsync(DictCity dictCity);
        Task<int> UpdateDictCityAsync(DictCity dictCity);
        Task DeleteDictCity(int dictCityId);
    }
}
