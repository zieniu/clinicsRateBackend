using ClinicsRate.Helpers;
using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Services
{
    public class DictProvinceService : IDictProvinceService
    {
        private readonly ClinicRateDbContext _clinicRateDbContext;

        public DictProvinceService(ClinicRateDbContext clinicRateDbContext)
        {
            _clinicRateDbContext = clinicRateDbContext;
        }

        /// <summary>
        /// Metoda dodająca nowy słownik do bazy danych
        /// </summary>
        /// <param name="dictProvince"></param>
        /// <returns></returns>
        public async Task<int> AddDictProvinceAsync(DictProvince dictProvince)
        {
            if (dictProvince == null)
            {
                throw new Exception("Obiekt dictProvince nie może być pusty.");
            }

            await _clinicRateDbContext.DictProvinces.AddAsync(dictProvince);
            await _clinicRateDbContext.SaveChangesAsync();

            return dictProvince.DictProvinceId;
        }

        /// <summary>
        /// Metoda usuwająca podany słownik z bazy danych
        /// </summary>
        /// <param name="dictProvinceId"></param>
        /// <returns></returns>
        public async Task DeleteDictProvinceAsync(int dictProvinceId)
        {
            if (dictProvinceId <= 0)
            {
                throw new Exception("Zmienna dictProvinceId nie może być mniejsza bądź równa 0");
            }

            var dictProvince = await _clinicRateDbContext.DictProvinces.SingleOrDefaultAsync(s => s.DictProvinceId == dictProvinceId);

            if (dictProvince != null)
            {
                _clinicRateDbContext.DictProvinces.Remove(dictProvince);
                await _clinicRateDbContext.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Metoda wyświetlająca wszystkie slowniki z bazy danych
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DictProvince> GetAllDictProvince()
        {
            return _clinicRateDbContext.DictProvinces.ToList();
        }

        /// <summary>
        /// Metoda aktualizaująca podany słownik w bazie danych
        /// </summary>
        /// <param name="dictProvince"></param>
        /// <returns></returns>
        public async Task<int> UpdateDictProvinceAsync(DictProvince dictProvince)
        {
            if (dictProvince == null)
            {
                throw new Exception("Obiekt dictProvince nie może być pusty.");
            }

            _clinicRateDbContext.DictProvinces.Update(dictProvince);
            await _clinicRateDbContext.SaveChangesAsync();
            return dictProvince.DictProvinceId;
        }
    }
}
