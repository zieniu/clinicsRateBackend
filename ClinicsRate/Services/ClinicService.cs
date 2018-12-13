using AutoMapper;
using ClinicsRate.Helpers;
using ClinicsRate.Interfaces;
using ClinicsRate.Models;
using ClinicsRate.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Services
{
    public class ClinicService : IClinicService
    {
        private readonly ClinicRateDbContext _clinicRateDbContext;
        private readonly IMapper _mapper;

        public ClinicService(ClinicRateDbContext clinicRateDbContext, IMapper mapper)
        {
            _clinicRateDbContext = clinicRateDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Metoda dodająca nową klinike do bazy danych
        /// </summary>
        /// <param name="clinic"></param>
        /// <returns></returns>
        public async Task<int> AddClinicAsync(ClinicDto clinicDto)
        {
            if (clinicDto == null)
            {
                throw new Exception("Obiekt clinic nie może być pusty.");
            }
                       
            var cityId = await _clinicRateDbContext.DictCities.Where(s => s.Name == clinicDto.City) // pobieranie danych z bazy danych odnosnie miasta
                .Select(c => c.DictCityId)
                .FirstAsync();

            var provinceId = await _clinicRateDbContext.DictProvinces.Where(s => s.Name == clinicDto.Province) // pobieranie danych z bazy danych odnosnie wojewodztwa
                .Select(p => p.DictProvinceId)
                .FirstAsync();

            if (cityId <= 0 || provinceId <= 0)
            {
                throw new Exception("Nie znaleziono miasta, badz wojewodztwa o podanym stringu w bazie danych");
            }

            var clinic = new Clinic() // tworzenie nowego obiektu 
            {
                ClinicId = clinicDto.ClinicId,
                ClinicName = clinicDto.ClinicName,
                Latitude = clinicDto.Latitude,
                Longitude = clinicDto.Longitude,
                PhoneNumber = clinicDto.PhoneNumber,
                PostCode = clinicDto.PostCode,
                ProvinceId = provinceId,
                Street = clinicDto.Street,
                CityId = cityId
            };

            try
            {
                await _clinicRateDbContext.Clinics.AddAsync(clinic);
                await _clinicRateDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception)
            {
                throw;
            }

            return clinic.ClinicId;
        }

        /// <summary>
        /// Metoda usuwająca klinike o podanym nr id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteClinicAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Zmienna id nie może być mniejsza bądź równa 0");
            }

            var clinic = await _clinicRateDbContext.Clinics.SingleOrDefaultAsync(s => s.ClinicId == id);

            if (clinic != null)
            {
                _clinicRateDbContext.Remove(clinic);
                _clinicRateDbContext.RemoveRange(_clinicRateDbContext.Opinions.Where(s => s.ClinicId == id));
                await _clinicRateDbContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Metoda zwracająca klinike o podanym id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClinicDto> GetClinicAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Zmienna id nie może być mniejsza bądź równa 0");
            }

            Clinic clinic = await _clinicRateDbContext.Clinics
                .Include(p => p.DictProvince)
                .Include(c => c.DictCity)
                .Where(p => p.ClinicId == id)
                .FirstOrDefaultAsync();

            if (clinic == null)
            {
                throw new Exception("Nie znaleziono kliniki o podanym id");
            }

            var clinicDto = _mapper.Map<ClinicDto>(clinic);

            return clinicDto;
        }


        /// <summary>
        /// Metoda odpowiadajaca za wyświetlanie wszystkich klinik znajdujących się w bazie danych
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClinicDto>> GetClinicsAsync()
        {
            IEnumerable<Clinic> clinics = await _clinicRateDbContext.Clinics
                .Include(p => p.DictProvince)
                .Include(c => c.DictCity)
                .ToListAsync();

            var clinicDto = _mapper.Map<IEnumerable<ClinicDto>>(clinics);

            return clinicDto;
        }


        /// <summary>
        /// Metoda odpowiadajaca za aktualizowanie kliniki w bazie danych
        /// </summary>
        /// <param name="clinic"></param>
        /// <returns></returns>
        public async Task<int> UpdateClinicAsync(ClinicDto clinicDto)
        {
            if (clinicDto == null)
            {
                throw new Exception("Obiekt clinic nie może być pusty.");
            }


            var cityId = await _clinicRateDbContext.DictCities.Where(s => s.Name == clinicDto.City)
                .Select(c => c.DictCityId)
                .FirstAsync();

            var provinceId = await _clinicRateDbContext.DictProvinces.Where(s => s.Name == clinicDto.Province)
                .Select(p => p.DictProvinceId)
                .FirstAsync();

            if (cityId <= 0 || provinceId <= 0)
            {
                throw new Exception("Nie znaleziono miasta, badz wojewodztwa o podanym stringu w bazie danych");
            }

            var clinic = new Clinic()
            {
                ClinicId = clinicDto.ClinicId,
                ClinicName = clinicDto.ClinicName,
                Latitude = clinicDto.Latitude,
                Longitude = clinicDto.Longitude,
                PhoneNumber = clinicDto.PhoneNumber,
                PostCode = clinicDto.PostCode,
                ProvinceId = provinceId,
                Street = clinicDto.Street,
                CityId = cityId
            };

            _clinicRateDbContext.Clinics.Update(clinic);
            await _clinicRateDbContext.SaveChangesAsync();
            return clinic.ClinicId;
        }
    }
}
