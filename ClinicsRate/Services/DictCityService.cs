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
    public class DictCityService : IDictCityService
    {
        private readonly ClinicRateDbContext _clinicRateDbContext;

        public DictCityService(ClinicRateDbContext clinicRateDbContext)
        {
            _clinicRateDbContext = clinicRateDbContext;
        }

        /// <summary>
        /// Metoda dodajaca nowy slownik do bazy danych
        /// </summary>
        /// <param name="dictCity"></param>
        /// <returns></returns>
        public async Task<int> AddDictCityAsync(DictCity dictCity)
        {
            if (dictCity == null)
            {
                throw new Exception("Obiekt dictCity nie może być pusty.");
            }
            
            _clinicRateDbContext.DictCities.Add(dictCity);
            await _clinicRateDbContext.SaveChangesAsync();
            return dictCity.DictCityId;
        }

        /// <summary>
        /// Metoda usuwająca słownik z bazy danych
        /// </summary>
        /// <param name="dictCityId"></param>
        /// <returns></returns>
        public async Task DeleteDictCity(int dictCityId)
        {
            if(dictCityId <= 0)
            {
                throw new Exception("Zmienna dictCityId nie może być mniejsza bądź rowna 0");
            }

            var dictCity = await _clinicRateDbContext.DictCities.SingleOrDefaultAsync(s => s.DictCityId == dictCityId);

            if(dictCity != null)
            {
                _clinicRateDbContext.DictCities.Remove(dictCity);
                await _clinicRateDbContext.SaveChangesAsync();
            }                        
        }

        /// <summary>
        /// Metoda zwracająca wszystkie slowniki miast z bazy danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DictCity>> GetAllDictCityAsync()
        {
           return await _clinicRateDbContext.DictCities.ToListAsync();
        }

        public async Task<int> UpdateDictCityAsync(DictCity dictCity)
        {
            if(dictCity == null)
            {
                throw new Exception("Obiekt dictCity nie może być pusty.");
            }

            _clinicRateDbContext.DictCities.Update(dictCity);
            await _clinicRateDbContext.SaveChangesAsync();

            return dictCity.DictCityId;
        }
    }
}
