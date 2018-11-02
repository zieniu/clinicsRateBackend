using ClinicsRate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Interfaces
{
    public interface IDictProvinceService
    {
        Task<IEnumerable<DictProvince>> GetAllDictProvinceAsync();
        Task<int> AddDictProvinceAsync(DictProvince dictProvince);
        Task<int> UpdateDictProvinceAsync(DictProvince dictProvince);
        Task DeleteDictProvinceAsync(int dictProvinceId);
    }
}
